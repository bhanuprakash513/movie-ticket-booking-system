using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;

namespace MovieBooking.BLL.Entities
{
    public partial class MovieSchedule : mb_MovieSchedule
    {
        public List<MovieSchedule_Item> items;
        public Hall hall;
        public MovieSchedule(mb_MovieSchedule _mb_schedule)
        {
            ID = _mb_schedule.ID;
            MovieID = _mb_schedule.MovieID;
            TheatreID = _mb_schedule.TheatreID;
            HallID = _mb_schedule.HallID;
            ScheduleDate = _mb_schedule.ScheduleDate;
            Price = _mb_schedule.Price;
            Active = _mb_schedule.Active;

            items = new List<MovieSchedule_Item>();
            hall = new Hall();
           
        }

        public void CopyTo(mb_MovieSchedule _schedule)
        {
            _schedule.ID = this.ID;
            _schedule.HallID = this.HallID;
            _schedule.Active = this.Active;
            _schedule.MovieID = this.MovieID;
            _schedule.Price = this.Price;
            _schedule.ScheduleDate = this.ScheduleDate;
            _schedule.TheatreID = this.TheatreID;
        }
    }

    public interface IMovieScheduleRepository
    {
       List<MovieSchedule> GetScheduleForMovie(Movie movie);
       List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id);
       List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id,DateTime date);
       MovieSchedule GetSchedule(int Id);
       //MovieSchedule GetScheduleForDate(DateTime date);
    }



    public class MovieScheduleRepository : IMovieScheduleRepository
    {
        public MovieScheduleRepository()
        {

        }

        public List<MovieSchedule> GetScheduleForMovie(Movie movie)
        {
            List<MovieSchedule> schedules = null;

            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.MovieID.Equals(movie.ID))
                         select new MovieSchedule(t);
                schedules = ts.ToList();
                MovieScheduleItemRepository itemRepo = new MovieScheduleItemRepository();

                foreach (MovieSchedule schedule in schedules)
                {
                    schedule.items = itemRepo.GetMovieScheduleItem(schedule);
                }
            }

            return schedules;
        }

        public List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id)
        {
            List<MovieSchedule> schedules = null;

            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.MovieID.Equals(movie_id) && c.TheatreID.Equals(theatre_id))
                         select new MovieSchedule(t);
                schedules = ts.ToList();
                MovieScheduleItemRepository itemRepo = new MovieScheduleItemRepository();

                foreach (MovieSchedule schedule in schedules)
                {
                    schedule.items = itemRepo.GetMovieScheduleItem(schedule);
                }
            }

            return schedules;
        }

        public List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id, DateTime date)
        {
            List<MovieSchedule> schedules = null;
            

            if (date < DateTime.Now)
            {
                return schedules;
            }
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.MovieID.Equals(movie_id) && c.TheatreID.Equals(theatre_id) && c.ScheduleDate.Equals(date))
                         select new MovieSchedule(t);
                schedules = ts.ToList();
                MovieScheduleItemRepository itemRepo = new MovieScheduleItemRepository();
                HallRepository hallRepo = new HallRepository();

                foreach (MovieSchedule schedule in schedules)
                {
                    schedule.items = itemRepo.GetMovieScheduleItem(schedule);
                    schedule.hall = hallRepo.GetHall(Int32.Parse(schedule.HallID));
                }
            }
            return schedules;
        }

        public MovieSchedule GetSchedule(int id)
        {
            MovieSchedule schedule = null;
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.ID.Equals(id))
                         select new MovieSchedule(t);
                schedule = ts.FirstOrDefault();
            }
            return schedule;
        }
    }



}
