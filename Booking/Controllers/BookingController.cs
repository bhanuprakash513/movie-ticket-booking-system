using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBooking.MVC.UI.Controllers
{
    public class BookingController : Controller
    {
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}
