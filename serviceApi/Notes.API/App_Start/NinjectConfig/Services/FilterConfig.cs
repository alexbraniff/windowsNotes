using Ninject;
using Ninject.Web.Mvc.FilterBindingSyntax;
using Ninject.Web.WebApi.FilterBindingSyntax;
using Notes.API.App_Start.NinjectConfig.Modules;
using Notes.API.Attributes;
using Notes.API.Filters;
using Notes.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Notes.API.App_Start.NinjectConfig
{
    public static class FilterConfig
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IFilterProvider>().To<NinjectFilterProvider>();

            kernel.Load<HttpTokenAuthenticationModule>();

            kernel.Bind<IAuthorizationFilter>().To<HttpTokenAuthenticationFilter>();

            kernel.BindHttpFilter<HttpTokenAuthenticationFilter>(FilterScope.Controller)
                .WhenControllerHas<HttpTokenAuthenticationAttribute>()
                .WithPropertyValue("Auth", kernel.Get<IAuthenticationService>());

            kernel.BindHttpFilter<HttpTokenAuthenticationFilter>(FilterScope.Action)
                .WhenActionMethodHas<HttpTokenAuthenticationAttribute>()
                .WithPropertyValue("Auth", kernel.Get<IAuthenticationService>());

            //kernel.BindFilter<MvcTokenAuthenticationFilter>(System.Web.Mvc.FilterScope.Controller, 0)
            //    .WhenControllerHas<MvcTokenAuthenticationAttribute>();

            //kernel.BindFilter<MvcTokenAuthenticationFilter>(System.Web.Mvc.FilterScope.Action, 0)
            //    .WhenActionMethodHas<MvcTokenAuthenticationAttribute>();
        }
    }
}