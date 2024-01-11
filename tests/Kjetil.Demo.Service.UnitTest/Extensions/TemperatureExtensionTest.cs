using Kjetil.Demo.Service.Extensions;
using Xunit;

namespace Kjetil.Demo.Service.UnitTest.Extensions;

public class TemperatureExtensionTest
{
    [Theory]
    [InlineData(1, 34)]
    [InlineData(-10, 14)]
    [InlineData(10, 50)]
    public void ToFarenheit_Input_Expected(int celcius, int farenheit)
    {
        Assert.Equal(farenheit, celcius.ToFarenheit());
    }
}