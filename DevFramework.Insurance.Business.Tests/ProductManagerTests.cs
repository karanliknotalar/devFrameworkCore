using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using DevFramework.Insurance.Business.Concrete.Managers;
using DevFramework.Insurance.DataAccess.Abstract;
using DevFramework.Insurance.Entities.Concrete;
using FluentValidation;
using Moq;

namespace DevFramework.Insurance.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            Mock<IMapper> mapper = new Mock<IMapper>();
            ProductManager productManager = new ProductManager(mock.Object, mapper.Object);

            productManager.Add(new Product());
        }
    }
}