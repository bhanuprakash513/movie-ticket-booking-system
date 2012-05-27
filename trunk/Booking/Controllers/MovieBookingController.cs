using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;
using MovieBooking.Model.Entities;

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
            List<Booking> bookings = bookingRepo.GetMovieBookingsForCustomer(new Guid("0AE3AAEB-A8FC-43AC-B441-0E94C72CA9DB"));
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

        public ActionResult Cancel()
        {


            return View();
        }


        public ActionResult CancelSuccess()
        {


            return View();
        }

        public ActionResult CancelFailure()
        {


            return RedirectToAction("Get", "MovieBooking");
        }
    }
}
