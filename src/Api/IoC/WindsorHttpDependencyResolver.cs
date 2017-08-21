using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Api.IoC;
using Castle.Windsor;

namespace Api
{
    internal sealed class WindsorHttpDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorHttpDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            _container = container;
        }

        public object GetService(Type t)
        {
            return _container.Kernel.HasComponent(t)
                ? _container.Resolve(t)
                : null;
        }

        public IEnumerable<object> GetServices(Type t)
        {
            return _container.ResolveAll(t)
                .Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new OwinWindsorDependencyScope(_container);
        }

        public void Dispose()
        {
        }
    }
}