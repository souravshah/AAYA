using System.Web.Http;
using System.Web.Mvc;
using GovHack.Data.Contracts;
using GovHack.Data.Repositories;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using WebApiContrib.IoC.Unity;

namespace Govhack2016
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //To support Web Api
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDataRepositoryFactory, DataRepositoryFactory>();
        }
    }
}