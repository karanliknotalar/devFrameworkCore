using System.Collections.Generic;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.DataAccess.Abstract;
using DevFramework.Insurance.Entities.ComplexType;
using DevFramework.Insurance.Entities.Concrete;

namespace DevFramework.Insurance.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id.Equals(id));
        }

        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName.Equals(userName) & u.Password.Equals(password));
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }

        public User Add(User entity)
        {
            return _userDal.Add(entity);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }

        public void Delete(User entity)
        {
            _userDal.Remove(entity);
        }
    }
}