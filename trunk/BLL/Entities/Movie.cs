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
namespace MovieBooking.BLL.Entities
{
    public partial class Movie : mb_Movie
    {
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
            mb_Movie_Item = MovieDet.mb_Movie_Item;
            mb_MovieSchedule = MovieDet.mb_MovieSchedule;
            
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

        }
    }
    public class MovieRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public MovieRepository()
        {
            cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
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

        public mb_Movie FindbyId(int Id)
        {
            try
            {
                mb_Movie th = new mb_Movie();
                using (IRepository<mb_Movie> mbRep = new MovieBookingRepository<mb_Movie>())
                {
                    th = mbRep.Single(u => u.ID == Id) as mb_Movie;
                }
                return th;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving Movie " + ex.Message);
            }
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

        public bool Delete()
        {
            throw new NotImplementedException();
        }
    }
}
