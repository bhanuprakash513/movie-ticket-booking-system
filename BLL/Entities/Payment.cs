﻿using System;
using System.Linq;
using System.Transactions;
using System.Collections.Generic;
using MovieBooking.DAL;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace MovieBooking.BLL.Entities
{

    public partial class Payment : mb_Payment
    {
        public int ID { get; set; }

        [NotNullValidator(MessageTemplate = "CardHolder Name - Cannot be null!")]
        [StringLengthValidator(5, RangeBoundaryType.Inclusive, 25, RangeBoundaryType.Inclusive, MessageTemplate = "CardHolder Name should be atleast 5 charachters long and not exceeding 25 characters")]
        public override string CardHolderName
        {
            get;
            set;
        }

        #region ctor and copyTo methods

        public Payment() { }

        public Payment(int movieBookingID, string paymentMode, DateTime paymentDate, string creditCardNum, string creditCardExpiry, string cardName, string ccv, float totalPayment, float gst)
        {
            this.MovieBookingID = movieBookingID;
            this.PaymentModeID = paymentMode;
            this.PaymentDate = PaymentDate;
            this.CreditCardNo = creditCardNum.ToString();
            this.CardExpiry = creditCardExpiry;
            this.CardHolderName = cardName;
            this.CCV = ccv;
            this.TotalAmount = Decimal.Parse(totalPayment.ToString());
            this.GSTPercent = gst;
        }

        public Payment(mb_Payment mbPm)
        {
            ID = mbPm.ID;
            MovieBookingID = mbPm.MovieBookingID;
            PaymentModeID = mbPm.PaymentModeID;
            PaymentDate = mbPm.PaymentDate;
            CreditCardNo = mbPm.CreditCardNo;
            CardExpiry = mbPm.CardExpiry;
            CardHolderName = mbPm.CardHolderName;
            CCV = mbPm.CCV;
            TotalAmount = mbPm.TotalAmount;
            GSTPercent = mbPm.GSTPercent;
        }

        public void CopyTo(mb_Payment mbPm)
        {
            mbPm.ID = this.ID;
            mbPm.MovieBookingID = this.MovieBookingID;
            mbPm.PaymentModeID = this.PaymentModeID;
            mbPm.PaymentDate = this.PaymentDate;
            mbPm.CreditCardNo = this.CreditCardNo;
            mbPm.CardExpiry = this.CardExpiry;
            mbPm.CardHolderName = this.CardHolderName;
            mbPm.CCV = this.CCV;
            mbPm.TotalAmount = this.TotalAmount;
            mbPm.GSTPercent = this.GSTPercent;
        }

        #endregion
    }

    public interface IPaymentRepository
    {
        //List<Payment GetPaymentForCustomer(Guid memberID);
        //Payment GetPayment(int id);
        //int CreatePayment(int movieBookingID, string paymentModeID, DateTime paymentDate, string cardNo, string cardExpiry, string cardHolderName, string ccv, float money, float gst);
        int CreatePayment(Payment pm);
    }

    public class PaymentRepository
    {
        // Global variable to store the ExceptionManager instance. 
        ExceptionManager exManager;
        ICacheManager cache = null;

        public PaymentRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            //exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        //public Theatre FindById(int id)
        //{
        //    Theatre _theatre = null;
        //    using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
        //    {
        //        var th = from t in mbRep.FetchAll().Where(c => c.ID.Equals(id))
        //                 select new Theatre(t);
        //        _theatre = th.FirstOrDefault();
        //    }
        //    return _theatre;
        //}

        //public IEnumerable<Theatre> FindAll()
        //{
        //    IList<Theatre> _theatres = null;
        //    using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
        //    {
        //        var ts = from t in mbRep.FetchAll()
        //                 select new Theatre(t);
        //        _theatres = ts.ToList<Theatre>();
        //    }
        //    return _theatres.AsEnumerable<Theatre>();
        //}

        //public Payment CreatePayment(int movieBookingID, string paymentModeID, DateTime paymentDate, string cardNo, string cardExpiry, string cardHolderName, string ccv, decimal totalAmount, float gst)
          public Payment CreatePayment(Payment pm)
          {
            //Payment pm = new Payment();
            //pm.MovieBookingID = movieBookingID;
            //pm.PaymentModeID = paymentModeID;
            //pm.PaymentDate = paymentDate;
            //pm.CreditCardNo = cardNo;
            //pm.CardExpiry = cardExpiry;
            //pm.CardHolderName = cardHolderName;
            //pm.CCV = ccv;
            //pm.TotalAmount = totalAmount;
            //pm.GSTPercent = gst;
            try
            {
                mb_Payment mbPm = new mb_Payment();
                pm.CopyTo(mbPm);
                int status = -1;
                using (IRepository<mb_Payment> mbRep = new MovieBookingRepository<mb_Payment>())
                {
                        mbRep.Add(mbPm);
                        mbRep.SaveChanges();
                        status = mbPm.ID;
                        pm.ID = mbPm.ID;
                        
                }
                return pm;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured while payment is done " + ex.Message);
            }
        }

        //public int Update(Theatre theatre)
        //{
        //    mb_Theatre th = new mb_Theatre();
        //    using (IRepository<mb_Theatre> mbRep = new MovieBookingRepository<mb_Theatre>())
        //    {
        //        th = mbRep.First(u => u.ID == theatre.ID) as mb_Theatre;
        //        theatre.CopyTo(th);
        //        mbRep.SaveChanges();
        //    }
        //    return th.ID;
        //}

        //public bool Delete()
        //{
        //    throw new NotImplementedException();
        //}
    }
}