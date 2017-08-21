using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace Api.Test.Acceptance
{
    [TestFixture]
    public abstract class SelfHostingTest
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