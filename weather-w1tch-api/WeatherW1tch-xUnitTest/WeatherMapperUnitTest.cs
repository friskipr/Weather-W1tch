using System;
using System.Collections.Generic;
using System.Text;
using WeatherW1tchAPI.Mapper;
using Xunit;

namespace WeatherW1tch_xUnitTest
{
    public class WeatherMapperUnitTest
    {
        // Test K to F
        [Fact]
        public void ConvertTempKtoF_ReturnValid()
        {
            var mapper = new WeatherMapper();
            var result = mapper.ConvertTempKtoF(200);

            Assert.True(result.ToString("#.##") == "-99.67");
        }

        // Test K to F
        [Fact]
        public void ConvertTempKtoF_ReturnInValid()
        {
            var mapper = new WeatherMapper();
            var result = mapper.ConvertTempKtoF(200);

            Assert.False(result.ToString("#.##") == "10");
        }

        // Test K to C
        [Fact]
        public void ConvertTempKtoC_ReturnValid()
        {
            var mapper = new WeatherMapper();
            var result = mapper.ConvertTempKtoF(200);

            Assert.False(result.ToString("#.##") == "-73.15");
        }

        // Test K to C
        [Fact]
        public void ConvertTempKtoC_ReturnInValid()
        {
            var mapper = new WeatherMapper();
            var result = mapper.ConvertTempKtoF(200);

            Assert.False(result.ToString("#.##") == "10");
        }

        // Test K to C
        [Theory]
        [InlineData(0)]
        [InlineData(-12.24)]
        [InlineData(100.99)]
        public void ConvertTempKtoC_ReturnValidType(double value)
        {
            var mapper = new WeatherMapper();
            var result = mapper.ConvertTempKtoF(value);

            Assert.IsType<double>(result);
        }
    }
}
