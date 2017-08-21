using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Castle.Windsor;

namespace Api.IoC
{
    public class WindsorStartup
    {
        public static void Configuration(HttpConfiguration configuration)
        {
            var container = new WindsorContainer()
                .Install(new ControllerInstaller(), new DependencyInstaller());
            var httpDependencyResolver = new WindsorHttpDependencyResolver(container);
            configuration.DependencyResolver = httpDependencyResolver;
        }
    }
}