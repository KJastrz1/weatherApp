using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService : IAccuWeatherService
    {
        //private static readonly HttpClient client = new HttpClient();
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language{2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language{2}";
        private const string one_day_forecast_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language{2}&metric=true";
        private const string five_days_forecast_endpoint = "forecasts/v1/daily/5day/{0}?apikey={1}&language{2}&metric=true";
        string api_key;
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json");

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }

        }

        public async Task<CurrentConditions> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                CurrentConditions[] currentConditions = JsonConvert.DeserializeObject<CurrentConditions[]>(json);
                return currentConditions.FirstOrDefault();
            }
        }

        public async Task<OneDayForecast> GetOneDayForecast(string cityKey)
        {

            string uri = base_url + "/" + string.Format(one_day_forecast_endpoint, cityKey, api_key, language);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                OneDayForecast forecast = JsonConvert.DeserializeObject<OneDayForecast>(json);
                return forecast;
            }

        }
          public async Task<OneDayForecast> GetFiveDaysForecast(string cityKey)
        {

            string uri = base_url + "/" + string.Format(five_days_forecast_endpoint, cityKey, api_key, language);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                OneDayForecast forecast = JsonConvert.DeserializeObject<OneDayForecast>(json);
                return forecast;
            }

        }
    }
}
