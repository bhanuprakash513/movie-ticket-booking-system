using System;
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

namespace MovieBooking.SI.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentService" in both code and config file together.
    [ServiceContract]
    public interface IPaymentService
    {
        [OperationContract]
        int Insert(Payment payment);

        [OperationContract]
        bool Update(Payment payment);
    }

    [DataContract]
    public class Payment : MovieBooking.BLL.Entities.Payment
    {
    }
}
