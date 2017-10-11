using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using AquaHobby.Repository;
using AquaHobby.Repository.Implementations;
using System.Data.Entity;
using AquaHobby.DAL;
using System.Web.Http.Controllers;
using AquaHobby.Api.Controllers;
using AquaHobby.DAL.Services;
using AquaHobby.DAL.Services.Implementations;

namespace AquaHobby.Api
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

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
            //repos
            container.RegisterType<IAppUsersRepository, AppUsersRepository>();
            container.RegisterType<IAquariumsRepository, AquariumsRepository>();
            container.RegisterType<IFishRepository, FishRepository>();
            container.RegisterType<IGalleriesRepository, GalleriesRepository>();
            container.RegisterType<IHealthBooksRepository, HealthBooksRepository>();
            container.RegisterType<IIllnessesRepository, IllnessesRepository>();
            container.RegisterType<IKindsRepository, KindsRepository>();
            container.RegisterType<INursingsRepository, NursingsRepository>();
            container.RegisterType<IKindNotyficationsRepository, KindNotyficationsRepository>();
            container.RegisterType<IObservationsRepository, ObservationsRepository>();
            container.RegisterType<IPhotosRepository, PhotosRepository>();
            container.RegisterType<IWaterChangesRepository, WaterChangesRepository>();
            //services
            container.RegisterType<IAppUserService, AppUserService>();

            container.RegisterType<DbContext, AquaHobbyContext>(new PerResolveLifetimeManager());
            container.RegisterType<AppUnityOfWork, AppUnityOfWork>(new PerResolveLifetimeManager());
            container.RegisterType<IHttpController, ValuesController>("Values");
        }
    }
}