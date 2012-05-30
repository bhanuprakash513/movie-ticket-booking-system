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
    public partial class aspnet_Paths
    {
        #region Primitive Properties
    
        public virtual System.Guid ApplicationId
        {
            get { return _applicationId; }
            set
            {
                if (_applicationId != value)
                {
                    if (aspnet_Applications != null && aspnet_Applications.ApplicationId != value)
                    {
                        aspnet_Applications = null;
                    }
                    _applicationId = value;
                }
            }
        }
        private System.Guid _applicationId;
    
        public virtual System.Guid PathId
        {
            get;
            set;
        }
    
        public virtual string Path
        {
            get;
            set;
        }
    
        public virtual string LoweredPath
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual aspnet_Applications aspnet_Applications
        {
            get { return _aspnet_Applications; }
            set
            {
                if (!ReferenceEquals(_aspnet_Applications, value))
                {
                    var previousValue = _aspnet_Applications;
                    _aspnet_Applications = value;
                    Fixupaspnet_Applications(previousValue);
                }
            }
        }
        private aspnet_Applications _aspnet_Applications;
    
        public virtual aspnet_PersonalizationAllUsers aspnet_PersonalizationAllUsers
        {
            get { return _aspnet_PersonalizationAllUsers; }
            set
            {
                if (!ReferenceEquals(_aspnet_PersonalizationAllUsers, value))
                {
                    var previousValue = _aspnet_PersonalizationAllUsers;
                    _aspnet_PersonalizationAllUsers = value;
                    Fixupaspnet_PersonalizationAllUsers(previousValue);
                }
            }
        }
        private aspnet_PersonalizationAllUsers _aspnet_PersonalizationAllUsers;
    
        public virtual ICollection<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser
        {
            get
            {
                if (_aspnet_PersonalizationPerUser == null)
                {
                    var newCollection = new FixupCollection<aspnet_PersonalizationPerUser>();
                    newCollection.CollectionChanged += Fixupaspnet_PersonalizationPerUser;
                    _aspnet_PersonalizationPerUser = newCollection;
                }
                return _aspnet_PersonalizationPerUser;
            }
            set
            {
                if (!ReferenceEquals(_aspnet_PersonalizationPerUser, value))
                {
                    var previousValue = _aspnet_PersonalizationPerUser as FixupCollection<aspnet_PersonalizationPerUser>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupaspnet_PersonalizationPerUser;
                    }
                    _aspnet_PersonalizationPerUser = value;
                    var newValue = value as FixupCollection<aspnet_PersonalizationPerUser>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupaspnet_PersonalizationPerUser;
                    }
                }
            }
        }
        private ICollection<aspnet_PersonalizationPerUser> _aspnet_PersonalizationPerUser;

        #endregion
        #region Association Fixup
    
        private void Fixupaspnet_Applications(aspnet_Applications previousValue)
        {
            if (previousValue != null && previousValue.aspnet_Paths.Contains(this))
            {
                previousValue.aspnet_Paths.Remove(this);
            }
    
            if (aspnet_Applications != null)
            {
                if (!aspnet_Applications.aspnet_Paths.Contains(this))
                {
                    aspnet_Applications.aspnet_Paths.Add(this);
                }
                if (ApplicationId != aspnet_Applications.ApplicationId)
                {
                    ApplicationId = aspnet_Applications.ApplicationId;
                }
            }
        }
    
        private void Fixupaspnet_PersonalizationAllUsers(aspnet_PersonalizationAllUsers previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.aspnet_Paths, this))
            {
                previousValue.aspnet_Paths = null;
            }
    
            if (aspnet_PersonalizationAllUsers != null)
            {
                aspnet_PersonalizationAllUsers.aspnet_Paths = this;
            }
        }
    
        private void Fixupaspnet_PersonalizationPerUser(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (aspnet_PersonalizationPerUser item in e.NewItems)
                {
                    item.aspnet_Paths = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (aspnet_PersonalizationPerUser item in e.OldItems)
                {
                    if (ReferenceEquals(item.aspnet_Paths, this))
                    {
                        item.aspnet_Paths = null;
                    }
                }
            }
        }

        #endregion
    }
}
