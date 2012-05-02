using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using System.Data.Objects;

using Microsoft.Practices.EnterpriseLibrary.Common;

using MovieBooking.DAL.Model;

using MovieBooking.SystemFrameworks;
using Microsoft.Practices.EnterpriseLibrary.Caching;

namespace MovieBooking.SystemFrameworks
{
    public static class SystemFrameworks
    {
        public static ReadOnlyCollection<mb_SystemParameter> GetSystemParameters(string category)
        {
            ICacheManager cache = CacheFactory.GetCacheManager();
            string cacheName = string.Format("SystemParam-{0}", category);
            List<mb_SystemParameter> roParams = new List<mb_SystemParameter>();

            if (cache.Contains(cacheName))
            {
                roParams = cache.GetData(cacheName) as List<mb_SystemParameter>;
            }
            else
            {
                List<mb_SystemParameter> roUsers = new List<mb_SystemParameter>();
                using (Entities ctx = new Entities())
                {
                    foreach (mb_SystemParameter ps in ctx.GetSystemParams())
                    {
                        roParams.Add(new MovieBooking.);
                    }
                }
                //
                cache.Add(cacheName, roParams);
            }
            return roParams.AsReadOnly();
        }
    }
}
