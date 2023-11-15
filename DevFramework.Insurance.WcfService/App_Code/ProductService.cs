using System.Collections.Generic;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Business.DependencyResolvers.Ninject;
using DevFramework.Insurance.Entities.Concrete;

public class ProductService : IProductService
{
    private readonly IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        _productService.TransactionalOperation(product1, product2);
    }

    public Product Update(Product entity)
    {
        return _productService.Update(entity);
    }

    public Product Add(Product entity)
    {
        return _productService.Add(entity);
    }
}