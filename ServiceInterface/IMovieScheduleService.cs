using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MovieBooking.BLL.Entities;

namespace MovieBooking.SI.Web
{
    [ServiceContract]
    public interface IMovieScheduleService
    {
        [OperationContract]
        IEnumerable<MovieSchedule> GetMovies();
    }

  
    public class MovieSchedule : MovieBooking.BLL.Entities.Movie
    {
    }
}
