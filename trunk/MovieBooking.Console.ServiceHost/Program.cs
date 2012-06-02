using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MovieBooking.SvcLib;

/* -----------------------------------------------------------------
 * REVISION HISTORY
 * -----------------------------------------------------------------
 * DATE           AUTHOR          REVISION		DESCRIPTION
 * 20 May 2012    Mansoor M I     0.1			Intial version
 * 													
 * 																									
 * 													
 * 
 */

namespace MovieBooking.Console.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
           
            // Global variable to store the ExceptionManager instance. 
            ExceptionManager exManager;
            ICacheManager cache = null;

            cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
            
            try
            {
                System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(PaymentService));
                host.Open();
                System.Console.WriteLine(host.Description.Endpoints[1].Address.ToString());
                System.Console.WriteLine("\n\nThe above service(s) are running...Press <ENTER> to stop the service(s)...");
                System.Console.ReadLine();
                host.Close();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                System.Console.ReadLine();
            }

        }
    }
}
