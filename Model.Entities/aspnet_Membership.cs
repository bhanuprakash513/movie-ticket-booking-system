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

namespace MovieBooking.Model.Entities
{
    public partial class aspnet_Membership
    {
        #region Primitive Properties
    
        public virtual System.Guid ApplicationId
        {
            get;
            set;
        }
    
        public virtual System.Guid UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (aspnet_Users != null && aspnet_Users.UserId != value)
                    {
                        aspnet_Users = null;
                    }
                    _userId = value;
                }
            }
        }
        private System.Guid _userId;
    
        public virtual string Password
        {
            get;
            set;
        }
    
        public virtual int PasswordFormat
        {
            get;
            set;
        }
    
        public virtual string PasswordSalt
        {
            get;
            set;
        }
    
        public virtual string MobilePIN
        {
            get;
            set;
        }
    
        public virtual string Email
        {
            get;
            set;
        }
    
        public virtual string LoweredEmail
        {
            get;
            set;
        }
    
        public virtual string PasswordQuestion
        {
            get;
            set;
        }
    
        public virtual string PasswordAnswer
        {
            get;
            set;
        }
    
        public virtual bool IsApproved
        {
            get;
            set;
        }
    
        public virtual bool IsLockedOut
        {
            get;
            set;
        }
    
        public virtual System.DateTime CreateDate
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastLoginDate
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastPasswordChangedDate
        {
            get;
            set;
        }
    
        public virtual System.DateTime LastLockoutDate
        {
            get;
            set;
        }
    
        public virtual int FailedPasswordAttemptCount
        {
            get;
            set;
        }
    
        public virtual System.DateTime FailedPasswordAttemptWindowStart
        {
            get;
            set;
        }
    
        public virtual int FailedPasswordAnswerAttemptCount
        {
            get;
            set;
        }
    
        public virtual System.DateTime FailedPasswordAnswerAttemptWindowStart
        {
            get;
            set;
        }
    
        public virtual string Comment
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual aspnet_Users aspnet_Users
        {
            get { return _aspnet_Users; }
            set
            {
                if (!ReferenceEquals(_aspnet_Users, value))
                {
                    var previousValue = _aspnet_Users;
                    _aspnet_Users = value;
                    Fixupaspnet_Users(previousValue);
                }
            }
        }
        private aspnet_Users _aspnet_Users;
    
        public virtual mb_RegisteredUser mb_RegisteredUser
        {
            get { return _mb_RegisteredUser; }
            set
            {
                if (!ReferenceEquals(_mb_RegisteredUser, value))
                {
                    var previousValue = _mb_RegisteredUser;
                    _mb_RegisteredUser = value;
                    Fixupmb_RegisteredUser(previousValue);
                }
            }
        }
        private mb_RegisteredUser _mb_RegisteredUser;

        #endregion
        #region Association Fixup
    
        private void Fixupaspnet_Users(aspnet_Users previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.aspnet_Membership, this))
            {
                previousValue.aspnet_Membership = null;
            }
    
            if (aspnet_Users != null)
            {
                aspnet_Users.aspnet_Membership = this;
                if (UserId != aspnet_Users.UserId)
                {
                    UserId = aspnet_Users.UserId;
                }
            }
        }
    
        private void Fixupmb_RegisteredUser(mb_RegisteredUser previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.aspnet_Membership, this))
            {
                previousValue.aspnet_Membership = null;
            }
    
            if (mb_RegisteredUser != null)
            {
                mb_RegisteredUser.aspnet_Membership = this;
            }
        }

        #endregion
    }
}
