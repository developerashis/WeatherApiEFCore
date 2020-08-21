using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Helper
{
    public class HttpResponseException : Exception
    {
        public string Code { get; }
        public string ExMessage { get; }
        public int StatusCode { get; }

        public HttpResponseException() { }
        public HttpResponseException(string exCode, string message, int statusCode) { Code = exCode; ExMessage = message; StatusCode = statusCode; }
    }
}
