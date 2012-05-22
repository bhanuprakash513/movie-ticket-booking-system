using System;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;
using MovieBooking.DAL;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace MovieBooking.BLL.Entities
{

    public partial class Theatre : mb_Theatre
    {
        public int ID { get; private set; }

        #region ctor and copyTo methods

        public Theatre() { }
        public Theatre(mb_Theatre mbTh)
        {
            ID = mbTh.ID;
            Active = mbTh.Active;
            Address = mbTh.Address;
            Email = mbTh.Email;
            FaxNo = mbTh.FaxNo;
            Name = mbTh.Name;
            PhoneNo = mbTh.PhoneNo;
            PostalCode = mbTh.PostalCode;
            WebSite = mbTh.WebSite;
            mb_MovieSchedule = mbTh.mb_MovieSchedule;
        }

        public void CopyTo(mb_Theatre mbTh)
        {
            mbTh.ID = ID;
            mbTh.Active = Active;
            mbTh.Address = Address;
            mbTh.Email = Email;
            mbTh.FaxNo = FaxNo;
            mbTh.Name = Name;
            mbTh.PhoneNo = PhoneNo;
            mbTh.PostalCode = PostalCode;
            mbTh.WebSite = WebSite;
            mbTh.mb_MovieSchedule = mb_MovieSchedule;
        }

        #endregion
    }

    public class TheatreRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public TheatreRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            //exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public Theatre FindById(int id)
        {
            Theatre _theatre = null;
            try
            {
                using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
                {
                    var th = from t in mbRep.FetchAll().Where(c => c.ID.Equals(id))
                             select new Theatre(t);
                    _theatre = th.FirstOrDefault();
                }
                return _theatre;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Theatre " + ex.Message);
            }
        }

        public IEnumerable<Theatre> FindAll()
        {
            IList<Theatre> _theatres = null;
            using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
                {
                    var ts = from t in mbRep.FetchAll()
                             select new Theatre(t);
                    _theatres = ts.ToList<Theatre>();
                }
                return _theatres.AsEnumerable<Theatre>();
            
        }

        public int Insert(Theatre theatre)
        {
            mb_Theatre th = new mb_Theatre();
            try
            {
                theatre.CopyTo(th);
                using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
                {
                    mbRep.Add(th);

                    mbRep.SaveChanges();
                }
                return th.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while creating new Theatre " + ex.Message);
            }
        }

        public int Update(Theatre theatre)
        {
            mb_Theatre th = new mb_Theatre();
            try
            {
                using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
                {
                    th = mbRep.First(u => u.ID == theatre.ID) as mb_Theatre;
                    theatre.CopyTo(th);
                    mbRep.SaveChanges();
                }
                return th.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while udpdating theatre " + ex.Message);
            }
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
