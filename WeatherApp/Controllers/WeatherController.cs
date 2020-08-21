using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Model;
using WeatherApp.Service;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {       

        private readonly ILogger<WeatherController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILogger<WeatherController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_weatherService.GetAllWeather());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id) {
            return Ok(await _weatherService.GetWeatherByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Weather weather)
        {
            await _weatherService.AddWeatherAsync(weather);
            return Created("", "");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Weather weather)
        {
            await _weatherService.UpdateWeatherAsync(weather);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _weatherService.DeleteWeatherAsync(id);
            return NoContent();
        }

    }
}
