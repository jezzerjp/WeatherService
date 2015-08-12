using Microsoft.Practices.Unity;
using System.Collections;
using System.Web.Http;
using Unity.WebApi;
using WeatherService.Business;
using WeatherService.Business.Interfaces;
using WeatherService.WeatherProviders;
using WeatherService.WeatherProviders.Interfaces;

namespace WeatherService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IWeatherFinder, WeatherFinder>();
            container.RegisterType<IWeatherProvider, BbcWeatherProvider>("Bbc");
            container.RegisterType<IWeatherProvider, AccuWeatherProvider>("Accu");

            // Resolve all named instances of IWeatherProvider 
            //container.RegisterType<IList<IWeatherProvider>, IWeatherProvider[]>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}