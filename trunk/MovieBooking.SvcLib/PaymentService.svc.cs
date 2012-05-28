using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using MovieBooking.BLL.Entities;

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

namespace MovieBooking.SvcLib
{
    public class PaymentService : IPaymentService
    {
        public int Insert(Payment payment)
        {
            int status = -1;
            PaymentRepository ptRep = new PaymentRepository();
            BLL.Entities.Payment pay = payment as BLL.Entities.Payment;

            status = ptRep.Insert(pay);
            return status;
        }

        public bool Update(Payment payment)
        {
            bool status = false;
            PaymentRepository ptRep = new PaymentRepository();
            //status = ptRep.Update(payment);
            return status;
        }
    }
}
