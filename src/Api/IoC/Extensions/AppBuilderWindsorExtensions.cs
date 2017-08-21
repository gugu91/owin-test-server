using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using Owin;

namespace Api.IoC.Extensions
{
    public static class AppBuilderWindsorExtensions
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