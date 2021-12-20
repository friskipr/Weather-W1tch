using System;

namespace WeatherW1tchAPI.Model
{
    public class SetupModel
    {
        public string URL { get; set; }
        public string AppID { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Exclude { get; set; }
    }
}
