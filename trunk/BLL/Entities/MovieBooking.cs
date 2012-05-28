using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Transactions;


namespace MovieBooking.BLL.Entities
{
    public partial class Booking : mb_MovieBooking
    {
        public List<BookingItem> bookingItems;
        public Payment payment;
        public Movie movie;
        public Theatre theatre;
        public Hall hall;

        public Booking(mb_MovieBooking _mb_booking)
        {
            ID = _mb_booking.ID;
            BookingRef = _mb_booking.BookingRef;
            BookingDate = _mb_booking.BookingDate;
            MemberID = _mb_booking.MemberID;
            ScheduleID = _mb_booking.ScheduleID;
            BookingDate = _mb_booking.BookingDate;
            StatusID = _mb_booking.StatusID;

            bookingItems = new List<BookingItem>();
            payment = new Payment();
            movie = new Movie();
            theatre = new Theatre();
            hall = new Hall();
                        
        }
    }

    public interface IBookingRepository 
    {
        List<Booking> GetMovieBookings();
        List<Booking> GetMovieBookingsForCustomer(Guid memberId);
        Booking CreateBooking(Movie movie, RegisteredUser user, MovieSchedule schedule, List<BookingItem> items, Payment payment );
        Booking CreateBooking(int schedule_id, List<string> selected_seats, Payment payment, RegisteredUser user);
    }

    public class BookingRepository : IBookingRepository
    {
        private IRepository<mb_MovieBooking> context;

        public BookingRepository()
        {
            this.context = new MovieBookingRepository<mb_MovieBooking>();
        }

        public List<Booking> GetMovieBookings()
        {
            List<Booking> bookingList = null;

            try
            {
                using (IRepository<mb_MovieBooking> mbRep = new MovieBookingRepository<mb_MovieBooking>())
                {
                    var ts = from t in mbRep.FetchAll()
                             select new Booking(t);
                    bookingList = ts.ToList();

                    BookingItemRepository itemRepo = new BookingItemRepository();

                    foreach (Booking booking in bookingList)
                    {
                        List<BookingItem> bookingItems = itemRepo.GetMovieBookingItems(booking);
                        booking.bookingItems = bookingItems;
                    }
                }
                return bookingList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie Bookings " + ex.Message);
            }
        }

        public List<Booking> GetMovieBookingsForCustomer(Guid MemberId)
        {
            List<Booking> bookingList = null;

            try
            {
                using (IRepository<mb_MovieBooking> mbRep = new MovieBookingRepository<mb_MovieBooking>())
                {

                    var ts = from t in mbRep.FetchAll().Where(b => b.MemberID.Equals(MemberId))
                             select new Booking(t);

                    bookingList = ts.ToList();

                    BookingItemRepository itemRepo = new BookingItemRepository();

                    foreach (Booking booking in bookingList)
                    {
                        List<BookingItem> bookingItems = itemRepo.GetMovieBookingItems(booking);
                        booking.bookingItems = bookingItems;
                    }
                }
                return bookingList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie Bookings for customer " + ex.Message);
            }
        }

        public List<BookingItem> GetMovieBookingsForSchedule(int scheduleItemId)
        {
            List<Booking> bookingList = null;
            List<BookingItem> bookingItemsList = new List<BookingItem>() ;

            try
            {
                using (IRepository<mb_MovieBooking> mbRep = new MovieBookingRepository<mb_MovieBooking>())
                {

                    var ts = from t in mbRep.FetchAll().Where(b => b.ScheduleID.Equals(scheduleItemId))
                             select new Booking(t);

                    bookingList = ts.ToList();

                    BookingItemRepository itemRepo = new BookingItemRepository();

                    foreach (Booking booking in bookingList)
                    {
                        List<BookingItem> bookingItems = itemRepo.GetMovieBookingItems(booking);
                        booking.bookingItems = bookingItems;
                        foreach (BookingItem _item in bookingItems)
                        {
                            bookingItemsList.Add(_item);
                        }
                       
                    }
                }
                return bookingItemsList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while getting Movie Bookings for customer " + ex.Message);
            }
        }


        public Booking CreateBooking(Movie movie, RegisteredUser user, MovieSchedule schedule, List<BookingItem> items, Payment payment)
        {
            try{
                using (IRepository<mb_MovieBooking> mbRep = new MovieBookingRepository<mb_MovieBooking>())
                {
                    // Define a transaction scope for the operations.
                    TransactionOptions options = new TransactionOptions
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                        Timeout = TransactionManager.DefaultTimeout
                    };

                    using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
                    {
                        mb_MovieBooking booking = new mb_MovieBooking();

                        List<mb_MovieBooking_Item> _booking_items = new List<mb_MovieBooking_Item>();
                        List<BookingItem> bookingItems = new List<BookingItem>();
                        //Set booking items in booking
                        foreach (BookingItem _item in items)
                        {
                            mb_MovieBooking_Item item = new mb_MovieBooking_Item();
                            BookingItem bItem = new BookingItem();
                            bItem.CopyTo(item);
                            _item.CopyTo(item);
                            _booking_items.Add(item);
                            bookingItems.Add(bItem);
                        }
                        
                       
                        booking.mb_MovieBooking_Item = _booking_items;

                        //Schedule foreign key
                        mb_MovieSchedule _schedule = new mb_MovieSchedule();
                        schedule.CopyTo(_schedule);
                        booking.ScheduleID = _schedule.ID;

                        //Registered user foreign key
                        mb_RegisteredUser _user = new mb_RegisteredUser();
                        user.CopyTo(_user);
                        booking.MemberID = _user.UserId;

                        booking.BookingDate = DateTime.Now;

                        booking.BookingRef = "1223";
                        booking.StatusID = "1";


                        mbRep.Add(booking);
                        mbRep.SaveChanges();
                        scope.Complete();
                        return new Booking(booking);
                    }

                }
            }catch(Exception ex){

                    throw new Exception("Error occured while creating new Booking " + ex.Message);
                }

            }

        public Booking CreateBooking(int schedule_id, List<string> selected_seats, Payment payment, RegisteredUser user)
        {
            Booking booking = null;
            
            try{
                using (IRepository<mb_MovieBooking> mbRep = new MovieBookingRepository<mb_MovieBooking>())
                {
                    // Define a transaction scope for the operations.
                    TransactionOptions options = new TransactionOptions
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                        Timeout = TransactionManager.DefaultTimeout
                    };

                    using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
                    {

                        mb_MovieBooking _booking = new mb_MovieBooking();
                        List<mb_MovieBooking_Item> items = new List<mb_MovieBooking_Item>();

                        List<BookingItem> bookingItems = new List<BookingItem>();
                        //Set booking items in booking
                        foreach(string seat in selected_seats){
                            mb_MovieBooking_Item item = new mb_MovieBooking_Item();
                            BookingItem bItem = new BookingItem();
                            bItem.SeatNo = seat;
                            item.SeatNo = seat;
                            items.Add(item);
                            bookingItems.Add(bItem);
                        }
                        _booking.mb_MovieBooking_Item = items;

                        _booking.ScheduleID = schedule_id;

                        //Registered user foreign key
                        //mb_RegisteredUser _user = new mb_RegisteredUser();
                        //user.CopyTo(_user);
                        _booking.MemberID = user.UserId;

                        _booking.BookingDate = DateTime.Now;
                        _booking.BookingRef = "1223";
                        _booking.StatusID = "1";
                        mbRep.Add(_booking);
                        mbRep.SaveChanges();
                        

                        booking =  new Booking(_booking);     
                        booking.bookingItems = bookingItems;                        

                        payment.MovieBookingID= _booking.ID;
                        PaymentRepository paymentRepo = new PaymentRepository();
                        //int id = paymentRepo.CreatePayment(34, "CreditCard", DateTime.Now, "1234123412341234", "01/12", "Subramanian.S", "232", Decimal.Parse("23.000"), float.Parse("7.00"));
                        Payment _pm = paymentRepo.CreatePayment(payment.MovieBookingID, payment.PaymentModeID.ToString(), payment.PaymentDate, payment.CreditCardNo.ToString(), payment.CardExpiry.ToString(), payment.CardHolderName.ToString(), payment.CCV.ToString(), Decimal.Parse(payment.TotalAmount.ToString()), float.Parse(payment.GSTPercent.ToString()));
                       
                        //Save the transaction if the payment is successfull.
                        if (_pm != null && _pm.ID != null)
                        {
                            booking.payment = _pm;                            
                            scope.Complete();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while creating new Booking " + ex.Message);
            }

            return booking;
        }


        }

}
