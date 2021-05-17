using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models.Weather
{
    public class Weather
    {
        public int now;
        public string now_dt;
        Info info;
        Fact fact;
        Forecast forecast;
        public Weather()
        {
            info = new();
            fact = new();
            forecast = new();
        }
    }
}
