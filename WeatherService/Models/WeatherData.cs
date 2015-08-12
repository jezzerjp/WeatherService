using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherService.Models
{
    public class WeatherData
    {
        public string Location { get; set; }
        public string TemperatureUnits { get; set; }
        public string WindSpeedUnits { get; set; }
        public string AverageTemperature { get; set; }
        public string AverageWindSpeed { get; set; }
    }
}