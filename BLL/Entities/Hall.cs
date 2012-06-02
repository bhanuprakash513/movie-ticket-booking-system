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
using System.Runtime.Serialization;

namespace MovieBooking.BLL.Entities
{
    [DataContract]
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

        public IEnumerable<Hall> FindByTheatreId(int theatreId)
        {
            IList<Hall> _halls = null;
            using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
            {
                var ts = from t in mbRep.Find(h => h.TheatreID == theatreId)
                         select new Hall(t);
                _halls = ts.ToList<Hall>();
            }
            return _halls.AsEnumerable<Hall>();
        }

        public Hall FindById(int id)
        {
            Hall _hall = null;
            try
            {
                using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
                {
                    //var mbHall = mbRep.First(u => u.ID == id && u.Active == true);
                    var mbHall = mbRep.First(u => u.ID == id);
                    _hall = new Hall(mbHall);
                }
            }
            catch (Exception ex)
            {
                exManager.HandleException(ex, "MovieBookingExceptionType");
                throw ex;
            }

            return _hall as Hall;
        }

        public IEnumerable<Hall> FindAll(int id)
        {
            IList<Hall> _hall = null;
            using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.TheatreID.Equals(id))
                         select new Hall(t);
                _hall = ts.ToList<Hall>();
            }
            return _hall.AsEnumerable<Hall>();

        }

        public Hall GetHall(Int32 hallId)
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
        public int Insert(Hall hall)
        {
            mb_Hall ha = new mb_Hall();
            hall.CopyTo(ha);
            using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
            {
                mbRep.Add(ha);
                mbRep.SaveChanges();
            }
            return ha.ID;
        }

        public int Update(Hall hall)
        {
            mb_Hall ha = new mb_Hall();
            using (IRepository<mb_Hall> mbRep = new MovieBookingRepository<mb_Hall>())
            {
                ha = mbRep.First(u => u.ID == hall.ID) as mb_Hall;
                hall.CopyTo(ha);
                mbRep.SaveChanges();
            }
            return ha.ID;
        }
    }
}
