using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models.Weather
{
    public class Forecast
    {
        string date;
        int date_ts;
        int week;
        string sunrise;
        string sunset;
        int moon_code;
        int moon_text;
        List<Part> parts;
    }
}
