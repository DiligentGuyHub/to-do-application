using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Models.Weather;
using ToDo.Domain.Services;

namespace ToDo.API.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<Weather> GetWeather(string lat, string lon, string lang)
        {
            //var request = WebRequest.CreateHttp($"https://api.weather.yandex.ru/v2/informers?lat={lat}&lon={lon}&lang={lang}");
            //request.Headers.Add("X-Yandex-API-Key", "54affabd-0082-40b8-a64d-e35d89acf599");
            //request.Method = "GET";
            //HttpWebRequest _request = request;

            //using (var response = _request.GetResponse())
            //{
            //    var responseStream = response.GetResponseStream() ?? throw new ArgumentNullException("Response", "incorrect request");

            //    using (var stream = new StreamReader(responseStream))
            //    {
            //        var weatherInfoString = stream.ReadToEnd();
            //        return JsonConvert.DeserializeObject<Weather>(weatherInfoString);
            //    }
            //}
                
            using (HttpClient client = new HttpClient())
            {



                string URI = "https://api.weather.yandex.ru/v2/informers?lat=55.75396&lon=37.620393";
                HttpResponseMessage response = await client.GetAsync(URI);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                Weather weather = JsonConvert.DeserializeObject<Weather>(jsonResponse);
                return weather;
            }
        }
    }
}
