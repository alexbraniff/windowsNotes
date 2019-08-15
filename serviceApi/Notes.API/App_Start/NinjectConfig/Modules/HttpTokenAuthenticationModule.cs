using Ninject.Modules;
using Notes.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notes.API.App_Start.NinjectConfig.Modules
{
    public class HttpTokenAuthenticationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<HttpTokenAuthenticationFilter>().To<HttpTokenAuthenticationFilter>();
        }
    }
}