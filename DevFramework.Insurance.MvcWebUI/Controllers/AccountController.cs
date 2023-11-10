using System;
using System.Linq;
using System.Web.Mvc;
using DevFramework.Core.CrossCuttingConcerns.Security;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Insurance.Business.Abstract;

namespace DevFramework.Insurance.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public string Login(string userName, string password)
        {
            var user = _userService.GetByUserNameAndPassword(userName, password);

            if (user is null) return "User not found. Not Authenticated!";

            AuthenticationHelper.CrateAuthCookie(new Identity()
            {
                Id = new Guid(),
                Name = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Roles = _userService.GetUserRoles(user).Select(r => r.RoleName).ToArray(),
                AuthenticationType = "Forms",
                IsAuthenticated = true
            }, DateTime.Now.AddMinutes(5), true);
            foreach (var role in _userService.GetUserRoles(user).Select(r => r.RoleName).ToArray())
            {
                Console.WriteLine("Role: " + role);
            }
            Console.WriteLine("UserId: " + user.Id);
            return $"User is authenticated by {user.UserName}";
        }
    }
}