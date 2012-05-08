using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using MovieBooking.DAL;

namespace MovieBooking.DLL.Entities
{

    #region interface

    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetQuery();
        IEnumerable<T> FetchAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T Single(Expression<Func<T, bool>> predicate);
        T First(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Attach(T entity);
        bool IsValid(T entity);
        void SaveChanges();
        void SaveChanges(SaveOptions options);
    }

    #endregion

    #region implementation

    /// <summary>
    /// A MovieBookingRepository repository for working with data in the database
    /// </summary>
    /// <typeparam name="T">A POCO that represents an Entity Framework entity</typeparam>
    public class MovieBookingRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The context object for the database
        /// </summary>
        private ObjectContext _context;
 
        /// <summary>
        /// The IObjectSet that represents the current entity.
        /// </summary>
        private IObjectSet<T> _objectSet;
 
        /// <summary>
        /// Initializes a new instance of the MovieBookingRepository class
        /// </summary>
        public MovieBookingRepository()
            : this(new MovieBookingEntitiesContext())
        {
        }
 
        /// <summary>
        /// Initializes a new instance of the MovieBookingRepository class
        /// </summary>
        /// <param name="context">The Entity Framework ObjectContext</param>
        private MovieBookingRepository(ObjectContext context)
        {
            _context = context;
            _objectSet = _context.CreateObjectSet<T>();
        }
 
        /// <summary>
        /// Gets all records as an IQueryable
        /// </summary>
        /// <returns>An IQueryable object containing the results of the query</returns>
        public IQueryable<T> GetQuery()
        {
            return _objectSet;
        }
 
        /// <summary>
        /// Gets all records as an IEnumberable
        /// </summary>
        /// <returns>An IEnumberable object containing the results of the query</returns>
        public IEnumerable<T> FetchAll()
        {
            return GetQuery().AsEnumerable();
        }
 
        /// <summary>
        /// Finds a record with the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A collection containing the results of the query</returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where<T>(predicate);
        }
 
        /// <summary>
        /// Gets a single record by the specified criteria (usually the unique identifier)
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record that matches the specified criteria</returns>
        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Single<T>(predicate);
        }
 
        /// <summary>
        /// The first record matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        /// <returns>A single record containing the first record matching the specified criteria</returns>
        public T First(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.FirstOrDefault<T>(predicate);
        }
 
        /// <summary>
        /// Deletes the specified entitiy
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
 
            _objectSet.DeleteObject(entity);
        }
 
        /// <summary>
        /// Deletes records matching the specified criteria
        /// </summary>
        /// <param name="predicate">Criteria to match on</param>
        public void Delete(Func<T, bool> predicate)
        {
            IEnumerable<T> records = from x in _objectSet.Where<T>(predicate) select x;
 
            foreach (T record in records)
            {
                _objectSet.DeleteObject(record);
            }
        }
 
        /// <summary>
        /// Adds the specified entity
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
 
            _objectSet.AddObject(entity);
        }
 
        /// <summary>
        /// Attaches the specified entity
        /// </summary>
        /// <param name="entity">Entity to attach</param>
        public void Attach(T entity)
        {
            _objectSet.Attach(entity);
        }
 
        /// <summary>
        /// Saves all context changes
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
 
        /// <summary>
        /// Saves all context changes with the specified SaveOptions
        /// </summary>
        /// <param name="options">Options for saving the context</param>
        public void SaveChanges(SaveOptions options)
        {
            _context.SaveChanges(options);
        }
 
        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
 
        /// <summary>
        /// Releases all resources used by the WarrantManagement.DataExtract.Dal.ReportDataBase
        /// </summary>
        /// <param name="disposing">A boolean value indicating whether or not to dispose managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public bool IsValid(T entity)
        {
            StringBuilder builder = new StringBuilder(string.Empty);
            //Create a new validator using the ValidationFactory method
            Validator pValidator = ValidationFactory.CreateValidator(entity.GetType());
            ValidationResults results = pValidator.Validate(entity); // new ValidationResults();
            //validator.Validate(this, results);
            if (!results.IsValid)
            {
                builder.Append("\t+Validation Error(s):\n");
                foreach (ValidationResult result in results)
                {
                    builder.Append(String.Format("\t Message=> {0} (Key: {1}, Tag: {2}, Target: {3})\n",
                        result.Message, result.Key, result.Tag, result.Target.ToString()));
                }
                throw new Exception(builder.ToString());
            }
            return results.IsValid;
        }
        
        #endregion
    }

}
