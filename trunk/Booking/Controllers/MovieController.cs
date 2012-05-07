using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;

namespace MovieBooking.MVC.UI.Controllers
{
    public class MovieController : Controller
    {
        //
        // GET: /MovieControlller/

        public ActionResult Index()
        {
            Movie movie1 = new Movie();
            movie1.MovieName = "sssss";


            Movie movie2 = new Movie();
            movie2.MovieName = "sssss";

            Movie movie3 = new Movie();
            movie3.MovieName = "sssss";

            List<Movie> movies = new List<Movie>();
            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);

            ViewBag.movies = movies;
            return View(movies);
        }

        public ActionResult Welcome(String name, int numTimes)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;

            return View();

        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult SelectSeats()
        {
            return View();
        }

    }
}
