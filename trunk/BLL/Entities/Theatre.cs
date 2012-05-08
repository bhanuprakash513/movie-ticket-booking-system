using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Transactions;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using MovieBooking.DAL;
using MovieBooking.Model.Entities;

namespace MovieBooking.BLL.Entities
{

    public partial class Theatre : mb_Theatre
    {
    }

    //public class TheatreRepository : MBRepository<Theatre>, IDisposable
    //{
    //    private MovieBookingEntitiesContext context = null;

    //    #region dispose
    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                context.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //    #endregion

    //    public override IEnumerable<Theatre> FindAll()
    //    {
    //        var theatres = from t in context.mb_Theatre
    //                    select new Theatre() { 
    //                        Address = t.Address, Email = t.Email, FaxNo = t.FaxNo, Name = t.Name,
    //                        PhoneNo = t.PhoneNo, PostalCode = t.PostalCode, ID = t.ID, WebSite = t.WebSite,
    //                        mb_MovieSchedule = t.mb_MovieSchedule
    //                      };
    //        return theatres.ToList();
    //    }

    //    public bool InsertTheatre()
    //    {
    //        //throw new NotImplementedException();
    //        context = new MovieBookingEntitiesContext();
    //        context.mb_Theatre.AddObject(new mb_Theatre()
    //        {
    //            Name = this.Name,
    //            Address = this.Address,
    //            Email = this.Email,
    //            FaxNo = this.FaxNo,
    //            PhoneNo = this.PhoneNo,
    //            PostalCode = this.PostalCode,
    //            WebSite = this.WebSite
    //        });
            
    //        return (context.SaveChanges()==1);
    //    }

    //    public bool UpdateTheatre()
    //    {
    //        throw new NotImplementedException();
            
    //    }

    //    public bool DeleteTheatre()
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}
