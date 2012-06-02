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
    public partial class Movie_Item: mb_Movie_Item
    {
       public int ID { get; set; }
        public Movie_Item()
        {
        }
        public Movie_Item(mb_Movie_Item MovieDet)
        {
            ID = MovieDet.ID;
            CastID = MovieDet.CastID;
            Description = MovieDet.Description;
            CastName = MovieDet.CastName;
            MovieID = MovieDet.MovieID;
                      
        }
        public void CopyTo(mb_Movie_Item mbTh)
        {
            mbTh.ID = ID;
            mbTh.MovieID = MovieID;
            mbTh.CastID = CastID;
            mbTh.CastName = CastName;
            mbTh.Description = Description;
        }
    }
    public class MovieItemRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public MovieItemRepository()
        {
            cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public IEnumerable<Movie_Item> FindAll()
        {
            IList<Movie_Item> _movies = null;
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                var ts = from t in mbRep.FetchAll()
                         select new Movie_Item(t);
                _movies = ts.ToList<Movie_Item>();
            }
            return _movies.AsEnumerable<Movie_Item>();
        }

        public Movie_Item FindbyId(int Id)
        {
            mb_Movie_Item th = new mb_Movie_Item();
            Movie_Item movItem;
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                th = mbRep.Single(u => u.ID == Id) as mb_Movie_Item;
            }
            movItem = new Movie_Item(th);
            return movItem;
        }

        public int FindbyIdCast(int Id,string Cast)
        {
            mb_Movie_Item th = new mb_Movie_Item();
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                th = mbRep.Single(u => u.MovieID == Id && u.CastID == Cast) as mb_Movie_Item;
            }
            return th.ID;
        }

        public int Insert(Movie_Item movie)
        {
            mb_Movie_Item th = new mb_Movie_Item();
            movie.CopyTo(th);
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                mbRep.Add(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public int Update(Movie_Item movie)
        {
            mb_Movie_Item th = new mb_Movie_Item();
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_Movie_Item;
                movie.CopyTo(th);
                mbRep.SaveChanges();
            }
            return th.ID;
        }

        public bool Delete(Movie_Item movie)
        {
            mb_Movie_Item th = new mb_Movie_Item();
            using (IRepository<mb_Movie_Item> mbRep = new MovieBookingRepository<mb_Movie_Item>())
            {
                th = mbRep.First(u => u.ID == movie.ID) as mb_Movie_Item;
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
    }
}
