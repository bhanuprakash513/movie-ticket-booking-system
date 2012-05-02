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
using System.Text;

using MovieBooking.DAL.Model;

using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Data.Objects;

namespace MovieBooking.BLL.POCOModel
{
    public partial class mb_RegisteredUser
    {
        #region Primitive Properties
    
        public virtual System.Guid UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    if (aspnet_Membership != null && aspnet_Membership.UserId != value)
                    {
                        aspnet_Membership = null;
                    }
                    _userId = value;
                }
            }
        }
        private System.Guid _userId;

        [NotNullValidator(MessageTemplate = "Cannot be null!", Ruleset = "validate_x")]
        [StringLengthValidator(19, RangeBoundaryType.Inclusive, 19, RangeBoundaryType.Inclusive, Ruleset = "validate_x")]
        [RegexValidator(@"^(S\d{9}[a-zA-Z])$", MessageTemplate = "Invalid NRIC!", Ruleset = "validate_x")]
        public virtual string NRIC
        {
            get;
            set;
        }

        [NotNullValidator(MessageTemplate = "DOB - Cannot be null!", Ruleset = "validate_x")]
        public virtual Nullable<System.DateTime> DOB
        {
            get;
            set;
        }
    
        public virtual string Address
        {
            get;
            set;
        }
    
        public virtual string PostalCode
        {
            get;
            set;
        }
    
        public virtual string BankName
        {
            get;
            set;
        }
    
        public virtual string AccountNo
        {
            get;
            set;
        }
    
        public virtual bool Active
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual aspnet_Membership aspnet_Membership
        {
            get { return _aspnet_Membership; }
            set
            {
                if (!ReferenceEquals(_aspnet_Membership, value))
                {
                    var previousValue = _aspnet_Membership;
                    _aspnet_Membership = value;
                    Fixupaspnet_Membership(previousValue);
                }
            }
        }
        private aspnet_Membership _aspnet_Membership;
    
        public virtual ICollection<mb_MovieBooking> mb_MovieBooking
        {
            get
            {
                if (_mb_MovieBooking == null)
                {
                    var newCollection = new FixupCollection<mb_MovieBooking>();
                    newCollection.CollectionChanged += Fixupmb_MovieBooking;
                    _mb_MovieBooking = newCollection;
                }
                return _mb_MovieBooking;
            }
            set
            {
                if (!ReferenceEquals(_mb_MovieBooking, value))
                {
                    var previousValue = _mb_MovieBooking as FixupCollection<mb_MovieBooking>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupmb_MovieBooking;
                    }
                    _mb_MovieBooking = value;
                    var newValue = value as FixupCollection<mb_MovieBooking>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupmb_MovieBooking;
                    }
                }
            }
        }
        private ICollection<mb_MovieBooking> _mb_MovieBooking;

        #endregion
        #region Association Fixup
    
        private void Fixupaspnet_Membership(aspnet_Membership previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.mb_RegisteredUser, this))
            {
                previousValue.mb_RegisteredUser = null;
            }
    
            if (aspnet_Membership != null)
            {
                aspnet_Membership.mb_RegisteredUser = this;
                if (UserId != aspnet_Membership.UserId)
                {
                    UserId = aspnet_Membership.UserId;
                }
            }
        }
    
        private void Fixupmb_MovieBooking(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (mb_MovieBooking item in e.NewItems)
                {
                    item.mb_RegisteredUser = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (mb_MovieBooking item in e.OldItems)
                {
                    if (ReferenceEquals(item.mb_RegisteredUser, this))
                    {
                        item.mb_RegisteredUser = null;
                    }
                }
            }
        }

        #endregion

        #region Customised Methods

        public void Insert()
        {
            // read properties for display in the page
            StringBuilder builder = new StringBuilder("<b>New Object Properties</b>:<br />");

            using (DAL.Model.Entities ctx = new DAL.Model.Entities())
            {
                var _user = new DAL.Model.mb_RegisteredUser { UserId = this.UserId,
                                DOB = null, NRIC = this.NRIC, BankName = this.BankName, AccountNo = this.AccountNo,
                                Address = this.Address, PostalCode = this.PostalCode };

                //Create a new validator using the ValidationFactory method
                Validator validator = ValidationFactory.CreateValidator<DAL.Model.mb_RegisteredUser>();
                ValidationResults results = new ValidationResults();
                validator.Validate(_user, results);
                if (results.IsValid)
                {
                    ctx.mb_RegisteredUser.AddObject(_user);
                    ctx.SaveChanges();
                }
                else
                {
                    builder.Append("<b>Validation Errors:</b>:<br />");
                    foreach (ValidationResult result in results)
                    {
                        builder.Append(String.Format("- <b>{0}</b><br />", result.Message));
                        builder.Append(String.Format("&nbsp; (Key: {0}, ", result.Key.ToString()));
                        builder.Append(String.Format("Tag: {0}, ", result.Tag));
                        builder.Append(String.Format("Target: {0})<br />", result.Target.ToString()));
                    }
                    throw new Exception(builder.ToString());
                }
            }
        }

        public static ReadOnlyCollection<RegisteredUsers_Ext> RegisteredUsers()
        {
            List<RegisteredUsers_Ext> roUsers = new List<RegisteredUsers_Ext>();
            using (DAL.Model.Entities ctx = new DAL.Model.Entities())
            {
                var users = ctx.GetExtRegisteredUsers();
                foreach(DAL.Model.RegisteredUsers_Ext ru in users)
                    roUsers.Add(new RegisteredUsers_Ext() { AccountNo = ru.AccountNo, Active = ru.Active, Address = ru.Address, 
                        BankName = ru.BankName, DOB = ru.DOB, UserId = ru.UserId, UserName = ru.UserName });
            }
            return roUsers.AsReadOnly();
        }
        
        #endregion

    }
}