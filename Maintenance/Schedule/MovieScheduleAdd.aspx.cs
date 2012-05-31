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
            Calendar1.Visible = true;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            TxtTodate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void Btncreate_Click(object sender, EventArgs e)
        {
            MovieBooking.BLL.Entities.MovieSchedule movie = new MovieBooking.BLL.Entities.MovieSchedule()
            {
                MovieID = Convert.ToInt32(this.ComboMovName.SelectedValue),
                TheatreID = Convert.ToInt32(this.ComboTheatreName.SelectedValue),
                HallID = Convert.ToInt32(this.CombohallName.SelectedValue),
                Price = Convert.ToDecimal(TxtPrice.Text),
                //FromDate = Convert.ToDateTime(this.TxtFromdate.Text),
                //ToDate = Convert.ToDateTime(this.TxtTodate.Text),
                Active = Convert.ToBoolean(this.ComboActive.SelectedValue),
           
            };
            MovieScheduleRepository newMovieSchedule = new MovieScheduleRepository();
            newMovieSchedule.Insert(movie);
            int ScheduleID = newMovieSchedule.FindbyMovieID(Convert.ToInt32(this.ComboMovName.SelectedValue));
            MovieScheduleItemRepository newScheduleItem = new MovieScheduleItemRepository();
            MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem = new MovieBooking.BLL.Entities.MovieSchedule_Item()
            {
                MovieScheduleID=ScheduleID,
                TimeSlotID=this.Combotime1.SelectedValue,
                Price=Convert.ToDecimal(TxtPrice.Text)
            };
            newScheduleItem.Insert(movieScheduleItem);
             MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem2 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
            {
                MovieScheduleID=ScheduleID,
                TimeSlotID=this.Combotime2.SelectedValue,
                Price=Convert.ToDecimal(TxtPrice.Text)
            };
            newScheduleItem.Insert(movieScheduleItem2);
             MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem3 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
            {
                MovieScheduleID=ScheduleID,
                TimeSlotID=this.Combotime3.SelectedValue,
                Price=Convert.ToDecimal(TxtPrice.Text)
            };
            newScheduleItem.Insert(movieScheduleItem3);
             MovieBooking.BLL.Entities.MovieSchedule_Item movieScheduleItem4 = new MovieBooking.BLL.Entities.MovieSchedule_Item()
            {
                MovieScheduleID=ScheduleID,
                TimeSlotID=this.Combotime4.SelectedValue,
                Price=Convert.ToDecimal(TxtPrice.Text)
            };
            newScheduleItem.Insert(movieScheduleItem4);
            
        }
   
    }
}