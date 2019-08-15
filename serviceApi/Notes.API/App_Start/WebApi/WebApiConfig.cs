using Notes.API.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Notes.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterGlobalFilters(config);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Default Api",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^\d*$" }
            );
        }

        private static void RegisterGlobalFilters(HttpConfiguration config)
        {
            //config.Filters.Add(new HttpTokenAuthenticationFilter());
        }
    }
}
