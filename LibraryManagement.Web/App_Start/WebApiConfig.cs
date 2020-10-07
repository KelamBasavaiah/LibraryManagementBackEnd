using LibraryManagement.Domain;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.LMBL;
using LibraryManagement.Domain.LMDAL;
using LibraryManagement.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace LibraryManagement.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IBookBL, BookBL>();
            container.RegisterType<IBookRepository, BookRepository>();
            config.DependencyResolver = new UnityDependencyResolver(container);
            
        }
    }
}
