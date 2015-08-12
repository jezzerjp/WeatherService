using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using WeatherService.Business.Interfaces;
using WeatherService.Models;
using WeatherService.WeatherProviders;
using WeatherService.WeatherProviders.Interfaces;

namespace WeatherService.Business
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class WeatherFinder : IWeatherFinder
    {
        //IEnumerable<IWeatherProvider> _weatherProviders;
        IWeatherProvider _bbcWeatherProvider;
        IWeatherProvider _accuWeatherProvider;

        public WeatherFinder(
            [Dependency("Bbc")]IWeatherProvider bbcWeatherProvider,
            [Dependency("Accu")]IWeatherProvider accuWeatherProvider
            )
        {
            _bbcWeatherProvider = bbcWeatherProvider;
            _accuWeatherProvider = accuWeatherProvider;
        }

    public AverageWeatherResult GetAverageWeather(string location)
        {
            var totalCelsius = 0.0;
            var totalKph = 0.0;
            var totalFahrenheit = 0.0;
            var totalMph = 0.0;

            // average the results from each provider
            //foreach (var provider in _weatherProviders)
            //{
            // TODO: use an adapter to convert provider result to a WeatherResult

            var weatherResult = _bbcWeatherProvider.GetWeather(location);
            if (weatherResult.Status != HttpStatusCode.OK)
            {
                return new AverageWeatherResult { Status = weatherResult.Status };
            }
            totalCelsius += weatherResult.TemperatureCelsius;
            totalKph += weatherResult.WindSpeedKph;
            totalFahrenheit += weatherResult.TemperatureFahrenheit;
            totalMph += weatherResult.WindSpeedMph;

            weatherResult = _accuWeatherProvider.GetWeather(location);
            if (weatherResult.Status != HttpStatusCode.OK)
            {
                return new AverageWeatherResult { Status = weatherResult.Status };
            }
            totalCelsius += weatherResult.TemperatureCelsius;
            totalKph += weatherResult.WindSpeedKph;
            totalFahrenheit += weatherResult.TemperatureFahrenheit;
            totalMph += weatherResult.WindSpeedMph;

            //}

            var totalProviders = 2;
            
            return new AverageWeatherResult
            {
                Status = HttpStatusCode.OK,
                Location = location,
                AverageTemperatureCelsius = totalCelsius / totalProviders,
                AverageWindSpeedKph = totalKph / totalProviders,
                AverageTemperatureFahrenheit = totalFahrenheit / totalProviders,
                AverageWindSpeedMph = totalMph / totalProviders
            };
        }
    }
}
