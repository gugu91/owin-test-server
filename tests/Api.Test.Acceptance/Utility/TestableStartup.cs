using Castle.MicroKernel.Registration;

namespace Api.Test.Acceptance.Utility
{
    public class TestableStartup : Startup
    {
        public static void OvverideComponent(IRegistration toRegister)
        {
            Container.Register(toRegister);
        }
    }
}