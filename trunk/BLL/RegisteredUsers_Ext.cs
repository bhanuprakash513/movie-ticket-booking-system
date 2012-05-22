//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MovieBooking.BLL.POCOModel
{
    public partial class RegisteredUsers_Ext
    {
        #region Primitive Properties
    
        public string UserName
        {
            get;
            set;
        }
    
        public string Email
        {
            get;
            set;
        }
    
        public string PasswordQuestion
        {
            get;
            set;
        }
    
        public string Comment
        {
            get;
            set;
        }
    
        public bool IsApproved
        {
            get;
            set;
        }
    
        public System.DateTime CreateDate
        {
            get;
            set;
        }
    
        public System.DateTime LastLoginDate
        {
            get;
            set;
        }
    
        public System.DateTime LastActivityDate
        {
            get;
            set;
        }
    
        public System.DateTime LastPasswordChangedDate
        {
            get;
            set;
        }
    
        public System.Guid UserId
        {
            get;
            set;
        }
    
        public bool IsLockedOut
        {
            get;
            set;
        }
    
        public System.DateTime LastLockoutDate
        {
            get;
            set;
        }
    
        public string NRIC
        {
            get;
            set;
        }
    
        public Nullable<System.DateTime> DOB
        {
            get;
            set;
        }
    
        public string Address
        {
            get;
            set;
        }
    
        public string PostalCode
        {
            get;
            set;
        }
    
        public string BankName
        {
            get;
            set;
        }
    
        public string AccountNo
        {
            get;
            set;
        }
    
        public bool Active
        {
            get;
            set;
        }

        #endregion
    }
}