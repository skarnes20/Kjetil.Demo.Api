namespace Kjetil.Demo.Service.Extensions;

public static class TempratureExtension
{
    public static int ToFarenheit(this int celcius)
    {
        return (int)Math.Round((double)celcius * 9 / 5 + 32);
    }
}