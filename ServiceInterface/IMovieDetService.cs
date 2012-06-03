using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using MovieBooking.BLL.Entities;
using System.Runtime.Serialization;

namespace MovieBooking.SI.Web
{
    [ServiceContract]
    public interface IMovieDetService
    {
        [OperationContract]
        Movie GetMovieDetails(int ID);

    }

    [DataContract]
    public class Movie : MovieBooking.BLL.Entities.Movie
    {
        
    }
}
