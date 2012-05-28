using System;
//using Microsoft.Practices.EnterpriseLibrary.Caching;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using MovieBooking.DLL.Entities;
using MovieBooking.Model.Entities;
using System.Runtime.Serialization;
using System.ServiceModel;

/* -----------------------------------------------------------------
 * REVISION HISTORY
 * -----------------------------------------------------------------
 * DATE           AUTHOR          REVISION		DESCRIPTION
 * 20 May 2012    Mansoor M I     0.1			Intial version
 * 													
 * 																									
 * 													
 * 
 */

namespace MovieBooking.BLL.Entities
{
    [DataContract]
    public class Payment : mb_Payment
    {
        [DataMember]
        public new int ID { get; private set; }
        [DataMember]
        public override int MovieBookingID { get; set; }
        [DataMember]
        public override string PaymentModeID { get; set; }
        [DataMember]
        public override System.DateTime PaymentDate { get; set; }
        [DataMember]
        public override string CreditCardNo { get; set; }
        [DataMember]
        public override string CardExpiry { get; set; }
        [DataMember]
        public override string CardHolderName { get; set; }
        [DataMember]
        public override string CCV { get; set; }
        [DataMember]
        public override decimal TotalAmount { get; set; }
        [DataMember]
        public override double GSTPercent { get; set; }

        #region ctor and copyTo methods

        public Payment() { }
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

    public class PaymentRepository
    {
        // Global variable to store the ExceptionManager instance. 
        //ExceptionManager exManager;
        //ICacheManager cache = null;

        public PaymentRepository()
        {
            //cache = CacheFactory.GetCacheManager();
            // Resolve the default ExceptionManager object from the container.
            //exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();
        }

        public Payment FindById(int id)
        {
            Payment _payment = null;
            using (IRepository<mb_Payment> mbRep = new MovieBookingRepository<mb_Payment>())
            {
                var pt = mbRep.First(p => p.ID.Equals(id));
                _payment = new Payment(pt);
            }
            return _payment;
        }

        public int Insert(Payment payment)
        {
            int status = -1;
            mb_Payment mb_pt = new mb_Payment();
            payment.CopyTo(mb_pt);

            using (IRepository<mb_Payment> mbRep = new MovieBookingRepository<mb_Payment>())
            {
                mbRep.Add(mb_pt);
                mbRep.SaveChanges();
                status = mb_pt.ID;
            }

            return status;
        }

        public bool Update(Payment payment)
        {
            int status = -1;
            using (IRepository<mb_Payment> mbRep = new MovieBookingRepository<mb_Payment>())
            {
                var mb_pt = mbRep.First(p => p.ID == payment.ID);
                payment.CopyTo(mb_pt);
                mbRep.SaveChanges();
                status = 0;
            }
            return (status == 0);
        }

    }
}
