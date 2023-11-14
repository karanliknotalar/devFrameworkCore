using System.Collections.Generic;
using System.Web.Http;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        public List<Product> Get()
        {
            return _service.GetAll();
        }
    }
}