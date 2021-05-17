using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models.Weather;

namespace ToDo.Domain.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeather(string latitude = "55.75396", string longitude= "37.620393", string language="en_US");
    }
}
