using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kjetil.Demo.DataAccess.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherDbContext _context;

        public WeatherRepository(WeatherDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WeatherEntity>> Get(int quantity)
        {
            return await _context.Weather.Take(quantity).ToListAsync();
        }
    }
}