using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Schedule
{
    public partial class MovieScheduleAdd : System.Web.UI.Page
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
        private void Validation(int MovieID,int TheatreID,int HallID,bool Active,DateTime StartDate,DateTime EndDate)
        {
            MovieScheduleRepository Moviesch = new MovieScheduleRepository();

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
        protected void Btncreate_Click(object sender, EventArgs e)
        {
            int MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue);
            int TheatreID= Convert.ToInt32(this.ComboTheatreName.SelectedValue);
            int HallID = Convert.ToInt32(this.CombohallName.SelectedValue);           
            bool Active = Convert.ToBoolean(this.ComboActive.SelectedValue);
            DateTime StartDate = Convert.ToDateTime(this.TxtFromdate.Text);
            DateTime EndDate = Convert.ToDateTime(this.TxtTodate.Text);
            Validation(MovieID, TheatreID, HallID, Active, StartDate, EndDate);
            List<DateTime> Dates = GetDateRange(StartDate, EndDate);
            if (Dates == null)
            {

            }
            else
            {
                for (int i = 0; i < Dates.Count(); i++)
                {
                    MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
                    {
                        MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                        TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                        HallID = Convert.ToInt32(this.CombohallName.SelectedValue),
                        Price = Convert.ToDecimal(TxtPrice.Text),
                        ScheduleDate = Dates[i],
                        Active = Convert.ToBoolean(this.ComboActive.SelectedValue),

                    };
                    MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
                    int ScheduleID = newMovieSchedule.Insert(movie);
                    MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleID,
                        TimeSlotID = this.Combotime1.SelectedValue,
                        Price = Convert.ToDecimal(TxtPrice.Text)
                    };
                    newScheduleItem.Insert(movieScheduleItem);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleID,
                        TimeSlotID = this.Combotime2.SelectedValue,
                        Price = Convert.ToDecimal(TxtPrice.Text)
                    };
                    newScheduleItem.Insert(movieScheduleItem2);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleID,
                        TimeSlotID = this.Combotime3.SelectedValue,
                        Price = Convert.ToDecimal(TxtPrice.Text)
                    };
                    newScheduleItem.Insert(movieScheduleItem3);
                    MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
                    {
                        MovieScheduleID = ScheduleID,
                        TimeSlotID = this.Combotime4.SelectedValue,
                        Price = Convert.ToDecimal(TxtPrice.Text)
                    };
                    newScheduleItem.Insert(movieScheduleItem4);
                    ErrorMessage.Text = "Inserted Successfully";
                }
            }

        }
   
    }
}