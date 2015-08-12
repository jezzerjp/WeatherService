using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherService.WeatherProviders.Helpers
{
    public static class WeatherConverter
    {
        public static double Mph(double kph)
        {
            return kph * 0.62;
        }

        public static double Kph(double mph)
        {
            return mph * 1.61;
        }

        public static double Celsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public static double Fahrenheit(double celsius)
        {
            return 32 + (celsius * 9) / 5;
        }
    }
}
