using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using WeatherService.WeatherProviders.Interfaces;
using WeatherService.WeatherProviders.Models;
using WeatherService.WeatherProviders.Helpers;

namespace WeatherService.WeatherProviders
{
    public class AccuWeatherProvider : IWeatherProvider
    {
        public WeatherResult GetWeather(string location)
        {
            var client = new RestClient("http://localhost:18888/api");
            var request = new RestRequest("weather/abcd");
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return new WeatherResult { Status = response.StatusCode };
            }

            var weatherResult = JsonConvert.DeserializeObject<WeatherResult>(response.Content);
            //convert for other units
            weatherResult.TemperatureCelsius = WeatherConverter.Celsius(weatherResult.TemperatureFahrenheit);
            weatherResult.WindSpeedKph = WeatherConverter.Kph(weatherResult.WindSpeedMph);
            weatherResult.Status = response.StatusCode;

            return weatherResult;
        }
    }
}
