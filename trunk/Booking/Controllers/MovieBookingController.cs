using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;

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

    }
}
