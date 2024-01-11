namespace Kjetil.Demo.Service.Extensions;

public static class TemperatureExtension
{
    public static int ToFahrenheit(this int celsius)
    {
        return (int)Math.Round((double)celsius * 9 / 5 + 32);
    }
}