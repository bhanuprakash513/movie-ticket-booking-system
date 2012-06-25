using System;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;
using MovieBooking.DAL;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Runtime.Serialization;
namespace MovieBooking.BLL.Entities
{
    [DataContract]
    public partial class Movie : mb_Movie
    {
        [DataMember]
        public int ID { get; set; }
    

        public Movie()
        {
        }
        public Movie(mb_Movie MovieDet)
        {
            ID = MovieDet.ID;
            MovieName = MovieDet.MovieName;
            LanguageID = MovieDet.LanguageID;
            Description = MovieDet.Description;
            RatingID = MovieDet.RatingID;
            RunningDuration = MovieDet.RunningDuration;
            genre = MovieDet.genre;
            Active = MovieDet.Active;
            CastDescription = MovieDet.CastDescription;
            //mb_Movie_Item = new mb_Movie_Item();


            //mb_Movie_Item = MovieDet.mb_Movie_Item;
            //mb_MovieSchedule = MovieDet.mb_MovieSchedule;
            ImageMoviePath = MovieDet.ImageMoviePath;
            //trailer_url = MovieDet.trailer_url;
            
        }
        public void CopyTo(mb_Movie mbTh)
        {
            mbTh.ID = ID;
            mbTh.MovieName = MovieName;
            mbTh.LanguageID = LanguageID;
            mbTh.Description = Description;
            mbTh.RatingID = RatingID;
            mbTh.RunningDuration = RunningDuration;
            mbTh.Active = Active;
            mbTh.genre = genre;
            mbTh.CastDescription = CastDescription;
            mbTh.ImageMoviePath = ImageMoviePath;
            //mbTh.trailer_url = trailer_url;

        }
    }
    public class MovieRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public MovieRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            //// Resolve the default ExceptionManager object from the container.
            //exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public IEnumerable<Movie> FindAll()
        {
            try
            {
                IList<Movie> _movies = null;
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    var ts = from t in mbRep.FetchAll()
                             select new Movie(t);
                    _movies = ts.ToList<Movie>();
                }
                return _movies.AsEnumerable<Movie>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving Movie " + ex.Message);
            }
        }

        public Movie FindbyId(int Id)
        {
            try
            {
                mb_Movie th = new mb_Movie();
                Movie movie;
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    th = mbRep.Single(u => u.ID == Id) as mb_Movie;
                }
                movie = new Movie(th);
                return movie;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving Movie " + ex.Message);
            }
        }
        public int FindIdbyName(string MovieName)
        {
            int id = 0;

            mb_Movie th = new mb_Movie();
            using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
            {
                th = mbRep.Single(u => u.MovieName == MovieName) as mb_Movie;
            }
            if (th != null)
            {
                id= th.ID;
            }
            return id;
            
        }


        public int Insert(Movie movie)
        {
            try
            {
                mb_Movie th = new mb_Movie();
                movie.CopyTo(th);
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    mbRep.Add(th);
                    mbRep.SaveChanges();
                }
                return th.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while inserting new movie" + ex.Message);
            }
        }

        public int Update(Movie movie)
        {
            try
            {
                mb_Movie th = new mb_Movie();
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    th = mbRep.First(u => u.ID == movie.ID) as mb_Movie;
                    movie.CopyTo(th);
                    mbRep.SaveChanges();
                }
                return th.ID;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while updating movie" + ex.Message);
            }
        }

        public bool Delete(Movie movie)
        {
            //throw new NotImplementedException();
            mb_Movie th = new mb_Movie();
            using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_Movie;
                if (th != null)
                {
                    movie.CopyTo(th);
                    mbRep.Delete(th);
                    mbRep.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            } 
       
            

        }

        //Start: Added 23-Jun-2012 for services
        public Movie GetMovieByName(string movieName)
        {
            Movie myMovie = null;

            try
            {
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    var ts = mbRep.Single(u => u.MovieName.Equals(movieName));
                    myMovie = new Movie(ts);
                }

                return myMovie;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving movie" + ex.Message);
            }
        }
        //End: Added 23-Jun-2012 for services
    }
}
