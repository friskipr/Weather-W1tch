using RestSharp;
using System;
using System.Collections.Specialized;
using WeatherW1tchAPI.DAO;
using WeatherW1tchAPI.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WeatherW1tchAPI.Services
{
    public class WeatherService : IWeatherService
    {
        private ISetupService SetupService;
        private string ServiceURL;
        private string Query;

        public WeatherService(ISetupService _setupSrv)
        {
            SetupService = _setupSrv;
        }

        /// <summary>
        /// Get weather profile from service
        /// </summary>
        /// <param name="model">setup object</param>
        /// <returns>weather forecast object</returns>
        public WeatherForecast Get(SetupModel model)
        {
            SetupService.Configure(model);
            BuildQuery(model);
            ServiceURL = model.URL;

            return Get();
        }

        // Get weather profile
        private WeatherForecast Get()
        {
            var client = new RestClient(ServiceURL);
            var request = new RestRequest($"?{Query}", DataFormat.Json);

            var response = client.Get(request);

            WeatherForecast output = JsonSerializer.Deserialize<WeatherForecast>(response.Content);

            return output;
        }

        /// <summary>
        /// Build query string
        /// </summary>
        /// <param name="model">Weather Model data</param>
        private void BuildQuery(SetupModel model)
        {
            NameValueCollection queryStr = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryStr.Add("lat", model.Lat);
            queryStr.Add("lon", model.Lon);
            queryStr.Add("exclude", model.Exclude);
            queryStr.Add("APPID", model.AppID);

            Query = queryStr.ToString();            
        }
    }
}
