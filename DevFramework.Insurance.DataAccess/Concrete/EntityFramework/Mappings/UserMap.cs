using System.Data.Entity.ModelConfiguration;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.DataAccess.Concrete.EntityFramework.Mapping
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable(@"Users", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.UserName).HasColumnName("UserName");
            Property(x => x.Password).HasColumnName("Password");
            Property(x => x.Email).HasColumnName("Email");
            Property(x => x.FirstName).HasColumnName("FirstName");
            Property(x => x.LastName).HasColumnName("LastName");
        }
    }
}