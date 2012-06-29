using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace MovieBooking.SI.Web
{
    [ServiceContract]
    public interface IHallListService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.NotAllowed)]
        IEnumerable<MovieBooking.BLL.Entities.Hall> GetHallList(int Id);

        //Start: Added on 28-Jun-2012
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool updateHall(MovieBooking.BLL.Entities.Hall myHall);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool addHall(MovieBooking.BLL.Entities.Hall myHall);
        //End: Added on 28-Jun-2012
    }

}
