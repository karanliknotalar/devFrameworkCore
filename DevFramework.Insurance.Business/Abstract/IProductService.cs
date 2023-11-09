using System.Collections.Generic;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product entity);
        Product Update(Product entity);
        void TransactionalOperation(Product product1, Product product2);
    }
}
