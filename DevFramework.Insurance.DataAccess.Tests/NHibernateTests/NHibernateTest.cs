using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevFramework.Insurance.DataAccess.Concrete.NHibernate;
using DevFramework.Insurance.DataAccess.Concrete.NHibernate.Helpers;

namespace DevFramework.Insurance.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTest
    {
        [TestMethod]
        public void Get_All_Returns_All_Products()
        {
            NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());

            var result = nhProductDal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void Get_All_with_parameter_Returns_filtered_products()
        {
            NhProductDal nhProductDal = new NhProductDal(new SqlServerHelper());

            var result = nhProductDal.GetList(p=>p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
