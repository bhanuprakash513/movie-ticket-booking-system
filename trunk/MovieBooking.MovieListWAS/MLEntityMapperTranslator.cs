using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;


namespace MovieBooking.MovieListWAS
{
    public class MLEntityMapperTranslator
    {
        SvcMovie mySvcMovie; 
        MovieRepository movieRepo;
        MovieScheduleRepository movieSchRepo;

        //Constructor
        public MLEntityMapperTranslator()
        {
            mySvcMovie = new SvcMovie();
            movieRepo = new MovieRepository();            
            movieSchRepo = new MovieScheduleRepository();
        }


        //Map business entity to service entity: Movie to SvcMovie
        public SvcMovie MovieBusinessToService(MovieBooking.BLL.Entities.Movie value)
        {
            mySvcMovie.movieName = value.MovieName;
            mySvcMovie.languageID = value.LanguageID;
            mySvcMovie.castDescription = value.CastDescription;
            mySvcMovie.description = value.Description;

            return mySvcMovie;
        }

        //Map business entity to service entity: MovieSchedule to SvcMovieSchedule
        public SvcMovieSchedule MovieSchBusinessToService(MovieBooking.BLL.Entities.MovieSchedule value)
        {
            SvcMovieSchedule mySvcMovieSchedule = new SvcMovieSchedule();
            TheatreRepository theatreRepo = new TheatreRepository();
            HallRepository hallRepo = new HallRepository();
            
            mySvcMovie = MovieBusinessToService(movieRepo.FindbyId(value.MovieID));
            mySvcMovieSchedule.svcMovie = mySvcMovie;
            mySvcMovieSchedule.ScheduleDate = value.ScheduleDate;
            mySvcMovieSchedule.hall = hallRepo.FindById(value.HallID).HallName;
            mySvcMovieSchedule.theatre = theatreRepo.FindById(value.TheatreID).Name;

            foreach (var ml in value.items)
            {
                mySvcMovieSchedule.movieSchItem.Add(MovieSchItemBusinessToService(ml));
            }

            return mySvcMovieSchedule;
        }

        //Map business entity to service entity: MovieSchedule list to SvcMovieSchedule list
        public List<SvcMovieSchedule> MovieSchListBusinessToService(List<MovieBooking.BLL.Entities.MovieSchedule> value)
        {
            List<SvcMovieSchedule> mySvcMovieScheduleList = new List<SvcMovieSchedule>();

            foreach (var ms in value)
                mySvcMovieScheduleList.Add(MovieSchBusinessToService(ms));

            return mySvcMovieScheduleList;
        }

        //Map business entity to service entity: MovieScheduleItem to SvcMovieScheduleItem
        //Private method, use internally
        private SvcMovieSchedule_Item MovieSchItemBusinessToService(MovieBooking.BLL.Entities.MovieSchedule_Item value)
        {
            SvcMovieSchedule_Item mySvcMovieScheduleItem = new SvcMovieSchedule_Item();
            mySvcMovieScheduleItem.TimeSlotID = value.TimeSlotID;

            return mySvcMovieScheduleItem;
        }

    }
}