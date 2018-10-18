using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using Sample.Data.Repository;
using System.Web.Mvc;

namespace Sample.WebApi
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // register Mvc Controllers
            builder.RegisterControllers(typeof(Sample.WebApi.WebApiApplication).Assembly);

            // register WebApi2 Controllers
            builder.RegisterApiControllers(typeof(Sample.WebApi.WebApiApplication).Assembly);

            // register Data Repositories
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();

            // build container
            var container = builder.Build();

            // register Mvc Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // register WebApi Dependency Resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);


        }
    }
}