using AdminTool.Services.Implement;
using AdminTool.Services.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace AdminTool
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAdminServices, AdminServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}