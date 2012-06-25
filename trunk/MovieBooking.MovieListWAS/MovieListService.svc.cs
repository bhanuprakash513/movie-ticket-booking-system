using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;

namespace MovieBooking.MovieListWAS
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class MovieListService : IMovieListService
    {
        MovieRepository movieRepo;
        MovieScheduleRepository movieSchRepo;
        MLEntityMapperTranslator t;

        //Constructor with no paramater
        public MovieListService()
        {
            movieRepo = new MovieRepository();
            movieSchRepo = new MovieScheduleRepository();
            t = new MLEntityMapperTranslator();
        }

        //Get movie's details, movie's name as parameter
        public SvcMovie MovieDesc(string movieName)
        {
            SvcMovie mySvcMovie = new SvcMovie();
            Movie m = new Movie();

            //if parameter movieName is null or empty, return null object, need not proceed to get movie's details
            if (movieName == null || movieName.Trim() == "")
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Please provide non empty value."),new FaultReason("An error has occur."));
            }

            try
            {
                m = movieRepo.GetMovieByName(movieName);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected movie not found."), new FaultReason("An error has occur."));
            }   

            if (m != null)
            {
                mySvcMovie = t.MovieBusinessToService(m);
            }

            return mySvcMovie;
        }

        //Get all movie schedule for a day, date as the parameter
        public List<SvcMovieSchedule> MovieScheduleListPerDay(DateTime dt)
        {
            List<MovieSchedule> msList = new List<MovieSchedule>();
            List<SvcMovieSchedule> mySvcMovieScheduleList = new List<SvcMovieSchedule>();

            if (dt == null)
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Please provide non empty value."), new FaultReason("An error has occur."));
            }

            msList = movieSchRepo.GetMovieScheduleListByDate(dt);

            if (msList != null && msList.Count > 0)
            {
                mySvcMovieScheduleList = t.MovieSchListBusinessToService(msList);
            }
            else
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected day no schedule."), new FaultReason("An error has occur."));
            }

            return mySvcMovieScheduleList;
        }

        //Get all movie schedule for a movie, movie's name as the parameter
        public List<SvcMovieSchedule> MovieScheduleListPerMovie(string movieName)
        {
            List<MovieSchedule> movieSchList = new List<MovieSchedule>();
            List<SvcMovieSchedule> mySvcMovieScheduleList = new List<SvcMovieSchedule>();
            Movie m = new Movie();

            //if parameter movieName is null or empty, return null object, need not proceed to get movie's details
            if (movieName == null || movieName.Trim() == "")
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Please provide non empty value."), new FaultReason("An error has occur."));
            }

            try
            {
                m = movieRepo.GetMovieByName(movieName);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected movie not found."), new FaultReason("An error has occur."));
            }            

            if (m != null)
            {
                movieSchList = movieSchRepo.GetScheduleForMovie(m);

                if (movieSchList != null && movieSchList.Count > 0)
                {
                    mySvcMovieScheduleList = t.MovieSchListBusinessToService(movieSchList);
                }
                else
                {
                    throw new FaultException<ServiceFault>(new ServiceFault("Selected movie has no schedule."), new FaultReason("An error has occur."));
                }
            }

            return mySvcMovieScheduleList;
        }

    }

}
