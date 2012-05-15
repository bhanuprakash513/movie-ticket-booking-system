﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace MovieBooking.DAL.Entities
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities() : base("name=Entities", "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string connectionString) : base(connectionString, "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(EntityConnection connection) : base(connection, "Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<RegisteredUser> RegisteredUsers
        {
            get
            {
                if ((_RegisteredUsers == null))
                {
                    _RegisteredUsers = base.CreateObjectSet<RegisteredUser>("RegisteredUsers");
                }
                return _RegisteredUsers;
            }
        }
        private ObjectSet<RegisteredUser> _RegisteredUsers;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the RegisteredUsers EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToRegisteredUsers(RegisteredUser registeredUser)
        {
            base.AddObject("RegisteredUsers", registeredUser);
        }

        #endregion
        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectResult<P_MB_GetRegisteredUsers_Result> GetRegisteredUsers()
        {
            return base.ExecuteFunction<P_MB_GetRegisteredUsers_Result>("GetRegisteredUsers");
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MovieBooking.Model", Name="RegisteredUser")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class RegisteredUser : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new RegisteredUser object.
        /// </summary>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="nRIC">Initial value of the NRIC property.</param>
        /// <param name="isDeleted">Initial value of the IsDeleted property.</param>
        public static RegisteredUser CreateRegisteredUser(global::System.Guid userId, global::System.String nRIC, global::System.Boolean isDeleted)
        {
            RegisteredUser registeredUser = new RegisteredUser();
            registeredUser.UserId = userId;
            registeredUser.NRIC = nRIC;
            registeredUser.IsDeleted = isDeleted;
            return registeredUser;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NRIC
        {
            get
            {
                return _NRIC;
            }
            set
            {
                OnNRICChanging(value);
                ReportPropertyChanging("NRIC");
                _NRIC = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NRIC");
                OnNRICChanged();
            }
        }
        private global::System.String _NRIC;
        partial void OnNRICChanging(global::System.String value);
        partial void OnNRICChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                OnDOBChanging(value);
                ReportPropertyChanging("DOB");
                _DOB = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DOB");
                OnDOBChanged();
            }
        }
        private Nullable<global::System.DateTime> _DOB;
        partial void OnDOBChanging(Nullable<global::System.DateTime> value);
        partial void OnDOBChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                OnIsDeletedChanging(value);
                ReportPropertyChanging("IsDeleted");
                _IsDeleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsDeleted");
                OnIsDeletedChanged();
            }
        }
        private global::System.Boolean _IsDeleted;
        partial void OnIsDeletedChanging(global::System.Boolean value);
        partial void OnIsDeletedChanged();

        #endregion
    
    }

    #endregion
    #region ComplexTypes
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="MovieBooking.Model", Name="GetRegisteredUsers_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class GetRegisteredUsers_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new GetRegisteredUsers_Result object.
        /// </summary>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="isApproved">Initial value of the IsApproved property.</param>
        /// <param name="createDate">Initial value of the CreateDate property.</param>
        /// <param name="lastLoginDate">Initial value of the LastLoginDate property.</param>
        /// <param name="lastActivityDate">Initial value of the LastActivityDate property.</param>
        /// <param name="lastPasswordChangedDate">Initial value of the LastPasswordChangedDate property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="isLockedOut">Initial value of the IsLockedOut property.</param>
        /// <param name="lastLockoutDate">Initial value of the LastLockoutDate property.</param>
        /// <param name="nRIC">Initial value of the NRIC property.</param>
        /// <param name="isDeleted">Initial value of the IsDeleted property.</param>
        public static GetRegisteredUsers_Result CreateGetRegisteredUsers_Result(global::System.String userName, global::System.Boolean isApproved, global::System.DateTime createDate, global::System.DateTime lastLoginDate, global::System.DateTime lastActivityDate, global::System.DateTime lastPasswordChangedDate, global::System.Guid userId, global::System.Boolean isLockedOut, global::System.DateTime lastLockoutDate, global::System.String nRIC, global::System.Boolean isDeleted)
        {
            GetRegisteredUsers_Result getRegisteredUsers_Result = new GetRegisteredUsers_Result();
            getRegisteredUsers_Result.UserName = userName;
            getRegisteredUsers_Result.IsApproved = isApproved;
            getRegisteredUsers_Result.CreateDate = createDate;
            getRegisteredUsers_Result.LastLoginDate = lastLoginDate;
            getRegisteredUsers_Result.LastActivityDate = lastActivityDate;
            getRegisteredUsers_Result.LastPasswordChangedDate = lastPasswordChangedDate;
            getRegisteredUsers_Result.UserId = userId;
            getRegisteredUsers_Result.IsLockedOut = isLockedOut;
            getRegisteredUsers_Result.LastLockoutDate = lastLockoutDate;
            getRegisteredUsers_Result.NRIC = nRIC;
            getRegisteredUsers_Result.IsDeleted = isDeleted;
            return getRegisteredUsers_Result;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PasswordQuestion
        {
            get
            {
                return _PasswordQuestion;
            }
            set
            {
                OnPasswordQuestionChanging(value);
                ReportPropertyChanging("PasswordQuestion");
                _PasswordQuestion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PasswordQuestion");
                OnPasswordQuestionChanged();
            }
        }
        private global::System.String _PasswordQuestion;
        partial void OnPasswordQuestionChanging(global::System.String value);
        partial void OnPasswordQuestionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }
        private global::System.String _Comment;
        partial void OnCommentChanging(global::System.String value);
        partial void OnCommentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                OnIsApprovedChanging(value);
                ReportPropertyChanging("IsApproved");
                _IsApproved = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsApproved");
                OnIsApprovedChanged();
            }
        }
        private global::System.Boolean _IsApproved;
        partial void OnIsApprovedChanging(global::System.Boolean value);
        partial void OnIsApprovedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                OnCreateDateChanging(value);
                ReportPropertyChanging("CreateDate");
                _CreateDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreateDate");
                OnCreateDateChanged();
            }
        }
        private global::System.DateTime _CreateDate;
        partial void OnCreateDateChanging(global::System.DateTime value);
        partial void OnCreateDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private global::System.DateTime _LastLoginDate;
        partial void OnLastLoginDateChanging(global::System.DateTime value);
        partial void OnLastLoginDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastActivityDate
        {
            get
            {
                return _LastActivityDate;
            }
            set
            {
                OnLastActivityDateChanging(value);
                ReportPropertyChanging("LastActivityDate");
                _LastActivityDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastActivityDate");
                OnLastActivityDateChanged();
            }
        }
        private global::System.DateTime _LastActivityDate;
        partial void OnLastActivityDateChanging(global::System.DateTime value);
        partial void OnLastActivityDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastPasswordChangedDate
        {
            get
            {
                return _LastPasswordChangedDate;
            }
            set
            {
                OnLastPasswordChangedDateChanging(value);
                ReportPropertyChanging("LastPasswordChangedDate");
                _LastPasswordChangedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastPasswordChangedDate");
                OnLastPasswordChangedDateChanged();
            }
        }
        private global::System.DateTime _LastPasswordChangedDate;
        partial void OnLastPasswordChangedDateChanging(global::System.DateTime value);
        partial void OnLastPasswordChangedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsLockedOut
        {
            get
            {
                return _IsLockedOut;
            }
            set
            {
                OnIsLockedOutChanging(value);
                ReportPropertyChanging("IsLockedOut");
                _IsLockedOut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsLockedOut");
                OnIsLockedOutChanged();
            }
        }
        private global::System.Boolean _IsLockedOut;
        partial void OnIsLockedOutChanging(global::System.Boolean value);
        partial void OnIsLockedOutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLockoutDate
        {
            get
            {
                return _LastLockoutDate;
            }
            set
            {
                OnLastLockoutDateChanging(value);
                ReportPropertyChanging("LastLockoutDate");
                _LastLockoutDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLockoutDate");
                OnLastLockoutDateChanged();
            }
        }
        private global::System.DateTime _LastLockoutDate;
        partial void OnLastLockoutDateChanging(global::System.DateTime value);
        partial void OnLastLockoutDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NRIC
        {
            get
            {
                return _NRIC;
            }
            set
            {
                OnNRICChanging(value);
                ReportPropertyChanging("NRIC");
                _NRIC = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NRIC");
                OnNRICChanged();
            }
        }
        private global::System.String _NRIC;
        partial void OnNRICChanging(global::System.String value);
        partial void OnNRICChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                OnDOBChanging(value);
                ReportPropertyChanging("DOB");
                _DOB = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DOB");
                OnDOBChanged();
            }
        }
        private Nullable<global::System.DateTime> _DOB;
        partial void OnDOBChanging(Nullable<global::System.DateTime> value);
        partial void OnDOBChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                OnIsDeletedChanging(value);
                ReportPropertyChanging("IsDeleted");
                _IsDeleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsDeleted");
                OnIsDeletedChanged();
            }
        }
        private global::System.Boolean _IsDeleted;
        partial void OnIsDeletedChanging(global::System.Boolean value);
        partial void OnIsDeletedChanged();

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="MovieBooking.Model", Name="P_MB_GetRegisteredUsers_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class P_MB_GetRegisteredUsers_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new P_MB_GetRegisteredUsers_Result object.
        /// </summary>
        /// <param name="userName">Initial value of the UserName property.</param>
        /// <param name="isApproved">Initial value of the IsApproved property.</param>
        /// <param name="createDate">Initial value of the CreateDate property.</param>
        /// <param name="lastLoginDate">Initial value of the LastLoginDate property.</param>
        /// <param name="lastActivityDate">Initial value of the LastActivityDate property.</param>
        /// <param name="lastPasswordChangedDate">Initial value of the LastPasswordChangedDate property.</param>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="isLockedOut">Initial value of the IsLockedOut property.</param>
        /// <param name="lastLockoutDate">Initial value of the LastLockoutDate property.</param>
        /// <param name="nRIC">Initial value of the NRIC property.</param>
        /// <param name="isDeleted">Initial value of the IsDeleted property.</param>
        public static P_MB_GetRegisteredUsers_Result CreateP_MB_GetRegisteredUsers_Result(global::System.String userName, global::System.Boolean isApproved, global::System.DateTime createDate, global::System.DateTime lastLoginDate, global::System.DateTime lastActivityDate, global::System.DateTime lastPasswordChangedDate, global::System.Guid userId, global::System.Boolean isLockedOut, global::System.DateTime lastLockoutDate, global::System.String nRIC, global::System.Boolean isDeleted)
        {
            P_MB_GetRegisteredUsers_Result p_MB_GetRegisteredUsers_Result = new P_MB_GetRegisteredUsers_Result();
            p_MB_GetRegisteredUsers_Result.UserName = userName;
            p_MB_GetRegisteredUsers_Result.IsApproved = isApproved;
            p_MB_GetRegisteredUsers_Result.CreateDate = createDate;
            p_MB_GetRegisteredUsers_Result.LastLoginDate = lastLoginDate;
            p_MB_GetRegisteredUsers_Result.LastActivityDate = lastActivityDate;
            p_MB_GetRegisteredUsers_Result.LastPasswordChangedDate = lastPasswordChangedDate;
            p_MB_GetRegisteredUsers_Result.UserId = userId;
            p_MB_GetRegisteredUsers_Result.IsLockedOut = isLockedOut;
            p_MB_GetRegisteredUsers_Result.LastLockoutDate = lastLockoutDate;
            p_MB_GetRegisteredUsers_Result.NRIC = nRIC;
            p_MB_GetRegisteredUsers_Result.IsDeleted = isDeleted;
            return p_MB_GetRegisteredUsers_Result;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PasswordQuestion
        {
            get
            {
                return _PasswordQuestion;
            }
            set
            {
                OnPasswordQuestionChanging(value);
                ReportPropertyChanging("PasswordQuestion");
                _PasswordQuestion = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PasswordQuestion");
                OnPasswordQuestionChanged();
            }
        }
        private global::System.String _PasswordQuestion;
        partial void OnPasswordQuestionChanging(global::System.String value);
        partial void OnPasswordQuestionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                OnCommentChanging(value);
                ReportPropertyChanging("Comment");
                _Comment = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Comment");
                OnCommentChanged();
            }
        }
        private global::System.String _Comment;
        partial void OnCommentChanging(global::System.String value);
        partial void OnCommentChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                OnIsApprovedChanging(value);
                ReportPropertyChanging("IsApproved");
                _IsApproved = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsApproved");
                OnIsApprovedChanged();
            }
        }
        private global::System.Boolean _IsApproved;
        partial void OnIsApprovedChanging(global::System.Boolean value);
        partial void OnIsApprovedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                OnCreateDateChanging(value);
                ReportPropertyChanging("CreateDate");
                _CreateDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreateDate");
                OnCreateDateChanged();
            }
        }
        private global::System.DateTime _CreateDate;
        partial void OnCreateDateChanging(global::System.DateTime value);
        partial void OnCreateDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private global::System.DateTime _LastLoginDate;
        partial void OnLastLoginDateChanging(global::System.DateTime value);
        partial void OnLastLoginDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastActivityDate
        {
            get
            {
                return _LastActivityDate;
            }
            set
            {
                OnLastActivityDateChanging(value);
                ReportPropertyChanging("LastActivityDate");
                _LastActivityDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastActivityDate");
                OnLastActivityDateChanged();
            }
        }
        private global::System.DateTime _LastActivityDate;
        partial void OnLastActivityDateChanging(global::System.DateTime value);
        partial void OnLastActivityDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastPasswordChangedDate
        {
            get
            {
                return _LastPasswordChangedDate;
            }
            set
            {
                OnLastPasswordChangedDateChanging(value);
                ReportPropertyChanging("LastPasswordChangedDate");
                _LastPasswordChangedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastPasswordChangedDate");
                OnLastPasswordChangedDateChanged();
            }
        }
        private global::System.DateTime _LastPasswordChangedDate;
        partial void OnLastPasswordChangedDateChanging(global::System.DateTime value);
        partial void OnLastPasswordChangedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.Guid _UserId;
        partial void OnUserIdChanging(global::System.Guid value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsLockedOut
        {
            get
            {
                return _IsLockedOut;
            }
            set
            {
                OnIsLockedOutChanging(value);
                ReportPropertyChanging("IsLockedOut");
                _IsLockedOut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsLockedOut");
                OnIsLockedOutChanged();
            }
        }
        private global::System.Boolean _IsLockedOut;
        partial void OnIsLockedOutChanging(global::System.Boolean value);
        partial void OnIsLockedOutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime LastLockoutDate
        {
            get
            {
                return _LastLockoutDate;
            }
            set
            {
                OnLastLockoutDateChanging(value);
                ReportPropertyChanging("LastLockoutDate");
                _LastLockoutDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLockoutDate");
                OnLastLockoutDateChanged();
            }
        }
        private global::System.DateTime _LastLockoutDate;
        partial void OnLastLockoutDateChanging(global::System.DateTime value);
        partial void OnLastLockoutDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NRIC
        {
            get
            {
                return _NRIC;
            }
            set
            {
                OnNRICChanging(value);
                ReportPropertyChanging("NRIC");
                _NRIC = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NRIC");
                OnNRICChanged();
            }
        }
        private global::System.String _NRIC;
        partial void OnNRICChanging(global::System.String value);
        partial void OnNRICChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                OnDOBChanging(value);
                ReportPropertyChanging("DOB");
                _DOB = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DOB");
                OnDOBChanged();
            }
        }
        private Nullable<global::System.DateTime> _DOB;
        partial void OnDOBChanging(Nullable<global::System.DateTime> value);
        partial void OnDOBChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsDeleted
        {
            get
            {
                return _IsDeleted;
            }
            set
            {
                OnIsDeletedChanging(value);
                ReportPropertyChanging("IsDeleted");
                _IsDeleted = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsDeleted");
                OnIsDeletedChanged();
            }
        }
        private global::System.Boolean _IsDeleted;
        partial void OnIsDeletedChanging(global::System.Boolean value);
        partial void OnIsDeletedChanged();

        #endregion
    }

    #endregion
    
}