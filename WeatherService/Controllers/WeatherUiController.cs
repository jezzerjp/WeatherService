using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    public class WeatherUiController : Controller
    {
        // GET: WeatherUi
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // POST: WeatherUi
        [HttpPost]
        public ActionResult Index(WeatherData weatherData)
        {
            weatherData.AverageTemperature = string.Empty;
            weatherData.AverageWindSpeed = string.Empty;
            if (weatherData.Location == null)
            {
                ViewBag.ErrorDescription = "You must supply a location";
                ModelState.Clear();
                return View(weatherData);
            }

            var client = new RestClient("http://localhost:50082/api");
            var request = new RestRequest("weather/" + weatherData.Location);
            var response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.ErrorDescription = "An error has occurred calling WeatherFinder service";
                ModelState.Clear();
                return View(weatherData);
            }
            var results = JsonConvert.DeserializeObject<AverageWeatherResult>(response.Content);
            if (results.Status != HttpStatusCode.OK)
            {
                ViewBag.ErrorDescription = "An error has occurred calling a weather provider";
                ModelState.Clear();
                return View(weatherData);
            }
            switch (weatherData.TemperatureUnits)
            {
                case "Celsius":
                    weatherData.AverageTemperature = Math.Round(results.AverageTemperatureCelsius).ToString();
                    break;
                case "Fahrenheit":
                    weatherData.AverageTemperature = Math.Round(results.AverageTemperatureFahrenheit).ToString();
                    break;
            }
            switch (weatherData.WindSpeedUnits)
            {
                case "Kph":
                    weatherData.AverageWindSpeed = Math.Round(results.AverageWindSpeedKph).ToString();
                    break;
                case "Mph":
                    weatherData.AverageWindSpeed = Math.Round(results.AverageWindSpeedMph).ToString();
                    break;
            }

            ViewBag.ErrorDescription = string.Empty;
            ModelState.Clear();
            return View(weatherData);
        }
    }
}