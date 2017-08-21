using Castle.MicroKernel.Registration;

namespace Api.Test.Acceptance
{
    public class TestableStartup : Startup
    {
        public static void OvverideComponent(IRegistration toRegister)
        {
            Container.Register(toRegister);
        }
    }
}