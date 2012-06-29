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
        HallRepository ptRep = new HallRepository();

        public IEnumerable<Hall> GetHallList(int Id)
        {
            List<Hall> HallDets = new List<Hall>();
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

        //Start: Added on 28-Jun-2012
        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public bool updateHall(MovieBooking.BLL.Entities.Hall myHall)
        {
            try
            {
                ptRep.Update(myHall);

                return true;
            }
            catch (FaultException ex)
            {
                throw new FaultException("Error occured while update hall" + ex.Message);
            }
        }

        [OperationBehavior(TransactionAutoComplete = true, TransactionScopeRequired = true)]
        public bool addHall(MovieBooking.BLL.Entities.Hall myHall)
        {
            bool existFlag = false;
            Hall _Hall = new Hall();

            try
            {
                _Hall = ptRep.FindHallByTheatreIdHallName(myHall.TheatreID, myHall.HallName);
                if (_Hall != null)
                {
                    existFlag = true;
                }
            }
            catch (FaultException ex)
            {
                throw new FaultException("Error occured while add hall" + ex.Message);
            }

            if (existFlag == false)
            {
                ptRep.Insert(myHall);
                return true;
            }
            else
                return false;
        }
        //End: Added on 28-Jun-2012
    }
}
