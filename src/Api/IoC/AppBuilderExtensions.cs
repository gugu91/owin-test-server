using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Owin;

namespace Api.IoC
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseWindsorScopeMidddleware(this IAppBuilder appBuilder, IWindsorContainer container)
        {
            return appBuilder.Use(async (env, next) =>
            {
                using (container.BeginScope())
                {
                    await next();
                }
            });
        }
    }
}