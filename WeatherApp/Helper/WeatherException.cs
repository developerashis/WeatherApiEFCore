using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Helper
{
    public class WeatherException : Exception
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public WeatherException(string code, string message) : base(message) {
            Code = code;
            Message = message;
        }
        
    }
}
