using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace MovieBooking.BLL.Entities
{
    public partial class MovieSchedule_Item : mb_MovieSchedule_Item
    {
         public MovieSchedule_Item(mb_MovieSchedule_Item _mb_schedule_item)
        {
            ID = _mb_schedule_item.ID;
            MovieScheduleID = _mb_schedule_item.MovieScheduleID;
            TimeSlotID = _mb_schedule_item.TimeSlotID;
            Price = _mb_schedule_item.Price;
        }
         public void CopyTo(mb_MovieSchedule_Item mbTh)
         {
             mbTh.ID = ID;
             mbTh.MovieScheduleID = MovieScheduleID;
             mbTh.TimeSlotID = TimeSlotID;
             mbTh.Price = Price;
         }

    }

    public interface IMovieSchedule_ItemRepository
    {
        List<MovieSchedule_Item> GetMovieScheduleItem(MovieSchedule schedule);
        MovieSchedule_Item GetMovieScheduleItem(int schedule_id);
    }

    public class MovieScheduleItemRepository : IMovieSchedule_ItemRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public MovieScheduleItemRepository()
        {
            cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }
        public IEnumerable<MovieSchedule_Item> FindAll()
        {
            IList<MovieSchedule_Item> _movies = null;
            using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
            {
                var ts = from t in mbRep.FetchAll()
                         select new MovieSchedule_Item(t);
                _movies = ts.ToList<MovieSchedule_Item>();
            }
            return _movies.AsEnumerable<MovieSchedule_Item>();
        }

        public mb_MovieSchedule_Item FindbyId(int Id)
        {
            mb_MovieSchedule_Item th = new mb_MovieSchedule_Item();
            using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
            {
                th = mbRep.Single(u => u.ID == Id) as mb_MovieSchedule_Item;
            }
            return th;
        }


        public int Insert(MovieSchedule_Item movie)
        {
            mb_MovieSchedule_Item th = new mb_MovieSchedule_Item();
            movie.CopyTo(th);
            using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
            {
                mbRep.Add(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public int Update(MovieSchedule_Item movie)
        {
            mb_MovieSchedule_Item th = new mb_MovieSchedule_Item();
            using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_MovieSchedule_Item;
                movie.CopyTo(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public bool Delete(MovieSchedule_Item movie)
        {
            mb_MovieSchedule_Item th = new mb_MovieSchedule_Item();
            using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_MovieSchedule_Item;
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


        public List<MovieSchedule_Item> GetMovieScheduleItem(MovieSchedule schedule)
        {
            List<MovieSchedule_Item> items = null;
            try
            {
                using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
                {
                    var ts = from t in mbRep.FetchAll().Where(c => c.MovieScheduleID.Equals(schedule.ID))
                             select new MovieSchedule_Item(t);
                    items = ts.ToList();
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie Schedule Item " + ex.Message);
            }
        }

        public MovieSchedule_Item  GetMovieScheduleItem(int scheduleItemId)
        {
            MovieSchedule_Item item = null;
            try
            {
                using (IRepository<mb_MovieSchedule_Item> mbRep = new MovieBookingRepository<mb_MovieSchedule_Item>())
                {
                    var ts = from t in mbRep.FetchAll().Where(c => c.ID.Equals(scheduleItemId))
                             select new MovieSchedule_Item(t);
                    return ts.FirstOrDefault();
                }

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie Schedule Item " + ex.Message);
            }
        }
    }
}
