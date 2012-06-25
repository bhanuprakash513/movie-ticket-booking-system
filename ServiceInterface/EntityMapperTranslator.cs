using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;


namespace MovieBooking.SI.Web
{
    public class EntityMapperTranslator
    {
        SvcMovie mySvcMovie; 
        MovieRepository movieRepo;
        MovieScheduleRepository movieSchRepo;

        //Constructor
        public EntityMapperTranslator()
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
            
            mySvcMovie = MovieBusinessToService(movieRepo.GetMovieById(value.MovieID));
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

        //Map business entity to service entity: Booking to SvcBooking
        public SvcBooking BookingBusinessToService(MovieBooking.BLL.Entities.Booking value)
        {
            SvcBooking svcBooking = new SvcBooking();

            svcBooking.payment = PaymentBusinessToService(value.payment);
            svcBooking.bookingDate = (DateTime) value.BookingDate;
            svcBooking.numOfTicket = value.bookingItems.Count();

            return svcBooking;
        }

        //Map business entity to service entity: Payment to SvcPayment
        //Private method, use internally
        private SvcPayment PaymentBusinessToService(MovieBooking.BLL.Entities.Payment value)
        {
            SvcPayment svcPayment = new SvcPayment();
 
            svcPayment.paymentDate = (DateTime) value.PaymentDate;
            svcPayment.cardHoldeName = value.CardHolderName;
            svcPayment.paymentMode = value.PaymentModeID;
            svcPayment.amount = (double) value.TotalAmount;
            svcPayment.gstRate = value.GSTPercent;

            return svcPayment;
        }

    }
}