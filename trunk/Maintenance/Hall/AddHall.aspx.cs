using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Hall
{
    public partial class AddHall : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                TheatreRepository theatreRep = new TheatreRepository();
                cmbTheatreName.DataSource = theatreRep.FindAll();
                cmbTheatreName.DataBind();
                cmbTheatreName.Items.Insert(0, new ListItem() { Text = "<--Select-->", Value = "0" });
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            MovieBooking.BLL.Entities.Hall hall = new MovieBooking.BLL.Entities.Hall()
            {
                TheatreID = Convert.ToInt32(this.cmbTheatreName.SelectedItem.Value),
                HallName=this.HallName.Text.ToString(),
                TotalSeats= Convert.ToInt32(this.TotalSeats.Text),
                Active= bool.Parse(this.cmbHallStatus.SelectedValue.ToString())
            };
            HallRepository hallRep = new HallRepository();
            hallRep.Insert(hall);
            ErrorMessage.Text = "Updated Successfully";  
        }
    }
}