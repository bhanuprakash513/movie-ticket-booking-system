using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace MovieBooking.MovieListWAS
{
    [ServiceContract]
    public interface IMovieListService
    {
        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        List<SvcMovieSchedule> MovieScheduleListPerMovie(string movieName);

        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        List<SvcMovieSchedule> MovieScheduleListPerDay(DateTime dt);

        [FaultContract(typeof(ServiceFault))]
        [OperationContract]
        SvcMovie MovieDesc(string movieName);
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
