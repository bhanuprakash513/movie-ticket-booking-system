using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;
using MovieBooking.Model.Entities;
using System.Web.Security;
using MovieBooking.MVC.UI.Models;

namespace MovieBooking.MVC.UI.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /MovieControlller/

        public ActionResult Index()
        {
            
            List<Movie> movies = new List<Movie>();
        

            ViewBag.movies = movies;
            return View(movies);
        }

        public ActionResult Welcome(String name, int numTimes)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();

        }

        [HttpGet]
        public ActionResult Search()
        {
            //Get Theatre list and set it in ViewBag
            TheatreRepository theatreRepo = new TheatreRepository();
            IEnumerable<Theatre> theatreList = theatreRepo.FindAll();
           

            List<SelectListItem> theatreListSelect = new List<SelectListItem>();
            foreach (Theatre th in theatreList)
            {
                theatreListSelect.Add(new SelectListItem()
                {
                    Value = th.ID.ToString(),
                    Text = th.Name,
                });
            }
            ViewBag.theatreList = theatreListSelect;

            //Get Movie list and set it in ViewBag
            MovieRepository movieRepo = new MovieRepository();
            IEnumerable<Movie> movieList = movieRepo.FindAll();
            List<SelectListItem> movieListSelect = new List<SelectListItem>();
            foreach (Movie _movie in movieList)
            {
                movieListSelect.Add(new SelectListItem()
                {
                    Value = _movie.ID.ToString(),
                    Text = _movie.MovieName,
                });
            }
            ViewBag.movieList = movieListSelect;


            return View();
        }

        [HttpPost]
        public ActionResult Search(String theatre_select, String movie_select , String day_select)
        {
            MovieScheduleRepository scheduleRepo = new MovieScheduleRepository();
            MovieRepository movieRepo = new MovieRepository();
            TheatreRepository theatreRepo = new TheatreRepository();
            List<MovieSchedule> schedules =  scheduleRepo.GetScheduleForMovie(int.Parse(theatre_select), int.Parse(movie_select), DateTime.Parse(day_select));
          
            //return theatre_select + "  " + movie_select + "  " + day_select;
            //ViewBag.scheduleList = schedules;
            mb_Movie movie = movieRepo.FindbyId(Int32.Parse(movie_select));
            Theatre theatre = theatreRepo.FindById(Int32.Parse(theatre_select));
            
            TempData["scheduleList"] = schedules;
            TempData["theatre"] = theatre;
            TempData["movie"] = movie;
            TempData["day_select"] = day_select;
            return RedirectToAction("SearchResults");
        }


        public ActionResult SearchResults()
        {
           List<MovieSchedule> scheduleList = TempData["scheduleList"] as List<MovieSchedule>;
           mb_Movie movie = TempData["movie"] as mb_Movie;
           Theatre theatre = TempData["theatre"] as Theatre;
           string day_select = TempData["day_select"].ToString();
           if (movie != null && theatre != null)
           {
               ViewBag.movie = movie;
               ViewBag.theatre = theatre;
           }

            if ( scheduleList != null && movie != null && theatre !=null)
            {
                ViewBag.movie = movie;
                ViewBag.theatre = theatre;
                ViewBag.scheduleList = scheduleList;
                ViewBag.day_select = day_select;
                Dictionary<string, List<MovieSchedule>> schedulesByHall = new Dictionary<string, List<MovieSchedule>>();
                    
            foreach (MovieSchedule schedule in scheduleList)
            {
                string hallName = schedule.hall.HallName;
                if (schedulesByHall.ContainsKey(hallName))
                {
                    schedulesByHall[hallName].Add(schedule);
                }
                else
                {
                    schedulesByHall[hallName] = new List<MovieSchedule>();
                    schedulesByHall[hallName].Add(schedule);
                }
            }
            ViewBag.schedulesByHall = schedulesByHall;
            }

           
            // ...
            return View();
        }


        public ActionResult SelectSeats(string id, string date)
        {
            TempData["schedule_id"] = id;
            ViewBag.schedule_id = id;
            TempData["day_select"] = date;
            ViewBag.day_select = date;
            BookingRepository repo = new BookingRepository();
            List<BookingItem> items = repo.GetMovieBookingsForSchedule(Int32.Parse(id));
            ViewBag.selected_seats = items;
            return View();
        }

        [HttpPost]
        public ActionResult SelectSeats(PaymentModel model)
        {
            if (ModelState.IsValid)
            {
                int schedule_id = Int32.Parse(Request["schedule_id"].ToString());
                String total_seats = Request["selected-total"];
                DateTime day_select = DateTime.Parse(Request["day_select"].ToString());
                int selected_num_seats = 0;
                if (total_seats != null)
                {
                    selected_num_seats = Int32.Parse(total_seats);
                }

                if (selected_num_seats > 0)
                {

                    List<string> selected_seats = new List<string>();
                    for (int i = 0; i < selected_num_seats; i++)
                    {
                        String seat = Request["seats[" + i + "]"];
                        selected_seats.Add(seat);
                    }

                    string creditCardNum = model.CreditCardNum.ToString();
                    string creditCardExpiry = model.CreditCardExpiry.ToString();
                    string nameAsInCard = model.CreditCardName.ToString();
                    string cvv = model.CVV.ToString();
                    //string totalPayment = Request["total-price"].ToString();
                    string total = Request["selected-total"].ToString();
                    string price = Request["price-per-ticket"].ToString();

                    string gst = "7.00";

                    Payment payment = new Payment();
                    payment.PaymentModeID = "CreditCard"; // Can not be more than 10 characters
                    payment.CreditCardNo = creditCardNum;
                    payment.CardExpiry = creditCardExpiry;
                    payment.CardHolderName = nameAsInCard;
                    payment.PaymentDate = DateTime.Now;
                    payment.TotalAmount = Decimal.Parse(total) * Decimal.Parse(price);
                    payment.GSTPercent = float.Parse(gst);
                    payment.PaymentModeID = "01"; //VISA
                    payment.CCV = cvv;


                    BookingRepository bookingRepo = new BookingRepository();
                    RegisteredUserRepository repo3 = new RegisteredUserRepository();
                    MembershipUser _user = Membership.GetUser(true);

                    
                    if (_user == null)
                    {
                        // For non-members user id would be set as user2
                        _user = Membership.GetUser("user2"); // Non member
                    }

                    RegisteredUser user = repo3.FindById(new Guid(_user.ProviderUserKey.ToString()));
                    Booking booking = bookingRepo.CreateBooking(schedule_id, selected_seats, user);

                    if (booking != null)
                    {
                        if (booking.ID > 0)
                        {
                            PaymentRepository paymentRepo = new PaymentRepository();
                            payment.MovieBookingID = booking.ID;

                            // Call payment Repository directly. Use this if the service is not available
                            ////int _status = paymentRepo.Insert(payment);
                            //booking.payment = paymentRepo.FindById(_status);

                            //Tests to consume net.Tcp binding services                            
                            using (Payment_Service.PaymentServiceClient client = new Payment_Service.PaymentServiceClient())
                            {
                                Payment_Service.Payment pay = new Payment_Service.Payment();

                                pay.CardExpiry = payment.CardExpiry;
                                pay.CardHolderName = payment.CardHolderName;
                                pay.CCV = payment.CCV;
                                pay.CreditCardNo = payment.CreditCardNo;
                                pay.GSTPercent = payment.GSTPercent;
                                pay.MovieBookingID = payment.MovieBookingID;
                                pay.PaymentDate = payment.PaymentDate;
                                pay.PaymentModeID = payment.PaymentModeID;
                                pay.TotalAmount = payment.TotalAmount;
                                int id = client.Insert(pay);
                                //Save the transaction if the payment is successfull.
                                if (id > 0)
                                {
                                    booking.payment = paymentRepo.FindById(id);
                                }
                            }                          

                        }
                         
                    }

                    TempData["booking"] = booking;
                    return RedirectToAction("PrintTicket");
                }
            }
            else
            {
                //TempData["schedule_id"] = id;
                //TempData["day_select"] = date;
                //ViewBag.day_select = date;
                int schedule_id = Int32.Parse(Request["schedule_id"].ToString());
                ViewBag.schedule_id = schedule_id;
                string date = Request["day_select"].ToString();
                ViewBag.day_select = date;

                

                BookingRepository repo = new BookingRepository();
                List<BookingItem> items = repo.GetMovieBookingsForSchedule(schedule_id);
                ViewBag.selected_seats = items;

            }

            return View(model);
            //return selected_seats.ToString() + " " + creditCardNum.ToString() + " " + creditCardExpiry + " " + nameAsInCard + " " +
            //       cvv + " " + day_select + schedule_id;
            //return View();
        }

        public ActionResult PrintTicket()
        {
            Booking booking = TempData["booking"] as Booking;
            if(booking != null){
                ViewBag.booking = booking;

                MovieScheduleItemRepository scheduleItemRepo = new MovieScheduleItemRepository();
                MovieSchedule_Item item =  scheduleItemRepo.GetMovieScheduleItem(Int32.Parse(booking.ScheduleID.ToString()));

                if (item != null)
                {
                    MovieScheduleRepository scheduleRepo = new MovieScheduleRepository();
                    MovieSchedule schedule = scheduleRepo.GetSchedule(Int32.Parse(item.MovieScheduleID.ToString()));

                    if (schedule != null)
                    {

                        ViewBag.movie = null;
                        ViewBag.theatre = null;
                        ViewBag.hall = null;
                        ViewBag.seats = null;

                        MovieRepository movieRepo = new MovieRepository();
                        mb_Movie movie = movieRepo.FindbyId(Int32.Parse(schedule.MovieID.ToString()));

                        if (movie != null)
                        {
                            ViewBag.movie = movie;
                        }

                        TheatreRepository theatreRepo = new TheatreRepository();
                        mb_Theatre theatre = theatreRepo.FindById(Int32.Parse(schedule.TheatreID.ToString()));

                        if (theatre != null)
                        {
                            ViewBag.theatre = theatre;
                        }

                        HallRepository hallRepo = new HallRepository();
                        mb_Hall hall = hallRepo.GetHall(schedule.HallID);

                        if (theatre != null)
                        {
                            ViewBag.hall = hall;
                        }

                        if (booking.bookingItems != null)
                        {
                            ViewBag.seats = booking.bookingItems;
                        }
                    }

                }
                return View();
            }
            return View();
        }

    }
}
