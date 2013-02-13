 using Wedding.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;

namespace Wedding.Tests
{
    
    
    /// <summary>
    ///This is a test class for PostTest and is intended
    ///to contain all PostTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PostTest
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
        ///A test for TagString
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Simon\\Documents\\Visual Studio 2010\\Projects\\Wedding\\Wedding", "/")]
        [UrlToTest("http://localhost:51894/")]
        public void TagStringTest()
        {
            Post target = new Post(); // TODO: Initialize to an appropriate value
            string actual;
            target.TagString = "these, are;my|  tags";

            Assert.AreEqual(target.Tags.Count, 4);
            Assert.AreEqual(target.Tags[0], "these");
            Assert.AreEqual(target.Tags[0], "are");
            Assert.AreEqual(target.Tags[0], "my");
            Assert.AreEqual(target.Tags[0], "tags");
        }
    }
}
