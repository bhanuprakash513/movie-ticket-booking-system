using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MovieBooking.SI.Web
{
    public class StockService : IStockService
    {
        #region IStock Members
        public Stock GetStock(string Symbol)
        {
            Stock st = null;
            switch (Symbol.ToUpper())
            {
                case "GOOG":
                    st = new Stock
                    {
                        Symbol = Symbol,
                        Date = DateTime.Now,
                        Company = "Google Inc.",
                        Close = 495
                    };
                    break;
                case "MSFT":
                    st = new Stock
                    {
                        Symbol = Symbol,
                        Date = DateTime.Now,
                        Company = "Microsoft Corporation",
                        Close = 25
                    };
                    break;
                case "YHOO":
                    st = new Stock
                    {
                        Symbol = Symbol,
                        Date = DateTime.Now,
                        Company = "Yahoo! Inc.",
                        Close = 17
                    };
                    break;
                case "AMZN":
                    st = new Stock
                    {
                        Symbol = Symbol,
                        Date = DateTime.Now,
                        Company = "Amazon.com, Inc.",
                        Close = 92
                    };
                    break;
            }
            return st;
        }
        #endregion
    }
}
