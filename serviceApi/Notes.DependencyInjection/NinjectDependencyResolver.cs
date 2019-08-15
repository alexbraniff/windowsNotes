using Ninject;
using System.Web.Http.Dependencies;

namespace Notes.DependencyInjection.Ninject
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