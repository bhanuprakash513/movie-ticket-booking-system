using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;

namespace MovieBooking.BLL.Entities
{
    public partial class MovieSchedule : mb_MovieSchedule
    {
        public List<MovieSchedule_Item> items;
        public Hall hall;
        public MovieSchedule()
    {
    }
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
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;
        public MovieScheduleRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
        //    exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public IEnumerable<MovieSchedule> FindAll()
        {
            IList<MovieSchedule> _movies = null;
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var ts = from t in mbRep.FetchAll()
                         select new MovieSchedule(t);
                _movies = ts.ToList<MovieSchedule>();
            }
            return _movies.AsEnumerable<MovieSchedule>();
        }
        public bool FindbyValues(int MovID, int TheaID, int HalID, DateTime SchDate)
        {
            bool ret = true;
            IList<MovieSchedule> _movies = null;
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                var th = from t in mbRep.FetchAll().Where(u => u.MovieID == MovID && u.TheatreID == TheaID && u.HallID == HalID && u.ScheduleDate == SchDate)
                select new MovieSchedule(t);
                _movies = th.ToList<MovieSchedule>();
            }
            if (_movies.Count == 0)
            {
                ret=false;
            }
            return ret;
        }
        public MovieSchedule FindbyId(int Id)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            MovieSchedule movSch;
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.Single(u => u.ID == Id) as mb_MovieSchedule;
            }
            movSch = new MovieSchedule(th);
            return movSch;
        }
        public MovieSchedule FindMovieschedule(int MovieID, int TheatreID, int HallID, DateTime schDate)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            MovieSchedule movSch;
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.Single(u => u.MovieID == MovieID && u.TheatreID == TheatreID && u.HallID == HallID && u.ScheduleDate == schDate) as mb_MovieSchedule;
            }
            movSch = new MovieSchedule(th);
            return movSch;
        }

        public int FindScheduleId(int MovieID, int TheatreID, int HallID, DateTime Schdate)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.Single(u => u.MovieID == MovieID && u.TheatreID == TheatreID && u.HallID == HallID && u.ScheduleDate == Schdate) as mb_MovieSchedule;
            }
            return th.ID;
        }
        public int FindbyMovieID(int ID)
        {

            mb_MovieSchedule th = new mb_MovieSchedule();
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.Single(u => u.MovieID == ID) as mb_MovieSchedule;
            }
            return th.ID;
        }

        public int Insert(MovieSchedule movie)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            movie.CopyTo(th);
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                mbRep.Add(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public int Update(MovieSchedule movie)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_MovieSchedule;
                movie.CopyTo(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public bool Delete(MovieSchedule movie)
        {
            mb_MovieSchedule th = new mb_MovieSchedule();
            using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_MovieSchedule;
                if (th != null)
                {
                    movie.CopyTo(th);
                    mbRep.Delete(th);
                    mbRep.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public List<MovieSchedule> GetScheduleForMovie(Movie movie)
        {
            List<MovieSchedule> schedules = null;
            try
            {
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
            catch (Exception ex)
            {
                throw new Exception("Error occured while retrieving schedule for movie " + ex.Message);
            }
        }

        public List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id)
        {
            List<MovieSchedule> schedules = null;
            try
            {
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
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting schedule for movie " + ex.Message);
            }
        }

        public List<MovieSchedule> GetScheduleForMovie(int movie_id, int theatre_id, DateTime date)
        {
            List<MovieSchedule> schedules = null;

            try
            {
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
                        schedule.hall = hallRepo.GetHall(schedule.HallID);
                    }
                }
                return schedules;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting schedule for Movie " + ex.Message);
            }
        }

        public MovieSchedule GetSchedule(int id)
        {
            MovieSchedule schedule = null;
            try
            {
                using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
                {
                    var ts = from t in mbRep.FetchAll().Where(c => c.ID.Equals(id))
                             select new MovieSchedule(t);
                    schedule = ts.FirstOrDefault();
                }
                return schedule;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie schedule " + ex.Message);
            }
        }

        //Start: Added 23-Jun-2012 for services
        public List<MovieSchedule> GetMovieScheduleListByDate(DateTime dt)
        {
            List<MovieSchedule> movieScheduleList = null;

            try
            {
                using (IRepository<mb_MovieSchedule> mbRep = new MovieBookingRepository<mb_MovieSchedule>())
                {
                    var ts = from t in mbRep.FetchAll().Where(b => b.ScheduleDate == dt)
                             select new MovieSchedule(t);
                    movieScheduleList = ts.ToList();

                    MovieScheduleItemRepository itemRepo = new MovieScheduleItemRepository();

                    foreach (MovieSchedule schedule in movieScheduleList)
                    {
                        List<MovieSchedule_Item> scheduleItems = itemRepo.GetMovieScheduleItem(schedule);
                        schedule.items = scheduleItems;
                    }
                }
                return movieScheduleList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving Movie Schedule " + ex.Message);
            }
        }

        public MovieSchedule GetMovieScheduleBySchItemId(int schItemId)
        {
            MovieSchedule ms = null;
            MovieSchedule_Item msi = null;

            try
            {
                using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
                {
                    var s = mbRep.First(p => p.ID == schItemId);
                    msi = new MovieSchedule_Item(s);

                    if (msi != null)
                    {
                        using (IRepository<mb_MovieSchedule> mbRep2 = new MovieBookingRepository<mb_MovieSchedule>())
                        {
                            var si = mbRep2.Single(p => p.ID == msi.MovieScheduleID);
                            ms = new MovieSchedule(si);
                        }

                        if (ms != null)
                        {
                            ms.items.Add(msi);
                        }
                    }
                }

                return ms;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving Movie Schedule " + ex.Message);
            }
        }
        //End: Added 23-Jun-2012 for services
    }



}
