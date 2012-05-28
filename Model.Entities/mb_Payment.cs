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
using System.Runtime.Serialization;

namespace MovieBooking.Model.Entities
{
    [DataContract]
    public partial class mb_Payment
    {
        #region Primitive Properties
        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }

        [DataMember]
        public virtual int MovieBookingID
        {
            get { return _movieBookingID; }
            set
            {
                if (_movieBookingID != value)
                {
                    if (mb_MovieBooking != null && mb_MovieBooking.ID != value)
                    {
                        mb_MovieBooking = null;
                    }
                    _movieBookingID = value;
                }
            }
        }
        private int _movieBookingID;

        [DataMember]
        public virtual string PaymentModeID
        {
            get;
            set;
        }

        [DataMember]
        public virtual System.DateTime PaymentDate
        {
            get;
            set;
        }

        [DataMember]
        public virtual string CreditCardNo
        {
            get;
            set;
        }

        [DataMember]
        public virtual string CardExpiry
        {
            get;
            set;
        }

        [DataMember]
        public virtual string CardHolderName
        {
            get;
            set;
        }

        [DataMember]
        public virtual string CCV
        {
            get;
            set;
        }

        [DataMember]
        public virtual decimal TotalAmount
        {
            get;
            set;
        }

        [DataMember]
        public virtual double GSTPercent
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual mb_MovieBooking mb_MovieBooking
        {
            get { return _mb_MovieBooking; }
            set
            {
                if (!ReferenceEquals(_mb_MovieBooking, value))
                {
                    var previousValue = _mb_MovieBooking;
                    _mb_MovieBooking = value;
                    Fixupmb_MovieBooking(previousValue);
                }
            }
        }
        private mb_MovieBooking _mb_MovieBooking;

        #endregion
        #region Association Fixup
    
        private void Fixupmb_MovieBooking(mb_MovieBooking previousValue)
        {
            if (previousValue != null && previousValue.mb_Payment.Contains(this))
            {
                previousValue.mb_Payment.Remove(this);
            }
    
            if (mb_MovieBooking != null)
            {
                if (!mb_MovieBooking.mb_Payment.Contains(this))
                {
                    mb_MovieBooking.mb_Payment.Add(this);
                }
                if (MovieBookingID != mb_MovieBooking.ID)
                {
                    MovieBookingID = mb_MovieBooking.ID;
                }
            }
        }

        #endregion
    }
}
