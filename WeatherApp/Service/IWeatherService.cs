using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.Service
{
    public interface IWeatherService
    {
        IQueryable<Weather> GetAllWeather();
        Task<bool> AddWeatherAsync(Weather weather);
        Task UpdateWeatherAsync(Weather newWeather);
        Task DeleteWeatherAsync(int id);
        Task<Weather> GetWeatherByIdAsync(int id);
    }
}
