using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Repository
{
    public interface IWeatherRepository : IRepository<Weather>
    {
        IQueryable<Weather> GetAllWeather();
        Task<bool> AddWeatherAsync(Weather weather);
        Task<bool> UpdateWeatherAsync(Weather newWeather);
        Task<bool> DeleteWeatherAsync(int id);
        Task<Weather> GetWeatherByIdAsync(int id);
    }
}
