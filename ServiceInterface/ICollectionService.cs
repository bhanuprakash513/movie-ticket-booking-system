using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using MovieBooking.BLL.Entities;


namespace MovieBooking.SI.Web
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface ICollectionService
    {
        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        List<SvcBooking> GetBookingListByDateRange(DateTime startDate, DateTime endDate);

        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        List<SvcBooking> GetBookingListByDate(DateTime startDate);

        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        SvcRevenue GetDailyRevenue(DateTime startDate);
    }

    [DataContract]
    public class SvcBooking
    {
        [DataMember]
        public SvcPayment payment { get; set; }
        [DataMember]
        public SvcMovieSchedule movieSchedule { get; set; }
        [DataMember]
        public DateTime bookingDate { get; set; }
        [DataMember]
        public int numOfTicket { get; set; }

        public SvcBooking()
        {
            payment = new SvcPayment();
            movieSchedule = new SvcMovieSchedule();
        }
    }

    [DataContract]
    public class SvcPayment
    {
        [DataMember]
        public string paymentMode { get; set; }
        [DataMember]
        public DateTime paymentDate { get; set; }
        [DataMember]
        public string ccnum { get; set; }
        [DataMember]
        public double amount { get; set; }
        [DataMember]
        public double gstRate { get; set; }
        [DataMember]
        public string cardHoldeName { get; set; }
    }

    [DataContract]
    public class SvcRevenue
    {
        [DataMember]
        public DateTime paymentDate { get; set; }
        [DataMember]
        public double revenueAmount { get; set; }
        [DataMember]
        public int ticketCount { get; set; }

        public SvcRevenue()
        {
            revenueAmount = 0.00;
            ticketCount = 0;
        }
    }

    [DataContract]
    public class SvcMovie
    {
        [DataMember]
        public string movieName { get; set; }
        [DataMember]
        public string languageID { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string castDescription { get; set; }
    }

    [DataContract]
    public class SvcMovieSchedule
    {
        [DataMember]
        public SvcMovie svcMovie { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ScheduleDate { get; set; }
        [DataMember]
        public List<SvcMovieSchedule_Item> movieSchItem { get; set; }
        [DataMember]
        public string hall { get; set; }
        [DataMember]
        public string theatre { get; set; }

        public SvcMovieSchedule()
        {
            svcMovie = new SvcMovie();
            movieSchItem = new List<SvcMovieSchedule_Item>();
        }
    }

    [DataContract]
    public class SvcMovieSchedule_Item
    {
        [DataMember]
        public string TimeSlotID { get; set; }
    }

    [DataContract]
    public class ServiceFault
    {
        [DataMember]
        public string issue { get; set; }

        public ServiceFault(string msg)
        {
            this.issue = msg;
        }
    }
}
