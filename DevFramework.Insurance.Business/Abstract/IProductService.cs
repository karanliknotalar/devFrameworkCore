using System.Collections.Generic;
using System.ServiceModel;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.Abstract
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        List<Product> GetAll();
        [OperationContract]
        Product GetById(int id);
        [OperationContract]
        Product Add(Product entity);
        [OperationContract]
        Product Update(Product entity);
        [OperationContract]
        void TransactionalOperation(Product product1, Product product2);
    }
}
