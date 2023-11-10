using System.Collections.Generic;
using DevFramework.Insurance.Entities.ComplexType;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByUserNameAndPassword(string userName, string password);
        List<UserRoleItem> GetUserRoles(User user);
        User Add(User entity);
        User Update(User entity);
        void Delete(User entity);
    }
}