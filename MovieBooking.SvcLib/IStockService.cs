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

namespace MovieBooking.SvcLib
{
    [ServiceContract]
    public interface IStockService
    {
        [OperationContract]
        Stock GetStock(string Symbol);
    }

    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Company { get; set; }
        [DataMember]
        public decimal Close { get; set; }
    }
}
