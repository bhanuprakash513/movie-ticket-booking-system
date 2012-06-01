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
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TxtFromdate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TxtTodate.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }
        private List<DateTime> GetDateRange(DateTime StartingDate, DateTime EndingDate)
        {
            if (StartingDate > EndingDate)
            {
                return null;
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
            DateTime StartDate = Convert.ToDateTime(this.TxtFromdate.Text);
            DateTime EndDate = Convert.ToDateTime(this.TxtTodate.Text);
            List<DateTime> Dates = GetDateRange(StartDate, EndDate);
            if (Dates == null)
            {

            }
            else
            {
                for (int i = 0; i < Dates.Count(); i++)
                {
                    MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                    int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                    int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                    int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                    int ScheduleId = movieSchedule.FindScheduleId(MovieId, TheatreId, HallID);
                    MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
                    {
                        ID = ScheduleId,
                        MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                        TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                        HallID = Convert.ToInt32(this.ComboHallName.SelectedValue),
                        Price = Convert.ToDecimal(txtPrice.Text),
                        ScheduleDate = Dates[i],
                        Active = Convert.ToBoolean(this.ComboActive.SelectedValue),

                    };
                    MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
                    newMovieSchedule.Update(movie);
                    MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime1.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Update(movieScheduleItem);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime2.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Update(movieScheduleItem2);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime3.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Update(movieScheduleItem3);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime4.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Update(movieScheduleItem4);
                    ErrorMessage.Text = "Updated Successfully";
                }
            }

        }

        protected void Btndelete_Click(object sender, EventArgs e)
        {
            DateTime StartDate = Convert.ToDateTime(this.TxtFromdate.Text);
            DateTime EndDate = Convert.ToDateTime(this.TxtTodate.Text);
            List<DateTime> Dates = GetDateRange(StartDate, EndDate);
            if (Dates == null)
            {

            }
            else
            {
                for (int i = 0; i < Dates.Count(); i++)
                {
                    MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                    int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                    int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                    int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                    int ScheduleId = movieSchedule.FindScheduleId(MovieId, TheatreId, HallID);
                    MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
                    {
                        ID = ScheduleId,
                        MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                        TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                        HallID = Convert.ToInt32(this.ComboHallName.SelectedValue),
                        Price = Convert.ToDecimal(txtPrice.Text),
                        ScheduleDate = Dates[i],
                        Active = Convert.ToBoolean(this.ComboActive.SelectedValue),

                    };
                    MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
                    MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime1.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Delete(movieScheduleItem);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime2.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Delete(movieScheduleItem2);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime3.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Delete(movieScheduleItem3);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleId,
                        TimeSlotID = this.Combotime4.SelectedValue,
                        Price = Convert.ToDecimal(txtPrice.Text)
                    };
                    newScheduleItem.Delete(movieScheduleItem4);
                    bool ret = newMovieSchedule.Delete(movie);
                    if (ret)
                    {
                        ErrorMessage.Text = "Deleted Successfully";
                    }
                }
            }
        }

        protected void BtnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                MovieScheduleRepository movieSchedule = new MovieScheduleRepository();
                int MovieId = Convert.ToInt32(this.ComboMovName.SelectedValue);
                int TheatreId = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
                int HallID = Convert.ToInt32(this.ComboHallName.SelectedValue);
                var MovieScheduleList = movieSchedule.FindMovieschedule(MovieId, TheatreId, HallID);
                if (MovieScheduleList != null)
                {
                    TxtFromdate.Text = MovieScheduleList.ScheduleDate.ToString();
                    TxtTodate.Text = MovieScheduleList.ScheduleDate.ToString();
                    ComboActive.SelectedValue = MovieScheduleList.Active.ToString();
                    txtPrice.Text = MovieScheduleList.Price.ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}