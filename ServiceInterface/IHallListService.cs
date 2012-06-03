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
        IEnumerable<Hall> GetHallList(int Id);

    }
    [DataContract]
    public class Hall : MovieBooking.BLL.Entities.Hall
    {

    }
}
