using WeatherW1tchAPI.DAO;
using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Services
{
    public interface IWeatherService
    {
        WeatherForecast Get(SetupModel model);
    }
}
