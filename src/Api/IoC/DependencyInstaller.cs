using Api.Dependency;
using Asos.Customer.Recs.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Api
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IHttpClient>()
                .ImplementedBy<HttpClientStub>()
                .LifestyleSingleton());
        }
    }
}