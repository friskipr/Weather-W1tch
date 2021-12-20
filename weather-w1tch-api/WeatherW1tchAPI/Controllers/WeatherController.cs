using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherW1tchAPI.Mapper;
using WeatherW1tchAPI.Model;
using WeatherW1tchAPI.Services;

namespace WeatherW1tchAPI.Controllers
{
    [EnableCors("WeatherPolicy")]
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherService _weatherService;
        private IWeatherMapper _mapper;
        private ICityService _cityService;

        public WeatherController(IWeatherService weatherSvc, IWeatherMapper mapper, ICityService citySvc)
        {
            _weatherService = weatherSvc;
            _mapper = mapper;
            _cityService = citySvc;
        }

        // Root page
        [Route("/")]
        [HttpGet]
        public string Index()
        {
            return "Web API is running. Status: OK";
        }

        // Supply list of city and country
        [Route("/getcity")]
        [HttpGet]
        public IEnumerable<CityModel> GetCities()
        {
            return _cityService.GetDummy(); ;
        }

        /// <summary>
        /// Supply weather profile in a city
        /// </summary>
        /// <param name="lat">Latitude</param>
        /// <param name="lon">Longitude</param>
        /// <returns></returns>
        [Route("/getweather")]
        [HttpGet]
        public WeatherModel GetWeather(string lat, string lon)
        {
            try
            {
                var model = new SetupModel
                {
                    Lat = lat,
                    Lon = lon
                };

                var output = _weatherService.Get(model);

                return _mapper.Map(output);
            }
            catch (Exception)
            {
                            
            }

            return null;
        }
    }
}
