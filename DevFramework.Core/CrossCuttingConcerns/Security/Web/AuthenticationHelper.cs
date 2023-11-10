using System;
using System.Text;
using System.Web;
using System.Web.Security;

namespace DevFramework.Core.CrossCuttingConcerns.Security.Web
{
    public static class AuthenticationHelper
    {
        public static void CrateAuthCookie(Identity identity, DateTime expiration, bool rememberMe)
        {
            var autTicket = new FormsAuthenticationTicket(
                1,
                identity.Name,
                DateTime.Now,
                expiration,
                rememberMe,
                CreateAutText(identity)
            );

            string encTicket = FormsAuthentication.Encrypt(autTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }

        private static string CreateAutText(Identity identity)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(identity.Email);
            stringBuilder.Append("|");
            stringBuilder.Append(string.Join(",", identity.Roles));
            stringBuilder.Append("|");
            stringBuilder.Append(identity.FirstName);
            stringBuilder.Append("|");
            stringBuilder.Append(identity.LastName);
            stringBuilder.Append("|");
            stringBuilder.Append(identity.Id);

            return stringBuilder.ToString();
        }
    }
}