using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.DataAccess.Concrete.EntityFramework.Mapping
{
    class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable(@"Categories", @"dbo");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryID");
            Property(x => x.CategoryName).HasColumnName("CategoryName");
            
        }
    }
}
