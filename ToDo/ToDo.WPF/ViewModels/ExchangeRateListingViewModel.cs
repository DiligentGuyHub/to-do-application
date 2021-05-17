using NbrbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.Services;

namespace ToDo.WPF.ViewModels
{
    public class ExchangeRateListingViewModel : ViewModelBase
    {
        private readonly IExchangeRateService _exchangeRateService;
        private Rate _usd;
        public Rate USD 
        { 
            get
            {
                return _usd;
            }
            set
            {
                _usd = value;
                OnPropertyChanged(nameof(USD));
            }
        }
        private Rate _eur;
        public Rate EUR
        {
            get
            {
                return _eur;
            }
            set
            {
                _eur = value;
                OnPropertyChanged(nameof(EUR));
            }
        }

        public ExchangeRateListingViewModel(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public static ExchangeRateListingViewModel LoadExchangeIndexViewModel(IExchangeRateService exchangeRateService)
        {
            ExchangeRateListingViewModel exchangeRateViewModel = new ExchangeRateListingViewModel(exchangeRateService);
            // everything is fine :D
            exchangeRateViewModel.LoadExchangeIndexes();
            return exchangeRateViewModel;
        }

        private void LoadExchangeIndexes()
        {
            _exchangeRateService.GetExchangeRate(RateType.USD).ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    USD = task.Result;
                }
            });
            _exchangeRateService.GetExchangeRate(RateType.EUR).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    EUR = task.Result;
                }
            });
        }

    }
}
