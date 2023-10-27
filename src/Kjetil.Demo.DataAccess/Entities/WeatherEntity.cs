using System;

namespace Kjetil.Demo.DataAccess.Entities;

public class WeatherEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Summary { get; set; }

    public int Temperature { get; set; }
}