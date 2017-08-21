using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;
using Api;
using Api.IoC;
using Castle.Windsor;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            WindsorStartup.Configuration(config);
            SerializationStartup.Configuration(config);
            RouteStartup.Configuration(config);

            appBuilder.UseWebApi(config);
        }
    }
}