using Ninject;
using Ninject.Web.Common;
using Notes.API.Areas.api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

namespace Notes.API.App_Start.NinjectConfig
{
    public static class ControllerConfig
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IHttpController>().To<AuthenticationController>().InRequestScope().Named("Authentication");
            kernel.Bind<IHttpController>().To<NoteController>().InRequestScope().Named("Note");
        }
    }
}