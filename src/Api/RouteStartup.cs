using System.Web.Http;

static internal class RouteStartup
{
    public static void Configuration(HttpConfiguration config)
    {
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "{controller}/{id}",
            defaults: new {id = RouteParameter.Optional}
        );
    }
}