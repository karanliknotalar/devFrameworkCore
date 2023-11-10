using System.Web.Mvc;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Entities.Concrete;
using DevFramework.Insurance.MvcWebUI.Models;

namespace DevFramework.Insurance.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll(),
            };
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "DemoProductName",
                UnitPrice = 25,
                QuantityPerUnit = "1",
                UnitsInStock = 5
            });
            return "added";
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(new Product
                {
                    CategoryId = 1,
                    ProductName = "DemoProductName",
                    UnitPrice = 2,
                    QuantityPerUnit = "1",
                    UnitsInStock = 5
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "DemoProductName",
                    UnitPrice = 25,
                    QuantityPerUnit = "1",
                    UnitsInStock = 5
                });
            return "updated";
        }
    }
}