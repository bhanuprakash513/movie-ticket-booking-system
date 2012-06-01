using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Theatre
{
    public partial class UpdateTheatre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TheatreRepository theatreRep = new TheatreRepository();
                cmbTheatreName.DataSource=theatreRep.FindAll();
                cmbTheatreName.DataBind();
                cmbTheatreName.Items.Insert(0, new ListItem() { Text = "<--Select-->", Value = "0" });
            }
        }

        protected void cmbTheatreName_SelectedIndexChanged(object sender, EventArgs e)
        {

            TheatreRepository theatreRep = new TheatreRepository();
            var theatr = theatreRep.FindById(Convert.ToInt16(cmbTheatreName.SelectedValue));

            TheatreAddress.Text = theatr.Address;
            TheatrePhoneNo.Text = theatr.PhoneNo;
            TheatrePostalCode.Text = theatr.PostalCode;
            TheatreFaxNo.Text = theatr.FaxNo;
            TheatreEmail.Text = theatr.Email;
            TheatreWebSiteAddress.Text = theatr.WebSite;
         
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            TheatreRepository theatreRep = new TheatreRepository();
            var theatr = theatreRep.FindById(Convert.ToInt16(cmbTheatreName.SelectedValue));

            theatr.Address = this.TheatreAddress.Text.ToString();
            theatr.Email = this.TheatreEmail.Text.ToString();
            theatr.FaxNo = this.TheatreFaxNo.Text.ToString();
            theatr.PhoneNo = this.TheatrePhoneNo.Text.ToString();
            theatr.PostalCode = this.TheatrePostalCode.Text.ToString();
            theatr.WebSite = this.TheatreWebSiteAddress.Text.ToString();
            theatreRep.Update(theatr);
            ErrorMessage.Text = "Updated Successfully";
            ClearAll();
         }

         protected void ClearAll()
         {
            cmbTheatreName.SelectedIndex = 0;
            TheatreAddress.Text = string.Empty;
            TheatreEmail.Text = string.Empty;
            TheatreFaxNo.Text = string.Empty;
            TheatrePhoneNo.Text = string.Empty;
            TheatrePostalCode.Text = string.Empty;
            TheatreWebSiteAddress.Text = string.Empty;
        }

      
    }
}