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
    public partial class mb_MovieSchedule_Item
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual Nullable<int> MovieScheduleID
        {
            get { return _movieScheduleID; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_movieScheduleID != value)
                    {
                        if (mb_MovieSchedule != null && mb_MovieSchedule.ID != value)
                        {
                            mb_MovieSchedule = null;
                        }
                        _movieScheduleID = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _movieScheduleID;
    
        public virtual string TimeSlotID
        {
            get;
            set;
        }
    
        public virtual Nullable<decimal> Price
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual mb_MovieSchedule mb_MovieSchedule
        {
            get { return _mb_MovieSchedule; }
            set
            {
                if (!ReferenceEquals(_mb_MovieSchedule, value))
                {
                    var previousValue = _mb_MovieSchedule;
                    _mb_MovieSchedule = value;
                    Fixupmb_MovieSchedule(previousValue);
                }
            }
        }
        private mb_MovieSchedule _mb_MovieSchedule;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixupmb_MovieSchedule(mb_MovieSchedule previousValue)
        {
            if (previousValue != null && previousValue.mb_MovieSchedule_Item.Contains(this))
            {
                previousValue.mb_MovieSchedule_Item.Remove(this);
            }
    
            if (mb_MovieSchedule != null)
            {
                if (!mb_MovieSchedule.mb_MovieSchedule_Item.Contains(this))
                {
                    mb_MovieSchedule.mb_MovieSchedule_Item.Add(this);
                }
                if (MovieScheduleID != mb_MovieSchedule.ID)
                {
                    MovieScheduleID = mb_MovieSchedule.ID;
                }
            }
            else if (!_settingFK)
            {
                MovieScheduleID = null;
            }
        }

        #endregion
    }
}