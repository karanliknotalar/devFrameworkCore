using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Insurance.Business.ValidationRules.FluentValidation;
using DevFramework.Insurance.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;

namespace DevFramework.Insurance.Business.DependencyResolvers.Ninject
{
    public class ValidationModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
        }
    }
}
