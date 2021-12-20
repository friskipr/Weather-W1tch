using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using WeatherW1tchAPI.Services;
using WeatherW1tchAPI.Mapper;
using WeatherW1tchAPI.Controllers;
using WeatherW1tchAPI.Model;

namespace WeatherW1tch_xUnitTest
{
    public class WeatherControllerUnitTest
    {
        // Testing Data
        IEnumerable<CityModel> GetCityData()
        {
            var cityList = new List<CityModel>();
            cityList.Add(new CityModel
            {
                City = "Tokyo",
                Country = "Japan",
                Lat = "35.6897",
                Lon = "139.6922"
            });
            return cityList;
        }

        [Fact]
        public void Index_ReturnText()
        {
            var mockWeatherSvc = new Mock<IWeatherService>();
            var mockWeatherMapper = new Mock<IWeatherMapper>();
            var mockCityService = new Mock<ICityService>();

            var controller = new WeatherController(mockWeatherSvc.Object, mockWeatherMapper.Object, mockCityService.Object);

            Assert.False(string.IsNullOrWhiteSpace(controller.Index()));
        }

        [Fact]
        public void GetCities_ReturnValidResponse()
        {
            var mockWeatherSvc = new Mock<IWeatherService>();
            var mockWeatherMapper = new Mock<IWeatherMapper>();
            var mockCityService = new Mock<ICityService>();
            mockCityService.Setup(x => x.GetDummy()).Returns(GetCityData());

            var controller = new WeatherController(mockWeatherSvc.Object, mockWeatherMapper.Object, mockCityService.Object);
            var result = controller.GetCities();

            Assert.True(result != null);

        }

        [Theory]
        [InlineData("30.5872", "114.2881")]
        [InlineData("31.8639", "117.2808")]
        public void GetWeather_NoResponseFromAPI_ReturnNull(string lat, string lon)
        {
            var setup = new SetupModel
            {
                Lat = lat,
                Lon = lon
            };

            var mockWeatherSvc = new Mock<IWeatherService>();
            mockWeatherSvc.Setup(x => x.Get(setup)).Returns(
                new WeatherW1tchAPI.DAO.WeatherForecast());

            var mockWeatherMapper = new Mock<IWeatherMapper>();
            mockWeatherMapper.Setup(y => y.Map(new WeatherW1tchAPI.DAO.WeatherForecast())).Returns(new WeatherModel());

            var mockCityService = new Mock<ICityService>();

            var controller = new WeatherController(mockWeatherSvc.Object, mockWeatherMapper.Object, mockCityService.Object);
            var result = controller.GetWeather(lat, lon);

            Assert.Null(result);
        }

        [Theory]
        [InlineData("30.5872", "114.2881")]
        [InlineData("31.8639", "117.2808")]
        public void GetWeather_ReturnResponse(string lat, string lon)
        {
            var setup = new SetupModel
            {
                Lat = lat,
                Lon = lon
            };

            var mockWeatherSvc = new Mock<IWeatherService>();
            mockWeatherSvc.Setup(x => x.Get(setup)).Returns(
                new WeatherW1tchAPI.DAO.WeatherForecast()
                {
                    lat = double.Parse(lat),
                    lon = double.Parse(lon),
                    timezone = "",
                    current = new WeatherW1tchAPI.DAO.Current()
                });

            var mockWeatherMapper = new Mock<IWeatherMapper>(); 
            mockWeatherMapper.Setup(y => y.Map(mockWeatherSvc.Object.Get(setup))).Returns(new WeatherModel()
            {
                TempC = "100"
            });

            var mockCityService = new Mock<ICityService>();

            var controller = new WeatherController(mockWeatherSvc.Object, mockWeatherMapper.Object, mockCityService.Object);
            var result = controller.GetWeather(lat, lon);

            Assert.Null(result);
        }
    }
}
