using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Lifestyle.Scoped;
using Castle.Windsor;
using Owin;

namespace Api.IoC.Extensions
{
    public static class AppBuilderWindsorExtensions
    {
        public static IAppBuilder UseWindsorScopeMidddleware(this IAppBuilder appBuilder)
        {
            return appBuilder.Use(async (env, next) =>
            {
                using (new CallContextLifetimeScope())
                {
                    await next();
                }
            });
        }
    }
}