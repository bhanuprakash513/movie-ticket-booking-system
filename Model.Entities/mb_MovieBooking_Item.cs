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
    public partial class mb_MovieBooking_Item
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> MovieBookingID
        {
            get { return _movieBookingID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_movieBookingID != value)
                    {
                        if (mb_MovieBooking != null && mb_MovieBooking.ID != value)
                        {
                            mb_MovieBooking = null;
                        }
                        _movieBookingID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _movieBookingID;
    
        public virtual string SeatNo
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
    
        public virtual ICollection<mb_MovieBooking> mb_MovieBooking1
        {
            get
            {
                if (_mb_MovieBooking1 == null)
                {
                    var newCollection = new FixupCollection<mb_MovieBooking>();
                    newCollection.CollectionChanged += Fixupmb_MovieBooking1;
                    _mb_MovieBooking1 = newCollection;
                }
                return _mb_MovieBooking1;
            }
            set
            {
                if (!ReferenceEquals(_mb_MovieBooking1, value))
                {
                    var previousValue = _mb_MovieBooking1 as FixupCollection<mb_MovieBooking>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupmb_MovieBooking1;
                    }
                    _mb_MovieBooking1 = value;
                    var newValue = value as FixupCollection<mb_MovieBooking>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupmb_MovieBooking1;
                    }
                }
            }
        }
        private ICollection<mb_MovieBooking> _mb_MovieBooking1;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixupmb_MovieBooking(mb_MovieBooking previousValue)
        {
            if (previousValue != null && previousValue.mb_MovieBooking_Item.Contains(this))
            {
                previousValue.mb_MovieBooking_Item.Remove(this);
            }
    
            if (mb_MovieBooking != null)
            {
                if (!mb_MovieBooking.mb_MovieBooking_Item.Contains(this))
                {
                    mb_MovieBooking.mb_MovieBooking_Item.Add(this);
                }
                if (MovieBookingID != mb_MovieBooking.ID)
                {
                    MovieBookingID = mb_MovieBooking.ID;
                }
            }
            else if (!_settingFK)
            {
                MovieBookingID = null;
            }
        }
    
        private void Fixupmb_MovieBooking1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (mb_MovieBooking item in e.NewItems)
                {
                    item.mb_MovieBooking_Item1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (mb_MovieBooking item in e.OldItems)
                {
                    if (ReferenceEquals(item.mb_MovieBooking_Item1, this))
                    {
                        item.mb_MovieBooking_Item1 = null;
                    }
                }
            }
        }

        #endregion
    }
}
