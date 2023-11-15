using System.Collections.Generic;
using AutoMapper;
using DevFramework.Core.Aspects.PostSharp.AuthorizationAspects;
using DevFramework.Core.Aspects.PostSharp.CacheAspects;
using DevFramework.Core.Aspects.PostSharp.ExceptionAspects;
using DevFramework.Core.Aspects.PostSharp.PerformanceAspects;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Business.ValidationRules.FluentValidation;
using DevFramework.Insurance.DataAccess.Abstract;
using DevFramework.Insurance.Entities.Concrete;
using DevFramework.Core.Aspects.PostSharp.TransactionAspects;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace DevFramework.Insurance.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(2)]
        [SecuredOperation(Roles = "Admin,Editor")]
        public List<Product> GetAll()
        {
            return _mapper.Map<List<Product>>(_productDal.GetList());
        }


        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product entity)
        {
            return _productDal.Add(entity);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product entity)
        {
            return _productDal.Update(entity);
        }

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        [ExceptionLogAspect(typeof(DatabaseLogger))]
        public void TransactionalOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);

            // her codes

            _productDal.Update(product2);
        }
    }
}