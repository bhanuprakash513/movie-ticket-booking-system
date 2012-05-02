using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MovieBooking.MVC.UI.Models
{

    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^(s|t)[0-9]{7}[a-jz]{1}$", ErrorMessage = "Invalid NRIC! e.g. S1234567A")]
        [StringLength(9, ErrorMessage = "NRIC must be 9 characters long. e.g. S1234567A", MinimumLength = 9)]
        [Display(Name = "NRIC")]
        public string NRIC { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        [RegularExpression(@"^([1-9]|0[1-9]|[12][0-9]|3[01])[- /.]([1-9]|0[1-9]|1[012])[- /.][0-9]{4}$", ErrorMessage = "Valid Formats are: 'dd/MM/yyyy', 'dd-MM-yyyy', 'dd.MM.yyyy'")]
        [StringLength(11, ErrorMessage = "Invalid DOB!. Valid Formats are: 'dd/MM/yyyy', 'dd-MM-yyyy', 'dd.MM.yyyy'. ")]
        public string DOB { get; set; }

        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [RegularExpression(@"(\d{3}-\d{6}-\d{1})$", ErrorMessage = "Invalid Account No!. e.g: '012-345678-9'.")]
        [Display(Name = "Account No")]
        [StringLength(12, ErrorMessage = "Account Numbers must be 12 characters long. e.g: '012-345678-9'. ", MinimumLength = 12)]
        public string AccountNo { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage="Invalid Postal Code.")]
        [Display(Name = "Postal Code")]
        [StringLength(6, ErrorMessage = "Postal Code must be 6 characters long.", MinimumLength = 6)]
        public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
