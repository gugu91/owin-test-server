using System;
using Castle.MicroKernel.Registration;

namespace Api.Test.Acceptance.Core
{
    public abstract class WindsorSelfHostingTest : SelfHostingTest
    {
        protected void OvverideComponent<T>(Func<T> factoryMethod, string instanceName = null) where T : class
        {
            var component = Component.For(typeof(T)).UsingFactoryMethod(factoryMethod).IsDefault();
            OverrideComponent(instanceName != null ? component.Named(instanceName) : component);
        }

        protected abstract void OverrideComponent(IRegistration componentRegistration);
    }
}