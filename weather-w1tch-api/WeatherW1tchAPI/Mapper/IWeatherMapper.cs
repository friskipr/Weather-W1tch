using WeatherW1tchAPI.DAO;
using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Mapper
{
    public interface IWeatherMapper
    {
        WeatherModel Map(WeatherForecast source);
        double ConvertTempKtoC(double temp);
        double ConvertTempKtoF(double temp);
    }
}
