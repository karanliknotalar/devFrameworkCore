using System.Collections.Generic;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Business.DependencyResolvers.Ninject;
using DevFramework.Insurance.Business.ServiceContracts.Wcf;
using DevFramework.Insurance.Entities.Concrete;

public class ProductDetailService : IProductDetailService
{
    private readonly IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }
}