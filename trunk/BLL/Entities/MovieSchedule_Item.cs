using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;

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

    }

    public interface IMovieSchedule_ItemRepository
    {
        List<MovieSchedule_Item> GetMovieScheduleItem(MovieSchedule schedule);
    }

    public class MovieScheduleItemRepository : IMovieSchedule_ItemRepository
    {

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
    }
}
