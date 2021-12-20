using WeatherW1tchAPI.Services;
using Xunit;

namespace WeatherW1tch_xUnitTest
{
    public class CityServiceUnitTest
    {
        [Fact]
        public void GetDummy_ReturnValidResponse()
        {
            var service = new CityService();
            var result = service.GetDummy();

            Assert.True(result != null);
        }

    }
}
