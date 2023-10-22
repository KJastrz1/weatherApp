using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class CCViewModel
    {
        public CCViewModel(CurrentConditions cc)
        {
            CurrentTemperature = cc.Temperature.Metric.Value;
            HasPrecipitation = cc.HasPrecipitation;
        }
        public double CurrentTemperature { get; set; }
        public bool HasPrecipitation { get; set;}
    }
}
