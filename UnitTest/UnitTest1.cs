using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchValidations()
        {
            ProductsManager mgr = new ProductsManager();
            string searchCriteria = "truc";
            Assert.IsTrue(mgr.ValidateSearchCriteria(searchCriteria));
        }
    }
    
}
