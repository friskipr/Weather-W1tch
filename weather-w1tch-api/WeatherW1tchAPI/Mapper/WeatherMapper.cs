using System;
using System.Collections.Generic;
using WeatherW1tchAPI.DAO;
using WeatherW1tchAPI.Model;
using System.Linq;

namespace WeatherW1tchAPI.Mapper
{
    public class WeatherMapper : IWeatherMapper
    {
        public WeatherMapper()
        { }

        /// <summary>
        /// Map objects
        /// </summary>
        /// <param name="source">DAO object</param>
        /// <returns>Model object</returns>
        public WeatherModel Map (WeatherForecast source)
        {
            var destination = new WeatherModel()
            {
                DewPoint = FormatDewPoint(source.current.dew_point),
                TempK = source.current.temp.ToString("#.## K"),
                TempC = ConvertTempKtoC(source.current.temp).ToString("#.## C"),
                TempF = ConvertTempKtoF(source.current.temp).ToString("#.## F"),
                Time = ConvertUnixDateTime(source.current.dt),
                Wind = FormatWindSpeed(source.current.wind_speed),
                Visibility = FormatVisibility(source.current.visibility),
                SkyCondition = FormatSkyCondition(source.current.weather),
                RelativeHumidity = FormatHumidity(source.current.humidity),
                Pressure = FormatPressure(source.current.pressure)
            };

            return destination;
        }

        // Convert temperature Kelvin to Celcius
        public double ConvertTempKtoC(double temp)
        {
            return temp - 273.15;
        }

        // Convert temperature Kelvin to Fahrenheit
        public double ConvertTempKtoF(double temp)
        {
            return ConvertTempKtoC(temp) * 9 / 5 + 32;
        }

        // Convert UNIX datetime to standard format
        private string ConvertUnixDateTime(int time)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(time);

            return dateTimeOffset.LocalDateTime.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // Formatting some details
        #region string Formatting
        private string FormatWindSpeed(double speed)
        {
            return $"{speed} m/s";
        }

        private string FormatVisibility(double visibility)
        {
            return $"{visibility / 1000} km";
        }

        private string FormatSkyCondition(IList<Weather> list)
        {
            return string.Join(", ", list.Select(x => x.main));
        }

        private string FormatHumidity(double humidity)
        {
            return $"{humidity} %";
        }

        private string FormatPressure(double pressure)
        {
            return $"{pressure} hPa";
        }

        private string FormatDewPoint(double dew)
        {
            return $"{dew} K / {ConvertTempKtoC(dew).ToString("#.##")} C";
        }
        #endregion
    }
}
