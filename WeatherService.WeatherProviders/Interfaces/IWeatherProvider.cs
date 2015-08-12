using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherService.WeatherProviders.Models;

namespace WeatherService.WeatherProviders.Interfaces
{
    public interface IWeatherProvider
    {
        WeatherResult GetWeather(string location);
    }
}
