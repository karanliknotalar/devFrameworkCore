using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Insurance.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DevFramework.Insurance.DataAccess.Concrete.NHibernate.Mapping
{
    public class CategoryMap:ClassMap<Category>
    {

        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();
            Id(i => i.CategoryId).Column("CategoryID");
            Map(x => x.CategoryName).Column("CategoryName");

        }
    }
}
