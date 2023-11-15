using DevFramework.Core.Utilities.Common;
using DevFramework.Insurance.Business.Abstract;
using Ninject.Modules;

namespace DevFramework.Insurance.Business.DependencyResolvers.Ninject
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().ToConstant(WcfProxy<IProductService>.CreateChannel());
        }
    }
}