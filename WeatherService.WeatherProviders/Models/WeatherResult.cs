using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace WeatherService.WeatherProviders.Models
{
    public class WeatherResult
    {
        public HttpStatusCode Status { get; set; }
        public string Location { get; set; }
        public double TemperatureCelsius { get; set; }
        public double TemperatureFahrenheit { get; set; }
        public double WindSpeedKph { get; set; }
        public double WindSpeedMph { get; set; }
    }
}
