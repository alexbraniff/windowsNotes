using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Notes.API.App_Start.NinjectConfig
{
    public class NinjectFilterProvider : IFilterProvider
    {
        private readonly IKernel Kernel;

        public NinjectFilterProvider(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            IEnumerable<Type> filters = AppDomain.CurrentDomain.GetAssemblies().SelectMany(t => t.GetTypes()).Where(t => typeof(IFilter).IsAssignableFrom(t) && t.IsClass && t.Namespace == "Notes.API.Filters");
            foreach (var filterType in filters)
            {
                yield return new FilterInfo(
                        (IFilter)Kernel.Get(filterType),
                        FilterScope.Action
                    );
            }
        }
    }
}