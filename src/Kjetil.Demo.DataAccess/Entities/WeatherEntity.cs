using System;
using System.ComponentModel.DataAnnotations;

namespace Kjetil.Demo.DataAccess.Entities;

public class WeatherEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(100)]
    public string Summary { get; set; }

    public int Temperature { get; set; }
}