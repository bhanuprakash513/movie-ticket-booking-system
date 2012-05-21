﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieBooking.Model.Entities;
using MovieBooking.DLL.Entities;
using System.Transactions;

namespace MovieBooking.BLL.Entities
{
    public partial class BookingItem : mb_MovieBooking_Item
    {

        public BookingItem(mb_MovieBooking_Item _mb_booking_item)
        {
            ID = _mb_booking_item.ID;
            MovieBookingID = _mb_booking_item.MovieBookingID;
            SeatNo = _mb_booking_item.SeatNo;
        }

        public BookingItem()
        {
        }


        public void CopyTo(mb_MovieBooking_Item _item)
        {
            _item.SeatNo = this.SeatNo;
            _item.MovieBookingID = this.MovieBookingID;
        }



    }

    public interface IBookingItemRepository
    {
        List<BookingItem> GetMovieBookingItems(Booking booking);
        void InsertMovieBookingItems(Booking booking,List<BookingItem> items);
    }


    public class BookingItemRepository : IBookingItemRepository
    {
        private IRepository<mb_MovieBooking_Item> context;

        public BookingItemRepository()
        {
            this.context = new MovieBookingRepository<mb_MovieBooking_Item>();
        }

        public List<BookingItem> GetMovieBookingItems(Booking booking)
        {
            List<BookingItem> bookingItems = null;

            using (IRepository<mb_MovieBooking_Item> mbRep = new MovieBookingRepository<mb_MovieBooking_Item>())
            {
                var ts = from t in mbRep.FetchAll().Where(c => c.MovieBookingID.Equals(booking.ID))
                         select new BookingItem(t);
                bookingItems = ts.ToList();
            }

            return bookingItems;
        }

        public void InsertMovieBookingItems(Booking booking, List<BookingItem> items)
        {
            using (IRepository<mb_MovieBooking_Item> mbRep = new MovieBookingRepository<mb_MovieBooking_Item>())
            {
                // Define a transaction scope for the operations.
                TransactionOptions options = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.DefaultTimeout
                };

                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, options))
                {

                    foreach (BookingItem item in items)
                    {
                        mb_MovieBooking_Item _item = new mb_MovieBooking_Item();
                        _item.MovieBookingID = booking.ID;
                        _item.SeatNo = item.SeatNo;
                        mbRep.Add(item);
                    }

                    mbRep.SaveChanges();
                    scope.Complete();
                }
            }

        }


    }
}
