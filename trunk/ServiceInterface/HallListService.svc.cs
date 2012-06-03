using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MovieBooking.BLL.Entities;

namespace MovieBooking.SI.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "HallListService" in code, svc and config file together.
    public class HallListService : IHallListService
    {
        public IEnumerable<Hall> GetHallList(int Id)
        {
            List<Hall> HallDets = new List<Hall>();
            HallRepository ptRep = new HallRepository();
            List<MovieBooking.BLL.Entities.Hall> HallDetail = ptRep.FindAll(Id) as List<MovieBooking.BLL.Entities.Hall>;
            foreach (MovieBooking.BLL.Entities.Hall Hal in HallDetail)
            {
                Hall haldet = new Hall();
                haldet.Active = Hal.Active;
                haldet.HallName = Hal.HallName;
                haldet.TotalSeats = Hal.TotalSeats;
                HallDets.Add(haldet);
            }
            return HallDets;
        }
    }
}
