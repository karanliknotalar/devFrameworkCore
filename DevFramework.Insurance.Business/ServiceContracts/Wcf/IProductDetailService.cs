using System.Collections.Generic;
using System.ServiceModel;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.ServiceContracts.Wcf
{
    [ServiceContract]
    public interface IProductDetailService
    {
        [OperationContract]
        List<Product> GetAll();
    }
}