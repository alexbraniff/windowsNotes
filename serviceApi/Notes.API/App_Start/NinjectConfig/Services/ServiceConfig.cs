using Ninject;
using Ninject.Web.Common;
using Notes.Service.Implementation;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.API.App_Start.NinjectConfig
{
    public static class ServiceConfig
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
        }
    }
}