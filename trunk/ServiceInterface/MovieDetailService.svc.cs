using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;

namespace MovieBooking.SI.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MovieDetailService" in code, svc and config file together.
    public class MovieDetailService : IMovieDetService
    {
        public Movie GetMovieDetails(int Id)
        {
            Movie MovDet = new Movie();
            MovieRepository ptRep = new MovieRepository();
            MovieBooking.BLL.Entities.Movie MovDetail = ptRep.FindbyId(Id) as MovieBooking.BLL.Entities.Movie;
            MovDet.Active = MovDetail.Active;
            MovDet.CastDescription = MovDetail.CastDescription;
            MovDet.Description = MovDetail.Description;
            MovDet.genre = MovDetail.genre;
            MovDet.ID = MovDetail.ID;
            MovDet.LanguageID = MovDetail.LanguageID;
            MovDet.MovieName = MovDetail.MovieName;
            MovDet.RatingID = MovDetail.RatingID;
            MovDet.RunningDuration = MovDetail.RunningDuration;
            MovDet.trailer_url = MovDet.trailer_url;
            MovDet.ImageMoviePath = MovDet.ImageMoviePath;
            return MovDet;
        }
    }
}
