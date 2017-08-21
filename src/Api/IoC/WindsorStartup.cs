using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using Castle.MicroKernel;
using Castle.MicroKernel.Handlers;
using Castle.Windsor;
using Castle.Windsor.Diagnostics;

namespace Api.IoC
{
    public class WindsorStartup
    {
        public static IWindsorContainer Configuration(HttpConfiguration configuration)
        {
            var container = new WindsorContainer();
            container.Install(new ControllerInstaller(), new DependencyInstaller());
            configuration.DependencyResolver = new WindsorHttpDependencyResolver(container);
            CheckForPotentiallyMisconfiguredComponents(container);

            return container;
        }

        private static void CheckForPotentiallyMisconfiguredComponents(IWindsorContainer container)
        {
            var host = (IDiagnosticsHost)container.Kernel.GetSubSystem(SubSystemConstants.DiagnosticsKey);
            var diagnostics = host.GetDiagnostic<IPotentiallyMisconfiguredComponentsDiagnostic>();

            var handlers = diagnostics.Inspect();

            if (!handlers.Any()) return;

            var message = new StringBuilder();
            var inspector = new DependencyInspector(message);

            foreach (IExposeDependencyInfo handler in handlers)
            {
                handler.ObtainDependencyDetails(inspector);
            }

            throw new ApplicationException(message.ToString());
        }
    }
}