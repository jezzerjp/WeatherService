using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherService.Business.Interfaces;
using WeatherService.Models;

namespace WeatherService.Controllers
{
    public class WeatherController : ApiController
    {
        private IWeatherFinder _weatherFinder;

        public WeatherController(IWeatherFinder weatherFinder)
        {
            _weatherFinder = weatherFinder;
        }

        // GET api/weather/location
        [Route("api/weather/{location}")]
        [HttpGet]
        public IHttpActionResult Get(string location)
        {
            return Ok(_weatherFinder.GetAverageWeather(location));
        }

    }
}
