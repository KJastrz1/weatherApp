using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            City[] cities = await accuWeatherService.GetLocations(txtCity.Text);
            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null)
            {
                txtResults.Text = "Press button to select what information to display";
            }
        }
        private async void btnGet_Current_Conditions(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null)
            {
                CurrentConditions currentConditions = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                string wT = currentConditions.WeatherText;
                double temperature = currentConditions.Temperature.Metric.Value;
                string resultString = $"Current Temperature for city {selectedCity.LocalizedName}: {temperature}°C \n{wT}";
                txtResults.Text = resultString;
            }
        }
        private async void btnGet_One_Day_Forecast(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null)
            {
                OneDayForecast oneDayForecast = await accuWeatherService.GetOneDayForecast(selectedCity.Key);
                DailyForecasts firstDay=oneDayForecast.DailyForecasts.First();
                double minTemperature = firstDay.Temperature.Minimum.Value;
                double maxTemperature = firstDay.Temperature.Maximum.Value;
                string iconPhrase = firstDay.Day.IconPhrase;
                string resultString = $"Minimum Temperature: {minTemperature}°C, Maximum Temperature: {maxTemperature}°C, Icon Phrase: {iconPhrase}";
                txtResults.Text = resultString;
            }
        }

        private async void btnGet_Five_Days_Forecast(object sender, RoutedEventArgs e)
        {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null)
            {
                OneDayForecast fiveDaysForecast = await accuWeatherService.GetFiveDaysForecast(selectedCity.Key);
                string resultString="";
                foreach (DailyForecasts day in fiveDaysForecast.DailyForecasts){
                    double minTemperature = day.Temperature.Minimum.Value;
                    double maxTemperature = day.Temperature.Maximum.Value;
                    string iconPhrase = day.Day.IconPhrase;
                    resultString += $"Day: {day.Date.ToString("d")} Minimum Temperature: {minTemperature}°C, Maximum Temperature: {maxTemperature}°C, Icon Phrase: {iconPhrase} \n";
                }
                txtResults.Text = resultString;
            }
        }




    }
}
