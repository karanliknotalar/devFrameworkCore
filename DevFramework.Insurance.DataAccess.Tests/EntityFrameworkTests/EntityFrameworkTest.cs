using DevFramework.Insurance.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevFramework.Insurance.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_All_Returns_All_Products()
        {
            EfProductDal efProductDal = new EfProductDal();

            var result = efProductDal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_All_with_parameter_Returns_filtered_products()
        {
            EfProductDal efProductDal = new EfProductDal();

            var result = efProductDal.GetList(p=>p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
