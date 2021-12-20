namespace WeatherW1tchAPI.DAO
{
    public class WeatherForecast
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public string timezone { get; set; }
        public int timezone_offset { get; set; }
        public Current current { get; set; }
    }
}
