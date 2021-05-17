using NbrbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Services
{
    public interface IExchangeRateService
    {
        Task<Rate> GetExchangeRate(RateType rateType);
    }
}
