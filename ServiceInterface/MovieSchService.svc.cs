using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using MovieBooking.BLL.Entities;
using System.Collections.Generic;

/* -----------------------------------------------------------------
 * REVISION HISTORY
 * -----------------------------------------------------------------
 * DATE           AUTHOR          REVISION		DESCRIPTION
 * 20 May 2012    Sujatha I     0.1			Intial version
 * 													
 * 																									
 * 													
 * 
 */

namespace MovieBooking.SI.Web
{
    public class MovieSchService : IMovieScheduleService
    {
        public IEnumerable<MovieSchedule> GetMovies()
        {
            List<MovieSchedule> Movies = new List<MovieSchedule>();
            MovieRepository Movrep = new MovieRepository();
            IEnumerable<MovieBooking.BLL.Entities.Movie> MovieEntity = Movrep.FindAll();
            foreach(MovieBooking.BLL.Entities.Movie movie in MovieEntity)
            {
                MovieSchedule Mov = new MovieSchedule();
                Mov.MovieName = movie.MovieName;
                Mov.Description = movie.Description;
                Mov.CastDescription = movie.CastDescription;
                Mov.Active = movie.Active;
                Mov.genre = movie.genre;
                Mov.LanguageID = movie.LanguageID;
                Movies.Add(Mov);
            }
            return Movies;
        }
       
    }
}
