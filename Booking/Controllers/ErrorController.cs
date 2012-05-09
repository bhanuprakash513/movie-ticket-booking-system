using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace MovieBooking.MVC.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            {
                var exception = Server.GetLastError();
                ExceptionManager exManager;
                exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
                exManager.HandleException(exception, "MovieBookingExceptionType");
                // etc..
            }

            return View();
        }

        public ActionResult ThrowError()
        {
            return View();
            //throw new NotImplementedException("NotImplementedEx!");
        }

    }
        
}
