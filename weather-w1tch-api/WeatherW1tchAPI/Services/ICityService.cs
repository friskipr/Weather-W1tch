using System.Collections.Generic;
using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Services
{
    public interface ICityService
    {
        IEnumerable<string[]> Get();
        IEnumerable<CityModel> GetDummy();
    }
}
