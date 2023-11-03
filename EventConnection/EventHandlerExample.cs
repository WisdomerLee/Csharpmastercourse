using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventConnection
{
    public record struct WeatherData(int? Temperature, int? Humidity);

    public class WeatherDataAggregator
    {
        public IEnumerable<WeatherData> WeatherHistory => _weatherHistory;
        private List<WeatherData> _weatherHistory = new();

        public void GetNotifiedAboutNewData(object? sender, WeatherDataEventArgs weatherData)
        {
            //your code goes here

            _weatherHistory.Add(weatherData.WeatherData);
        }
    }


    public class WeatherStation
    {
        public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

        public void Measure()
        {
            int temperature = 25;

            OnWeatherMeasured(temperature);
        }

        private void OnWeatherMeasured(int temperature)
        {
            //your code goes here
            WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(Temperature: temperature, Humidity: null)));
        }
    }

    public class WeatherBaloon
    {
        public event EventHandler<WeatherDataEventArgs>? WeatherMeasured;

        public void Measure()
        {
            int humidity = 50;

            OnWeatherMeasured(humidity);
        }

        private void OnWeatherMeasured(int humidity)
        {
            //your code goes here
            WeatherMeasured?.Invoke(this, new WeatherDataEventArgs(new WeatherData(Humidity: humidity, Temperature: null)));
        }
    }

    public class WeatherDataEventArgs : EventArgs
    {
        public WeatherData WeatherData { get; }

        public WeatherDataEventArgs(WeatherData weatherData)
        {
            WeatherData = weatherData;
        }
    }
    internal class EventHandlerExample
    {

    }
}
