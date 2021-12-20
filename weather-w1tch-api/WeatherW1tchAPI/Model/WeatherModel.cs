using System;

namespace WeatherW1tchAPI.Model
{
    public class WeatherModel
    {
        public string Location { get; set; }
        public string Time { get; set; }
        public string Wind { get; set; }
        public string Visibility { get; set; }
        public string SkyCondition { get; set; }
        public string TempK { get; set; }
        public string TempC { get; set; }
        public string TempF { get; set; }
        public string DewPoint { get; set; }
        public string RelativeHumidity { get; set; }
        public string Pressure { get; set; }
    }
}
