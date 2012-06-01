using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace MovieBooking.UI.Maintenance
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string encrypted;
            string message = "Hello World!";
            encrypted = Cryptographer.EncryptSymmetric("crpMB", message);
            //lbl1.Text = encrypted;
            string plainText;
            plainText = Cryptographer.DecryptSymmetric("crpMB", encrypted);
            //lbl2.Text = plainText;
        }
    }
}
