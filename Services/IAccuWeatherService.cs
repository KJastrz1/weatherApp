using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);
        Task<CurrentConditions> GetCurrentConditions(string cityKey);
        Task<OneDayForecast> GetOneDayForecast(string cityKey);
        Task<OneDayForecast> GetFiveDaysForecast(string cityKey);
    }
}
