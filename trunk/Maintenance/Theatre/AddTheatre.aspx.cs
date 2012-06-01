using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MovieBooking.BLL.Entities;

namespace MovieBooking.UI.Maintenance.Theatre
{
    public partial class AddTheatre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            MovieBooking.BLL.Entities.Theatre theatre = new MovieBooking.BLL.Entities.Theatre()
            {
          
                Name = this.TheatreName.Text.ToString(),
                Address = this.TheatreAddress.Text.ToString(),
                Email = this.TheatreEmail.Text.ToString(),
                FaxNo = this.TheatreFaxNo.Text.ToString(),
                PhoneNo = this.TheatrePhoneNo.Text.ToString(),
                PostalCode = this.TheatrePostalCode.Text.ToString(),
                WebSite = this.TheatreWebSiteAddress.Text.ToString()
            };
            TheatreRepository theatreRep = new TheatreRepository();
            theatreRep.Insert(theatre);
            ErrorMessage.Text = "Updated Successfully";
            ClearAll();
            //theatre.InsertTheatre();
        }

        protected void ClearAll()
        {
            TheatreName.Text = string.Empty;
            TheatreAddress.Text = string.Empty;
            TheatreEmail.Text = string.Empty;
            TheatreFaxNo.Text = string.Empty;
            TheatrePhoneNo.Text = string.Empty;
            TheatrePostalCode.Text = string.Empty;
            TheatreWebSiteAddress.Text = string.Empty;
        }

        
    }
}