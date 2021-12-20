using System;
using System.Collections.Generic;
using System.IO;
using WeatherW1tchAPI.DAO;
using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Services
{
    public class CityService : ICityService
    {
        public CityService()
        { }

        // Get list of city from file
        public IEnumerable<string[]> Get()
        {
            string path = Environment.CurrentDirectory + "/Data/worldcities.csv";
            
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 64 * 1024, FileOptions.SequentialScan))
            using (var reader = new StreamReader(fs))
            {
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line.Split(',');
                }
            }
        }

        // Get Dummy lisf of city
        public IEnumerable<CityModel> GetDummy()
        {
            var cityList = new List<CityModel>();
            cityList.Add(new CityModel
            {
                City = "Tokyo",
                Country = "Japan",
                Lat = "35.6897",
                Lon = "139.6922"
            });
            cityList.Add(new CityModel
            {
                City = "Jakarta",
                Country = "Indonesia",
                Lat = "-6.2146",
                Lon = "106.8451"
            });
            cityList.Add(new CityModel
            {
                City = "Shanghai",
                Country = "China",
                Lat = "31.1667",
                Lon = "121.4667"
            });
            cityList.Add(new CityModel
            {
                City = "Wuhan",
                Country = "China",
                Lat = "30.5872",
                Lon = "114.2881"
            });
            cityList.Add(new CityModel
            {
                City = "Istanbul",
                Country = "Turkey",
                Lat = "41.01",
                Lon = "28.9603"
            });

            return cityList;
        }
    }
}
