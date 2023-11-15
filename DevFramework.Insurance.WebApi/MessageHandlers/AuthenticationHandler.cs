using System;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using DevFramework.Insurance.Business.Abstract;
using DevFramework.Insurance.Business.Concrete.Managers;
using DevFramework.Insurance.Business.DependencyResolvers.Ninject;

namespace DevFramework.Insurance.WebApi.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (!string.IsNullOrEmpty(token))
                {
                    var data = Convert.FromBase64String(token);
                    var decodedString = Encoding.UTF8.GetString(data);
                    var tokenValues = decodedString.Split(':');

                    var userService = InstanceFactory.GetInstance<IUserService>();
                    var userName = tokenValues[0];
                    var password = tokenValues[1];

                    var user = userService.GetByUserNameAndPassword(userName, password);

                    if (user != null)
                    {
                        var userRoles = userService.GetUserRoles(user).Select(r => r.RoleName).ToArray();
                        var principal = new GenericPrincipal(new GenericIdentity(userName), userRoles);
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch
            {
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}