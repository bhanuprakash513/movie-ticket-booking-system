using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieBooking.BLL.Entities;
using MovieBooking.Model.Entities;

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
            return RedirectToAction("SearchResults");
        }


        public ActionResult SearchResults()
        {
           List<MovieSchedule> scheduleList = TempData["scheduleList"] as List<MovieSchedule>;
           mb_Movie movie = TempData["movie"] as mb_Movie;
           Theatre theatre = TempData["theatre"] as Theatre;
            if ( scheduleList != null && movie != null && theatre !=null)
            {
                ViewBag.movie = movie;
                ViewBag.theatre = theatre;
                ViewBag.scheduleList = scheduleList;
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


        public ActionResult SelectSeats(string id)
        {
            TempData["schedule_id"] = id;
            return View();
        }

        [HttpPost]
        public String SelectSeats()
        {
            String schedule_id = TempData["schedule_id"].ToString();
            String total_seats = Request["selected-total"];
            int selected_num_seats = 0;
            if (total_seats != null)
            {
                selected_num_seats = Int32.Parse(total_seats);
            }

            List<string> selected_seats = new List<string>();
            for (int i = 0; i < selected_num_seats; i++)
            {
                String seat = Request["seats[" + i + "]"];
                selected_seats.Add(seat);
            }

            return selected_seats.ToString();
            //return View();
        }

    }
}
