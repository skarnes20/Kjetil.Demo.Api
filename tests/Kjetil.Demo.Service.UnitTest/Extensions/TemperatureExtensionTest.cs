namespace Kjetil.Demo.Service.UnitTest.Extensions;

public class TemperatureExtensionTest
{
    [Theory]
    [InlineData(1, 34)]
    [InlineData(-10, 14)]
    [InlineData(10, 50)]
    public void ToFahrenheit_Input_Expected(int celsius, int fahrenheit)
    {
        Assert.Equal(fahrenheit, celsius.ToFahrenheit());
    }
}