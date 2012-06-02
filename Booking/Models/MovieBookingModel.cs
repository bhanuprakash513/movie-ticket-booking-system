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
        [RegularExpression(@"^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "Invalid Credit Card Number")]        
        [Display(Name = "Credit Card Number")]
        public string CreditCardNum { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [RegularExpression(@"(\d{2}-\d{4})$", ErrorMessage = "Invalid Expiry Date: Eg: 02-2012'.")]
        [Display(Name = "Credit Card Expiry")]
        public string CreditCardExpiry { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Credit Card Name")]
        public string CreditCardName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(3, ErrorMessage = "Invalid CVV Number")]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
    }

}