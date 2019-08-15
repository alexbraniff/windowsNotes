using Ninject;
using Ninject.Web.Common;
using Notes.Data.Implementation;
using Notes.Data.Infrastructure;
using System;
using System.Web;
using System.Web.Http;

namespace Notes.API.App_Start.NinjectConfig
{
    public class IocConfig
    {
        public static IKernel RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC
            //kernel.Load(Assembly.GetExecutingAssembly()); //only required for asp.net mvc (not for webapi)
            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            NinjectFilterProvider filterProvider = new NinjectFilterProvider(kernel);

            RegisterServices(kernel);

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDbContext>().To<NotesContext>().InTransientScope();

            RepositoryConfig.Register(kernel);
            ServiceConfig.Register(kernel);
            ControllerConfig.Register(kernel);
            FilterConfig.Register(kernel);
        }
    }
}