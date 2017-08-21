using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using Castle.MicroKernel.Registration;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Api.Test.Acceptance
{
    [TestFixture]
    public abstract class InMemoryTest
    {
        private IDisposable _app;
        protected HttpClient HttpClient;
        
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var port = FreeTcpPort();

            HttpClient = new HttpClient { BaseAddress = new Uri("http://localhost:" + port) };
            _app = WebApp.Start<Startup>("http://localhost:" + port);
        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _app.Dispose();
        }

        protected void OvverideComponent<T>(Func<T> factoryMethod, string instanceName= null) where T : class
        {
            var component = Component.For(typeof(T)).UsingFactoryMethod(factoryMethod).IsDefault();
            OverrideComponent(instanceName != null ? component.Named(instanceName) : component);
        }

        protected abstract void OverrideComponent(IRegistration componentRegistration);

        private static int FreeTcpPort()
        {
            var l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            var port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            return port;
        }
    }
}