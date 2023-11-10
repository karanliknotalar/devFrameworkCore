using System.Collections.Generic;
using DevFramework.Core.DataAccess;
using DevFramework.Insurance.Entities.ComplexType;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}