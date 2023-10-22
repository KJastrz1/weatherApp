using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class ForecastViewModel
    {
        public ObservableCollection<DailyForecastViewModel> dailyForecastList { get; }

        public ForecastViewModel(OneDayForecast forecast, int numOfDays)
        {
            dailyForecastList = new ObservableCollection<DailyForecastViewModel>(forecast.DailyForecasts
            .Take(numOfDays) 
            .Select(forecast => new DailyForecastViewModel
            {
                Date = forecast.Date,
                MinTemp = forecast.Temperature.Minimum.Value,
                MaxTemp = forecast.Temperature.Maximum.Value
            })
            .ToList());
        }  

    }

    public class DailyForecastViewModel
    {
        public DateTime Date { get; set; }
        public double MinTemp { get; set; }
        public double MaxTemp { get; set; }
    }
}
 