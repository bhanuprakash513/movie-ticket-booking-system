using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;
using MovieBooking.Model.Entities;
using System.Web.Security;

namespace MovieBooking.MVC.UI.Controllers
{
    public class MovieBookingController : Controller
    {
        //
        // GET: /MovieBooking/

        public ActionResult Index()
        {
         
            BookingRepository repo = new BookingRepository();

            IEnumerable <Booking> bookings = repo.GetMovieBookings();
            
            return View(bookings.ToList());
        }

        public ActionResult Get()
        {
            BookingRepository bookingRepo = new BookingRepository();
            //RegisteredUser user = repo3.FindById(new Guid("0AE3AAEB-A8FC-43AC-B441-0E94C72CA9DB"));

            //String userName = User.Identity.Name;
            //MembershipUserCollection collection = Membership.FindUsersByName(userName);

            MembershipUser user =  Membership.GetUser(true);

            if (user == null)
            {
                return RedirectToAction("LogOn", "Account");
            }
            

            List<Booking> bookings = bookingRepo.GetMovieBookingsForCustomer(new Guid(user.ProviderUserKey.ToString()));
            foreach (Booking booking in bookings)
            {
                MovieScheduleItemRepository scheduleItemRepo = new MovieScheduleItemRepository();
                MovieSchedule_Item item = scheduleItemRepo.GetMovieScheduleItem(Int32.Parse(booking.ScheduleID.ToString()));

                if (item != null)
                {
                    MovieScheduleRepository scheduleRepo = new MovieScheduleRepository();
                    MovieSchedule schedule = scheduleRepo.GetSchedule(Int32.Parse(item.MovieScheduleID.ToString()));

                    if (schedule != null)
                    {

                        MovieRepository movieRepo = new MovieRepository();
                        mb_Movie movie = movieRepo.FindbyId(Int32.Parse(schedule.MovieID.ToString()));

                        if (movie != null)
                        {
                            booking.movie = new Movie(movie);
                        }

                        TheatreRepository theatreRepo = new TheatreRepository();
                        mb_Theatre theatre = theatreRepo.FindById(Int32.Parse(schedule.TheatreID.ToString()));

                        if (theatre != null)
                        {
                            booking.theatre = new Theatre(theatre);
                        }

                        HallRepository hallRepo = new HallRepository();
                        mb_Hall hall = hallRepo.GetHall(Int32.Parse(schedule.HallID));

                        if (theatre != null)
                        {
                            booking.hall = new Hall(hall);
                        }

                    }

                }

            }
            ViewBag.bookings = bookings;

            return View();
        }

        public ActionResult Cancel(int booking_id)
        {
            ViewBag.booking_id = booking_id;
            return View();
        }


        public ActionResult CancelSuccess()
        {
            try
            {
                int booking_id = Int32.Parse(Request["booking_id"].ToString());
                BookingRepository bookingRepo = new BookingRepository();
                int status = bookingRepo.CancelBooking(booking_id);

                if (status != 0)
                {
                    ViewBag.message = "Successfully cancelled your ticket. Please collect the money once u visit the theatre next time";
                    return RedirectToAction("Get", "MovieBooking");
                }
                else
                {
                    ViewBag.message = "Error occurred while cancelling ticket. Sorry for inconvenience caused. Please call our customer care";
                    return RedirectToAction("Get", "MovieBooking");
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error occurred while cancelling ticket. Sorry for inconvenience caused. Please call our customer care";
                return RedirectToAction("Get", "MovieBooking");
            }
        }

        public ActionResult CancelFailure()
        {
            //Tests to consume net.Tcp binding services
            //using (PaymentService.PaymentServiceClient client = new PaymentService.PaymentServiceClient())
            //{
            //    PaymentService.Payment pay = new PaymentService.Payment();
            //    pay.CardExpiry = "2015/05";
            //    pay.CardHolderName = "CardHolderName";
            //    pay.CCV = "1234";
            //    pay.CreditCardNo = "1234-5678-9012-3456";
            //    pay.GSTPercent = 7.5;
            //    pay.MovieBookingID = 1;
            //    pay.PaymentDate = DateTime.Now;
            //    pay.PaymentModeID = "01";
            //    pay.TotalAmount = 100.75m;

            //    int id = client.Insert(pay);
            //}

            return RedirectToAction("Get", "MovieBooking");
        }


    }
}
