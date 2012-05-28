using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MovieBooking.MVC.UI.Models
{
    public class PaymentModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(16, ErrorMessage = "Invalid Credit Card Number")]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNum { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Credit Card Expiry")]
        public string CreditCardExpiry { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Credit Card Name")]
        public string CreditCardName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
    }

}