using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Helper;
using WeatherApp.Model;

namespace WeatherApp.Repository
{
    public class WeatherRepository : Repository<Weather>, IWeatherRepository
    {
        private readonly WeatherDbContext  _weatherDbContext;

        public WeatherRepository(WeatherDbContext weatherDbContext) : base(weatherDbContext)
        {
            _weatherDbContext = weatherDbContext;
        }

       
        public async Task<bool> UpdateWeatherAsync(Weather newWeather)
        {
            var entity = await _weatherDbContext.Set<Weather>().Where(p => p.Id == newWeather.Id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new WeatherException("404", "Specified weather does not exist");
            }
            return await UpdateAsync(entity);
        }

        public IQueryable<Weather> GetAllWeather()
        {
            return GetAll();
        }

        public async Task<bool> DeleteWeatherAsync(int id)
        {
            var entity = await _weatherDbContext.Set<Weather>().Where(p => p.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                throw new WeatherException("404", "Specified weather does not exist");
            }
            _weatherDbContext.Set<Weather>().Remove(entity);
            return await _weatherDbContext.SaveChangesAsync() > 0;
        }

        public async Task<Weather> GetWeatherByIdAsync(int id)
        {
            var entity = await GetAll().Where(p => p.Id == id).FirstOrDefaultAsync();
            return entity;
        }

        public async Task<bool> AddWeatherAsync(Weather entity)
        {
            return await AddAsync(entity);
        }
    }
}
