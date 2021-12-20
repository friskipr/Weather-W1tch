using System.Collections.Generic;

namespace WeatherW1tchAPI.DAO
{
    public class Current
    {
        public int dt { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double dew_point { get; set; }
        public double uvi { get; set; }
        public double clouds { get; set; }
        public double visibility { get; set; }
        public double wind_speed { get; set; }
        public double wind_deg { get; set; }
        public List<Weather> weather { get; set; }
        public Rain rain { get; set; }
    }
}
