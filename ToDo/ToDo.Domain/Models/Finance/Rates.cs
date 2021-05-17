using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NbrbAPI.Models
{
    public enum RateType
    {
        USD,
        EUR
    }
    public class Rate
    {
        [Key]
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public decimal? Cur_OfficialRate { get; set; }
        public RateType Type { get; set; }
    }

    public class RateShort
    {
        public int Cur_ID { get; set; }
        [Key]
        public System.DateTime Date { get; set; }
        public decimal? Cur_OfficialRate { get; set; }
    }

}