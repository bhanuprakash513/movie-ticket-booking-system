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


                //using (StockService.StockServiceClient ss = new StockService.StockServiceClient("WSHttpBinding_IStockService"))
                //{
                //   StockService.Stock  s = ss.GetStock("GOOG");
                   
                //}

                //using (PaymentService.PaymentServiceClient pay = new PaymentService.PaymentServiceClient())
                //{
                //    PaymentService.Payment pt = new PaymentService.Payment();
                //    pt.CardExpiry = "2012-05";
                //    pt.CardHolderName = "CardHolderName";
                //    pt.CCV="123";
                //    pt.CreditCardNo="1234-5678-9012-3456";
                //    pt.GSTPercent = 7.5;
                //    pt.MovieBookingID = 1;
                //    pt.PaymentDate = DateTime.Now;
                //    pt.TotalAmount = 100.75m;

                //    int pId = pay.Insert(pt);
                //    Console.WriteLine(pId);
                //}
                
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
            ClearAll();
            DispAll();
        }

        protected void ClearAll()
        {
            //cmbTheatreName.SelectedIndex = 0;
            HallName.Text = string.Empty;
            TotalSeats.Text = string.Empty;
        }

        protected void cmbTheatreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DispAll();
        }

        protected void DispAll()
        {
            HallRepository hallRep = new HallRepository();
            HallListService.HallListServiceClient HallList = new HallListService.HallListServiceClient("BasicHttpBinding_IHallListService");
            gvHall.DataSource = HallList.GetHallList(Convert.ToInt32(cmbTheatreName.SelectedValue));
            //gvHall.DataSource = hallRep.FindAll(Convert.ToInt32(cmbTheatreName.SelectedValue));
            gvHall.DataBind();
        }
    }
}