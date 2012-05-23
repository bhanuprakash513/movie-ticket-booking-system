//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace MovieBooking.BLL.POCOModel
{
    public partial class Entities : ObjectContext
    {
        public const string ConnectionString = "name=Entities";
        public const string ContainerName = "Entities";
    
        #region Constructors
    
        public Entities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Entities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public Entities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<aspnet_Membership> aspnet_Membership
        {
            get { return _aspnet_Membership  ?? (_aspnet_Membership = CreateObjectSet<aspnet_Membership>("aspnet_Membership")); }
        }
        private ObjectSet<aspnet_Membership> _aspnet_Membership;
    
        public ObjectSet<aspnet_Users> aspnet_Users
        {
            get { return _aspnet_Users  ?? (_aspnet_Users = CreateObjectSet<aspnet_Users>("aspnet_Users")); }
        }
        private ObjectSet<aspnet_Users> _aspnet_Users;
    
        public ObjectSet<mb_Movie> mb_Movie
        {
            get { return _mb_Movie  ?? (_mb_Movie = CreateObjectSet<mb_Movie>("mb_Movie")); }
        }
        private ObjectSet<mb_Movie> _mb_Movie;
    
        public ObjectSet<mb_Movie_Item> mb_Movie_Item
        {
            get { return _mb_Movie_Item  ?? (_mb_Movie_Item = CreateObjectSet<mb_Movie_Item>("mb_Movie_Item")); }
        }
        private ObjectSet<mb_Movie_Item> _mb_Movie_Item;
    
        public ObjectSet<mb_MovieBooking> mb_MovieBooking
        {
            get { return _mb_MovieBooking  ?? (_mb_MovieBooking = CreateObjectSet<mb_MovieBooking>("mb_MovieBooking")); }
        }
        private ObjectSet<mb_MovieBooking> _mb_MovieBooking;
    
        public ObjectSet<mb_MovieBooking_Item> mb_MovieBooking_Item
        {
            get { return _mb_MovieBooking_Item  ?? (_mb_MovieBooking_Item = CreateObjectSet<mb_MovieBooking_Item>("mb_MovieBooking_Item")); }
        }
        private ObjectSet<mb_MovieBooking_Item> _mb_MovieBooking_Item;
    
        public ObjectSet<mb_MovieBooking_Trans> mb_MovieBooking_Trans
        {
            get { return _mb_MovieBooking_Trans  ?? (_mb_MovieBooking_Trans = CreateObjectSet<mb_MovieBooking_Trans>("mb_MovieBooking_Trans")); }
        }
        private ObjectSet<mb_MovieBooking_Trans> _mb_MovieBooking_Trans;
    
        public ObjectSet<mb_MovieSchedule> mb_MovieSchedule
        {
            get { return _mb_MovieSchedule  ?? (_mb_MovieSchedule = CreateObjectSet<mb_MovieSchedule>("mb_MovieSchedule")); }
        }
        private ObjectSet<mb_MovieSchedule> _mb_MovieSchedule;
    
        public ObjectSet<mb_MovieSchedule_Item> mb_MovieSchedule_Item
        {
            get { return _mb_MovieSchedule_Item  ?? (_mb_MovieSchedule_Item = CreateObjectSet<mb_MovieSchedule_Item>("mb_MovieSchedule_Item")); }
        }
        private ObjectSet<mb_MovieSchedule_Item> _mb_MovieSchedule_Item;
    
        public ObjectSet<mb_Payment> mb_Payment
        {
            get { return _mb_Payment  ?? (_mb_Payment = CreateObjectSet<mb_Payment>("mb_Payment")); }
        }
        private ObjectSet<mb_Payment> _mb_Payment;
    
        public ObjectSet<mb_RegisteredUser> mb_RegisteredUser
        {
            get { return _mb_RegisteredUser  ?? (_mb_RegisteredUser = CreateObjectSet<mb_RegisteredUser>("mb_RegisteredUser")); }
        }
        private ObjectSet<mb_RegisteredUser> _mb_RegisteredUser;
    
        public ObjectSet<mb_SystemParameter> mb_SystemParameter
        {
            get { return _mb_SystemParameter  ?? (_mb_SystemParameter = CreateObjectSet<mb_SystemParameter>("mb_SystemParameter")); }
        }
        private ObjectSet<mb_SystemParameter> _mb_SystemParameter;
    
        public ObjectSet<mb_Theatre> mb_Theatre
        {
            get { return _mb_Theatre  ?? (_mb_Theatre = CreateObjectSet<mb_Theatre>("mb_Theatre")); }
        }
        private ObjectSet<mb_Theatre> _mb_Theatre;

        #endregion

        #region Function Imports
        public ObjectResult<RegisteredUsers_Ext> GetExtRegisteredUsers()
        {
            return base.ExecuteFunction<RegisteredUsers_Ext>("GetExtRegisteredUsers");
        }

        #endregion
    }
}