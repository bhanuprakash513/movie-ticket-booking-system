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
            if (!IsPostBack)
            {
                TxtFromdate.Text = DateTime.Now.ToString("dd-MM-yyy");
                TxtTodate.Text = DateTime.Now.ToString("dd-MM-yyy");
            }

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
        private bool Validation(int MovieID, int TheatreID, int HallID, DateTime StartDate, DateTime EndDate)
        {
            bool val = true;
            MovieScheduleRepository Moviesch = new MovieScheduleRepository();
            List<DateTime> Dates = GetDateRange(StartDate, EndDate);
            if (Dates == null)
            {

            }
            else
            {
                for (int i = 0; i < Dates.Count(); i++)
                {
                    bool ret = Moviesch.FindbyValues(MovieID, TheatreID, HallID, Dates[i]);
                    if (ret)
                    {
                        ErrorMessage.Text = "Already Schedules for the Information";

                    }
                    else
                    {
                        val = false;
                    }
                }
            }
            return val;



        }
        private List<DateTime> GetDateRange(DateTime StartingDate, DateTime EndingDate)
        {
            List<DateTime> rv = new List<DateTime>();
            if (StartingDate > DateTime.Now)
            {
                if (!StartingDate.Month.Equals(EndingDate.Month))
                {
                    ErrorMessage.Text = "Error !! Movie can be scheduled only for Current Month";
                }
                else
                {
                    if (StartingDate > EndingDate)
                    {
                        ErrorMessage.Text = "Error !!  Start Date should be less than End Date";
                    }

                    DateTime tmpDate = StartingDate;
                    do
                    {
                        rv.Add(tmpDate);
                        tmpDate = tmpDate.AddDays(1);
                    } while (tmpDate <= EndingDate);
                }
            }
            else
            {
                ErrorMessage.Text = "Error !! From date should be greater than Today's Date";
            }
            return rv;
        }
        protected void Btncreate_Click(object sender, EventArgs e)
        {
            int MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue);
            int TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue);
            int HallID = Convert.ToInt32(this.CombohallName.SelectedValue);
            bool Active = Convert.ToBoolean(this.ComboActive.SelectedValue);
            DateTime StartDate = Convert.ToDateTime(this.TxtFromdate.Text);
            DateTime EndDate = Convert.ToDateTime(this.TxtTodate.Text);
            bool val = Validation(MovieID, TheatreID, HallID, StartDate, EndDate);
            List<DateTime> Dates = GetDateRange(StartDate, EndDate);
            if (!val)
            {
                if (Dates == null)
                {
                    ErrorMessage.Text = "Error !! No Dates Retrieved";
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
            else
            {
                
            }

        }

    }
}