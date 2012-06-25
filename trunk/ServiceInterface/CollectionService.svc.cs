using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;

namespace MovieBooking.SI.Web
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession)]
    public class CollectionService : ICollectionService
    {
        EntityMapperTranslator t;
        BookingRepository bookRepo;
        MovieScheduleRepository movieSchRepo;

        //Constructor
        public CollectionService()
        {
            t = new EntityMapperTranslator();
            bookRepo = new BookingRepository();
            movieSchRepo = new MovieScheduleRepository();
        }

        // Get booking list, booking date as the parameter
        public List<SvcBooking> GetBookingListByDate(DateTime startDate)
        {
            List<Booking> myBookingList = new List<Booking>();
            List<SvcBooking> mySvcBookingList = new List<SvcBooking>();
            SvcBooking mySvcBooking = new SvcBooking();

            try
            {
                myBookingList = bookRepo.GetPaidBookingListByDate(startDate);
            }
            catch (Exception ex)
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected day no booking."), new FaultReason("An error has occur."));
            }

            if (myBookingList != null && myBookingList.Count > 0)
            {
                foreach (Booking b in myBookingList)
                {
                    mySvcBooking = t.BookingBusinessToService(b);
                    mySvcBooking.movieSchedule = GetSvcMovieSchedule((int)b.ScheduleID);
                    mySvcBookingList.Add(mySvcBooking);
                }
                return mySvcBookingList;
            }
            else
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected day no booking."), new FaultReason("An error has occur."));
            }
        }

        // Get booking list, booking date range as the parameter
        public List<SvcBooking> GetBookingListByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Booking> myBookingList = new List<Booking>();
            List<SvcBooking> mySvcBookingList = new List<SvcBooking>();
            SvcBooking mySvcBooking = new SvcBooking();

            if (endDate == null)
                endDate = startDate;

            do
            {
                myBookingList = bookRepo.GetPaidBookingListByDate(startDate);

                if (myBookingList != null)
                {
                    foreach (Booking b in myBookingList)
                    {
                        mySvcBooking = t.BookingBusinessToService(b);
                        mySvcBooking.movieSchedule = GetSvcMovieSchedule((int)b.ScheduleID);
                        mySvcBookingList.Add(mySvcBooking);
                    }
                }

                startDate = startDate.AddDays(1);
            } while (startDate <= endDate);

            if(mySvcBookingList != null && mySvcBookingList.Count > 0)
                return mySvcBookingList;
            else
                throw new FaultException<ServiceFault>(new ServiceFault("Selected days no booking."), new FaultReason("An error has occur."));
        }

        // Get revenue for a day, payment date as the parameter
        public SvcRevenue GetDailyRevenue(DateTime startDate)
        {
            SvcRevenue svcRevenue = new SvcRevenue();
            List<SvcBooking> mySvcBookingList = new List<SvcBooking>();

            try
            {
                mySvcBookingList = GetBookingByPayDate(startDate);
            }
            catch
            {
                throw new FaultException<ServiceFault>(new ServiceFault("Selected day no revenue."), new FaultReason("An error has occur."));
            }

            if(mySvcBookingList != null && mySvcBookingList.Count > 0)
            {
                foreach (SvcBooking sb in mySvcBookingList)
                {
                    svcRevenue.paymentDate = sb.payment.paymentDate;
                    svcRevenue.revenueAmount += sb.payment.amount;
                    svcRevenue.ticketCount += sb.numOfTicket;
                }

            }

            return svcRevenue;
        }

        // Get booking list, payment date as the parameter
        //Currently not expose to contract
        public List<SvcBooking> GetBookingByPayDate(DateTime startDate)
        {
            PaymentRepository payRepo = new PaymentRepository();
            List<SvcBooking> mySvcBookingList = new List<SvcBooking>();
            SvcBooking mySvcBooking = new SvcBooking();
            List<int> bookingIdList = new List<int>();

            try
            {
                bookingIdList = payRepo.GetBookingIdByPaymentDate(startDate);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while retreiving booking by payment date" + ex.Message);
            }

            if (bookingIdList != null && bookingIdList.Count > 0)
            {
                foreach (int i in bookingIdList)
                {
                    Booking booking = bookRepo.GetBookingByBookingId(i);
                    mySvcBooking = t.BookingBusinessToService(booking);
                    mySvcBooking.movieSchedule = GetSvcMovieSchedule((int)booking.ScheduleID);
                    mySvcBookingList.Add(mySvcBooking);
                }
            }

            return mySvcBookingList;
        }

        // Get movie schedule, movie schedule id as the parameter
        //Private method, use internally
        private SvcMovieSchedule GetSvcMovieSchedule(int scheduleId)
        {
            MovieBooking.BLL.Entities.MovieSchedule movieSchedule = new MovieBooking.BLL.Entities.MovieSchedule();

            movieSchedule = movieSchRepo.GetMovieScheduleBySchItemId(scheduleId);

            return t.MovieSchBusinessToService(movieSchedule);
        }
    }
}
