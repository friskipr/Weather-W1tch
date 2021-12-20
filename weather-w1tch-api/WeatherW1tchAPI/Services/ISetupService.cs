using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Services
{
    public interface ISetupService
    {
        void Configure(SetupModel _weather);
    }
}
