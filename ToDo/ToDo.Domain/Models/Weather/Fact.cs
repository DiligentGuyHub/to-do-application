using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models.Weather
{
    public class Fact
    {
        public int temp;
        public int feels_like;
        public int temp_water;
        public string icon;
        public string condition;
        public int wind_speed;
        public int wind_gust;
        public string wind_dir;
        public int pressure_mm;
        public int pressure_pa;
        public int humidity;
        public string daytime;
        public bool polar;
        public string season;
        public int obs_time;
        public Fact() { }
    }
}
