using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly IAccuWeatherService _accuWeatherService;
        private CityViewModel _selectedCity;
        public ObservableCollection<CityViewModel> Cities { get; set; }
        private CurrentConditions _currentConditions;
        private OneDayForecast _forecast;

        public MainWindowViewModel(IAccuWeatherService accuWeatherService)
        {
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>();
        }

        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadCurentConditions();
            }
        }

        [RelayCommand]
        public async void SearchCities(string locationName)
        {
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities)
                Cities.Add(new CityViewModel(city));
        }

        [ObservableProperty]
        private CCViewModel ccView;

        
        public async void LoadCurentConditions()
        {
            if (SelectedCity != null)
            {
                _currentConditions = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key);
                CcView = new CCViewModel(_currentConditions);
            }
        }

        [ObservableProperty]
        private ForecastViewModel forecastView;

        [RelayCommand]
        public async void LoadOneDayForecast()
        {
            if (SelectedCity != null)
            {
                _forecast = await _accuWeatherService.GetOneDayForecast(SelectedCity.Key);
                ForecastView = new ForecastViewModel(_forecast, 1);
            }
        }

        [RelayCommand]
        public async void LoadFiveDaysForecast()
        {
            if (SelectedCity != null)
            {
                _forecast = await _accuWeatherService.GetFiveDaysForecast(SelectedCity.Key);
                ForecastView = new ForecastViewModel(_forecast, 5);
            }
        }
    }
}
