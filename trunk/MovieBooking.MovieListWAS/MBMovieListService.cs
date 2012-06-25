using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace MovieBooking.MovieListWAS
{
    public partial class MBMovieListService : ServiceBase
    {
        ServiceHost svcHost = null;

        public MBMovieListService()
        {
            //InitializeComponent();
            ServiceName = "MBMovieListService";
        }

        protected override void OnStart(string[] args)
        {
            if (svcHost != null)
            {
                svcHost.Close();
            }

            svcHost = new ServiceHost(typeof(MovieListService));

            svcHost.Open();

        }

        protected override void OnStop()
        {
            if (svcHost != null)
            {
                svcHost.Close();
                svcHost = null;
            }
        }
    }
}
