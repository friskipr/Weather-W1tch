using WeatherW1tchAPI.Model;

namespace WeatherW1tchAPI.Services
{
    public class SetupService : ISetupService
    {
        public SetupService()
        {}

        /// <summary>
        /// Configuration
        /// </summary>
        /// <param name="_weather">model object</param>
        public void Configure(SetupModel _weather)
        {
            ConfigureAppId(_weather);
            ConfigureURL(_weather);
            ConfigureExclude(_weather);
        }

        /// <summary>
        /// Configure APP ID
        /// </summary>
        /// <param name="_weather">model object</param>
        private void ConfigureAppId(SetupModel _weather)
        {
            if (string.IsNullOrEmpty(_weather.AppID))
                _weather.AppID = "1ebeb21329f41ac46e74defdb18f6e5b"; //Fill with APP ID
        }

        /// <summary>
        /// Configure service URL
        /// </summary>
        /// <param name="_weather">model object</param>
        private void ConfigureURL(SetupModel _weather)
        {
            if (string.IsNullOrEmpty(_weather.URL))
                _weather.URL = "https://api.openweathermap.org/data/2.5/onecall";
        }

        /// <summary>
        /// Configure Exclude query string
        /// </summary>
        /// <param name="_weather">model object</param>
        private void ConfigureExclude(SetupModel _weather)
        {
            if (string.IsNullOrEmpty(_weather.Exclude))
                _weather.Exclude = "hourly,daily,minutely,alerts";
        }
    }
}
