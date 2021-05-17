using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models.Weather
{
    public class Part
    {
        public string part_name;
        public int temp_min;
        public int temp_max;
        public int temp_avg;
        public int feels_like;
        public string icon;
        public string condition;
        public string daytime;
        public bool polar;
        public int wind_speed;
        public int wind_gust;
        public string wind_dir;
        public int pressure_mm;
        public int pressure_pa;
        public int humidity;
        public int prec_mm;
        public int prec_period;
        public int prec_prob;
        public Part() { }
    }
}
