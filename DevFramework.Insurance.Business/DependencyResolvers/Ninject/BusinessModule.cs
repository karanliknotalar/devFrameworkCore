using System.Data.Entity;
using DevFramework.Core.DataAccess;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Business.Concrete.Managers;
using DevFramework.Insurance.DataAccess.Abstract;
using DevFramework.Insurance.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Insurance.DataAccess.Concrete.NHibernate.Helpers;

namespace DevFramework.Insurance.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
            
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            
            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}