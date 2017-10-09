using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using System.Web.Http.Dependencies;

namespace AquaHobby.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Konfiguracja i usługi składnika Web API
            //UnityContainer container = GetContainer();
            config.DependencyResolver = new UnityResolver(Bootstrapper.Initialise());
            // Skonfiguruj składnik Web API, aby korzystał tylko z uwierzytelniania za pomocą tokenów bearer.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public class UnityResolver : System.Web.Http.Dependencies.IDependencyResolver
        {
            protected IUnityContainer container;

            public UnityResolver(IUnityContainer container)
            {
                if (container == null)
                {
                    throw new ArgumentNullException("container");
                }
                this.container = container;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return container.Resolve(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return null;
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                try
                {
                    return container.ResolveAll(serviceType);
                }
                catch (ResolutionFailedException)
                {
                    return new List<object>();
                }
            }

            public IDependencyScope BeginScope()
            {
                var child = container.CreateChildContainer();
                return new UnityResolver(child);
            }

            public void Dispose()
            {
                Dispose(true);
            }

            protected virtual void Dispose(bool disposing)
            {
                container.Dispose();
            }
        }
        //private static UnityContainer GetContainer()
        //{
        //    UnityContainer container = new UnityContainer();

        //    container.RegisterType<IAppUsersRepository, AppUsersRepository>();
        //    container.RegisterType<IAquariumsRepository, AquariumsRepository>();
        //    container.RegisterType<IFishRepository, FishRepository>();
        //    container.RegisterType<IGalleriesRepository, GalleriesRepository>();
        //    container.RegisterType<IHealthBooksRepository, HealthBooksRepository>();
        //    container.RegisterType<IIllnessesRepository, IllnessesRepository>();
        //    container.RegisterType<IKindsRepository, KindsRepository>();
        //    container.RegisterType<INursingsRepository, NursingsRepository>();
        //    container.RegisterType<IKindNotyficationsRepository, KindNotyficationsRepository>();
        //    container.RegisterType<IObservationsRepository, ObservationsRepository>();
        //    container.RegisterType<IPhotosRepository, PhotosRepository>();
        //    container.RegisterType<IWaterChangesRepository, WaterChangesRepository>();
        //    container.RegisterType<DbContext, AquaHobbyContext>(new ContainerControlledLifetimeManager());
        //    container.RegisterType<AppUnityOfWork>(new ContainerControlledLifetimeManager());
        //    return container;
        //}
    }
}
