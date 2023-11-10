using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using DevFramework.Core.Utilities.Mvc.Infrastructure;
using DevFramework.Insurance.Business.DependencyResolvers.Ninject;

namespace DevFramework.Insurance.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += OnPostAuthenticateRequest;
            base.Init();
        }

        private void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie is null)
                {
                    return;
                }

                var encryptTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encryptTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encryptTicket);
                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var principle = new GenericPrincipal(identity, identity.Roles);
                HttpContext.Current.User = principle;
                Thread.CurrentPrincipal = principle;
            }
            catch (Exception)
            {
            }
        }
    }
}