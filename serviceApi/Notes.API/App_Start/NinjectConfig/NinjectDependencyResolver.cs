using Ninject;
using System.Web.Http.Dependencies;

namespace Notes.API.App_Start.NinjectConfig
{
    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(_kernel.BeginBlock());
        }
    }
}