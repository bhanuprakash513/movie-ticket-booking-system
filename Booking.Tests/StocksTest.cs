using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

/* -----------------------------------------------------------------
 * REVISION HISTORY
 * -----------------------------------------------------------------
 * DATE           AUTHOR          REVISION		DESCRIPTION
 * 20 May 2012    Mansoor M I     0.1			Intial version
 * 													
 * 																									
 * 													
 * 
 */

namespace MovieBooking.Tests
{
    
    
    /// <summary>
    ///This is a test class for StocksTest and is intended
    ///to contain all StocksTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StocksTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetStock
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("D:\\Projects\\MTech\\Sem1\\.NET I\\Source\\ServiceInterface", "/")]
        //[UrlToTest("http://localhost:49755/Service1.svc")]
        public void GetStockTest()
        {
            //Tests to consume basic and ws HTTP services
            using (StockService.StockServiceClient client = new StockService.StockServiceClient("BasicHttpBinding_IStockService"))
            {
                StockService.Stock expected = client.GetStock("MSFT");
                string Symbol = "MSFT"; // TODO: Initialize to an appropriate value
                StockService.Stock actual = client.GetStock(Symbol);
                Assert.AreEqual(expected.Company, actual.Company);
                //Assert.Inconclusive("Verify the correctness of this test method.");
            }

            //Tests to consume net.Tcp binding services
            using (PaymentService.PaymentServiceClient client = new PaymentService.PaymentServiceClient())
            {
                //StockService.Tcp.Stock expected = client.GetStock("MSFT");
                //string Symbol = "MSFT"; // TODO: Initialize to an appropriate value
                //StockService.Tcp.Stock actual = client.GetStock(Symbol);
                //Assert.AreEqual(expected.Company, actual.Company);
                //Assert.Inconclusive("Verify the correctness of this test method.");

                PaymentService.Payment pay = new PaymentService.Payment();
                pay.CardExpiry = "2015/05";
                pay.CardHolderName = "CardHolderName";
                pay.CCV = "1234";
                pay.CreditCardNo = "1234-5678-9012-3456";
                pay.GSTPercent = 7.5;
                pay.MovieBookingID = 1;
                pay.PaymentDate = DateTime.Now;
                pay.PaymentModeID = "01";

                int id = client.Insert(pay);

                Console.WriteLine(id);
            }
        }
    }
}
