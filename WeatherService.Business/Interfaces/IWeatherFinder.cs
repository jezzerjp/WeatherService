using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherService.Models;

namespace WeatherService.Business.Interfaces
{
    public interface IWeatherFinder
    {
        AverageWeatherResult GetAverageWeather(string location);
    }
}
