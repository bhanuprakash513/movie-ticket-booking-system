using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Hall
{
    public partial class UpdateHall : System.Web.UI.Page
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

        protected void cmbTheatreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            HallRepository hallRep = new HallRepository();
            //foreach(MovieBooking.BLL.Entities.Hall h in hallRep.FindByTheatreId(Convert.ToInt32(cmbTheatreName.SelectedValue)))
              //  cmbHallName.Items.Add( new ListItem() { Text = h.HallName, Value = h.ID.ToString() });
            cmbHallName.DataSource = hallRep.FindByTheatreId(Convert.ToInt32(cmbTheatreName.SelectedValue));
            cmbHallName.DataTextField = "HallName";
            cmbHallName.DataValueField = "ID";
            cmbHallName.DataBind();
            cmbHallName.Items.Insert(0, new ListItem() { Text = "<--Select-->", Value = "0" });
        }

        protected void cmbHallName_SelectedIndexChanged(object sender, EventArgs e)
        {
            HallRepository hallRep = new HallRepository();
            var hal = hallRep.FindById(Convert.ToInt16(cmbHallName.SelectedValue));

            HallName.Text = hal.HallName;
            TotalSeats.Text = hal.TotalSeats.ToString();
            cmbHallStatus.SelectedValue = hal.Active.ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            HallRepository hallRep = new HallRepository();
            var hal = hallRep.FindById(Convert.ToInt16(cmbHallName.SelectedValue));

            hal.HallName = this.HallName.Text.ToString();
            hal.TotalSeats = Convert.ToInt32(this.TotalSeats.Text.ToString());
            hal.Active = bool.Parse(this.cmbHallStatus.SelectedValue.ToString());
            hallRep.Update(hal);
            ErrorMessage.Text = "Updated Successfully";
            ClearAll();
        }

        protected void ClearAll()
        {
            cmbTheatreName.SelectedIndex = 0;
            cmbHallName.SelectedIndex = 0;
            HallName.Text = string.Empty;
            TotalSeats.Text = string.Empty;
        }
      
    }
}