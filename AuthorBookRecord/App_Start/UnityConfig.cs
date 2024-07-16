using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AuthorBookRecord
{
    public static class UnityConfig
    {
        private static readonly IUnityContainer container;

        internal static IUnityContainer Container => container;

        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}