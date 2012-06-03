using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MovieBooking.BLL.Entities;

namespace MovieBooking.SvcLib
{
    [ServiceContract]
    public interface IMovieScheduleService
    {
        IEnumerable<Movie> GetMovies();
    }
    public class Movie : MovieBooking.BLL.Entities.Movie
    {
    }
}
