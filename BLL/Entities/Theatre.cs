using System;
using System.Collections.Generic;
using MovieBooking.DAL;
using MovieBooking.Model.Entities;

namespace MovieBooking.BLL.Entities
{

    public interface ITheatre : IDisposable
    {
        IEnumerable<mb_Theatre> GetTheatre();
        bool InsertTheatre();
        bool UpdateTheatre();
        bool DeleteTheatre();
    }

    public class Theatre : mb_Theatre, ITheatre, IDisposable
    {
        private MovieBookingEntitiesContext context = null;

        #region dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region ITheatre Members

        public IEnumerable<mb_Theatre> GetTheatre()
        {
            throw new NotImplementedException();
        }

        public bool InsertTheatre()
        {
            //throw new NotImplementedException();
            context = new MovieBookingEntitiesContext();
            context.mb_Theatre.AddObject(new mb_Theatre()
            {
                Name = this.Name,
                Address = this.Address,
                Email = this.Email,
                FaxNo = this.FaxNo,
                PhoneNo = this.PhoneNo,
                PostalCode = this.PostalCode,
                WebSite = this.WebSite
            });
            
            return (context.SaveChanges()==1);
        }

        public bool UpdateTheatre()
        {
            throw new NotImplementedException();
            
        }

        public bool DeleteTheatre()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
