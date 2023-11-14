using System.Collections.Generic;
using System.Linq;
using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Insurance.DataAccess.Abstract;
using DevFramework.Insurance.Entities.ComplexType;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<UserRoleItem> GetUserRoles(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from userRole in context.UserRoles
                    join role in context.Roles
                        on userRole.UserId equals user.Id
                    where userRole.RoleId.Equals(role.Id)
                    select new UserRoleItem { RoleName = role.Name };
                return result.ToList();
            }
        }
    }
}