using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.DAL;
using MovieBooking.Model.Entities;
using MovieBooking.DLL.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace MovieBooking.BLL.Entities
{
    public partial class Hall : mb_Hall
    {
        public Hall(mb_Hall _hall)
        {
            ID = _hall.ID;
            TheatreID = _hall.TheatreID;
            HallName = _hall.HallName;
            TotalSeats = _hall.TotalSeats;
            Active = _hall.Active;
       }

        public void CopyTo(mb_Hall mbHall)
        {
            mbHall.ID = this.ID;
            mbHall.TheatreID = this.TheatreID;
            mbHall.HallName = this.HallName;
            mbHall.TotalSeats = this.TotalSeats;
            mbHall.Active = this.Active;
        }

        public Hall() { }
    }

    public interface IHallRepository
    {
        Hall GetHall(int hallId);

    }


    public class HallRepository : IHallRepository
    {
        private IRepository<mb_Hall> context;
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public HallRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            //exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public Hall GetHall(int hallId)
        {
            Hall hall = null;
            using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.ID.Equals(hallId))
                         select new Hall(t);
                hall = ts.FirstOrDefault();
            }
            return hall;
        }

    }
}
