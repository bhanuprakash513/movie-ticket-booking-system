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
    public partial class mb_Movie_Item
    {
        #region Primitive Properties
    
        public virtual int ID
        {
            get;
            set;
        }
    
        public virtual int MovieID
        {
            get { return _movieID; }
            set
            {
                if (_movieID != value)
                {
                    if (mb_Movie != null && mb_Movie.ID != value)
                    {
                        mb_Movie = null;
                    }
                    _movieID = value;
                }
            }
        }
        private int _movieID;
    
        public virtual string CastID
        {
            get;
            set;
        }
    
        public virtual string Description
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual mb_Movie mb_Movie
        {
            get { return _mb_Movie; }
            set
            {
                if (!ReferenceEquals(_mb_Movie, value))
                {
                    var previousValue = _mb_Movie;
                    _mb_Movie = value;
                    Fixupmb_Movie(previousValue);
                }
            }
        }
        private mb_Movie _mb_Movie;

        #endregion
        #region Association Fixup
    
        private void Fixupmb_Movie(mb_Movie previousValue)
        {
            if (previousValue != null && previousValue.mb_Movie_Item.Contains(this))
            {
                previousValue.mb_Movie_Item.Remove(this);
            }
    
            if (mb_Movie != null)
            {
                if (!mb_Movie.mb_Movie_Item.Contains(this))
                {
                    mb_Movie.mb_Movie_Item.Add(this);
                }
                if (MovieID != mb_Movie.ID)
                {
                    MovieID = mb_Movie.ID;
                }
            }
        }

        #endregion
    }
}