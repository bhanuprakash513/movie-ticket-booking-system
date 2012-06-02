using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Schedule
{
    public partial class MovieScheduleUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
     
        private bool Validation(int MovieID, int TheatreID, int HallID, DateTime StartDate)
        {
            bool val = false;
            MovieScheduleRepository Moviesch = new MovieScheduleRepository();

                bool ret = Moviesch.FindbyValues(MovieID, TheatreID, HallID, StartDate);
                if (!ret)
                {
                    ErrorMessage.Text = "Update/Delete Cannot be done";

                }
                else
                {
                     val=true;
                }
            return val;



        }
        private void ClearFields()
        {
            this.Combotime1.SelectedIndex = 0;
            this.Combotime2.SelectedIndex = 0;
            this.Combotime3.SelectedIndex = 0;
            this.Combotime4.SelectedIndex = 0;
            txtPrice.Text = string.Empty;
            this.ComboActive.SelectedIndex = 0;
        }
        private List<DateTime> GetDateRange(DateTime StartingDate, DateTime EndingDate)
        {
            if (StartingDate > EndingDate)
            {
                ErrorMessage.Text = "Start Date should be less than End Date";
            }
            List<DateTime> rv = new List<DateTime>();
            DateTime tmpDate = StartingDate;
            do
            {
                rv.Add(tmpDate);
                tmpDate = tmpDate.AddDays(1);
            } while (tmpDate <= EndingDate);
            return rv;
        }
        protected void Btnupdate_Click(object sender, EventArgs e)
        { 
            int MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue);
            int TheatreID= Convert.ToInt32(this.ComboTheatreName.SelectedValue);
            int HallId = Convert.ToInt32(this.ComboHallName.SelectedValue);           
            bool Active = Convert.ToBoolean(this.ComboActive.SelectedValue);
            DateTime schDate = Convert.ToDateTime(this.TxtSchDate.Text);
            bool val = Validation(MovieID, TheatreID, HallId, schDate);
            if (val)
            {
                

                        MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                        int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                        int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                        int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                        int ScheduleId = movieSchedule.FindScheduleId(MovieId, TheatreId, HallID, schDate);
                        MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
                        {
                            ID = ScheduleId,
                            MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                            TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                            HallID = Convert.ToInt32(this.ComboHallName.SelectedValue),
                            Price = Convert.ToDecimal(txtPrice.Text),
                            ScheduleDate = schDate,
                            Active = Convert.ToBoolean(this.ComboActive.SelectedValue),

                        };
                        MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
                        newMovieSchedule.Update(movie);
                        MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
                        var MovieSchItem = newScheduleItem.findIdbyTimeslot(ScheduleId);
                        List<MovieBooking.BLL.Entities.MovieSchedule_Item> MovitemId = (List<MovieBooking.BLL.Entities.MovieSchedule_Item>)MovieSchItem;
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[0].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime1.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Update(movieScheduleItem);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[1].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime2.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Update(movieScheduleItem2);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[2].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime3.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Update(movieScheduleItem3);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[3].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime4.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Update(movieScheduleItem4);
                        ErrorMessage.Text = "Updated Successfully";
                    
               
            }
            else
            {
                ErrorMessage.Text = "No Data Found. Cannot be Updated";
            }

        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            int MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue);
            int TheatreID= Convert.ToInt32(this.ComboTheatreName.SelectedValue);
            int HallId = Convert.ToInt32(this.ComboHallName.SelectedValue);           
            bool Active = Convert.ToBoolean(this.ComboActive.SelectedValue);
            DateTime schDate = Convert.ToDateTime(this.TxtSchDate.Text);
            bool val = Validation(MovieID, TheatreID, HallId, schDate);
            
            if (val)
            {
              
                        MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                        int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                        int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                        int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                        int ScheduleId = movieSchedule.FindScheduleId(MovieId, TheatreId, HallID, schDate);
                        MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
                        {
                            ID = ScheduleId,
                            MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                            TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                            HallID = Convert.ToInt32(this.ComboHallName.SelectedValue),
                            Price = Convert.ToDecimal(txtPrice.Text),
                            ScheduleDate = schDate,
                            Active = Convert.ToBoolean(this.ComboActive.SelectedValue),

                        };
                        MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
                        MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
                        var MovieSchItem = newScheduleItem.findIdbyTimeslot(ScheduleId);
                        List<MovieBooking.BLL.Entities.MovieSchedule_Item> MovitemId = (List<MovieBooking.BLL.Entities.MovieSchedule_Item>)MovieSchItem;
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[0].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime1.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Delete(movieScheduleItem);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[1].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime2.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Delete(movieScheduleItem2);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[2].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime3.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Delete(movieScheduleItem3);
                        MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                        {
                            ID = MovitemId[3].ID,
                            MovieScheduleID = ScheduleId,
                            TimeSlotID = this.Combotime4.SelectedValue,
                            Price = Convert.ToDecimal(txtPrice.Text)
                        };
                        newScheduleItem.Delete(movieScheduleItem4);
                        bool ret = newMovieSchedule.Delete(movie);
                        if (ret)
                        {
                            ErrorMessage.Text = "Deleted Successfully";
                            ClearFields();
                        }
                    
                
            }
            else
            {
                ErrorMessage.Text = "No Data Found";
            }
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                MovieScheduleItemRepository movieScheduleItem = new MovieScheduleItemRepository();
                int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                DateTime schDate = Convert.ToDateTime(this.TxtSchDate.Text);
                var MovieScheduleList = movieSchedule.FindMovieschedule(MovieId, TheatreId, HallID, schDate);
                if (MovieScheduleList != null)
                {
                    ComboActive.SelectedValue = MovieScheduleList.Active.ToString();
                    txtPrice.Text = Convert.ToInt32(MovieScheduleList.Price).ToString();
                    var MovieSchItem = movieScheduleItem.FindbySchId(MovieScheduleList.ID);
                    if (MovieSchItem != null)
                    {
                        List<MovieBooking.BLL.Entities.MovieSchedule_Item> Movsch = (List<MovieBooking.BLL.Entities.MovieSchedule_Item>)MovieSchItem;
                        
                        this.Combotime1.SelectedValue = Movsch[0].TimeSlotID;
                        this.Combotime2.SelectedValue = Movsch[1].TimeSlotID;
                        this.Combotime3.SelectedValue = Movsch[2].TimeSlotID;
                        this.Combotime4.SelectedValue = Movsch[3].TimeSlotID;
                      
                        
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Calendar3.Visible = true;
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            TxtSchDate.Text = Calendar3.SelectedDate.ToShortDateString();
            Calendar3.Visible = false;
        }
    }
}