using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WeatherApp.Helper;
using WeatherApp.Model;
using WeatherApp.Repository;

namespace WeatherApp.Service
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public async Task<bool> AddWeatherAsync(Weather weather)
        {
            return await _weatherRepository.AddWeatherAsync(weather);
        }

        public async Task DeleteWeatherAsync(int id)
        {
            try
            {
                await _weatherRepository.DeleteWeatherAsync(id);
            }
            catch (WeatherException ex)
            {
                if (ex.Code == "400")
                    throw new HttpResponseException("1001", ex.Message, 404);
            }
        }

        public IQueryable<Weather> GetAllWeather()
        {
            return _weatherRepository.GetAllWeather();
        }

        public async Task<Weather> GetWeatherByIdAsync(int id)
        {
            return await _weatherRepository.GetWeatherByIdAsync(id);
        }

        public async Task UpdateWeatherAsync(Weather newWeather)
        {
            try
            {

                await _weatherRepository.UpdateWeatherAsync(newWeather);
            }
            catch (WeatherException ex)
            {
                if (ex.Code == "400")
                    throw new HttpResponseException("1001", ex.Message, 404);
            }
        }
    }
}
