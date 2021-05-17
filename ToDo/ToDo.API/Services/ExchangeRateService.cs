using NbrbAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;

namespace ToDo.API.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        public async Task<Rate> GetExchangeRate(RateType rateType)
        {
            using (HttpClient client = new HttpClient())
            {
                string URI = "https://www.nbrb.by/api/exrates/rates/" + GetUriSuffix(rateType);
                HttpResponseMessage response = await client.GetAsync(URI);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                Rate rate = JsonConvert.DeserializeObject<Rate>(jsonResponse);
                rate.Type = rateType;
                return rate;
            }
        }

        private string GetUriSuffix(RateType rateType)
        {
            switch(rateType)
            {
                case RateType.USD:
                    return "145";
                case RateType.EUR:
                    return "292";
                default:
                    throw new Exception("Exchange rate for given is not defined");
            }
        }
    }
}
