using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebAPI.Helper;

namespace WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IAPIHelper, APIHelper>();
        }
    }
}