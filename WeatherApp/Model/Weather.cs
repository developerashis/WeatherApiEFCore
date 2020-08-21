using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Model
{
    public class Weather
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public string Adjective { get; set; }
    }
}
