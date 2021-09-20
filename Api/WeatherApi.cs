using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestSharp;


namespace Api
{
    public class WeatherApi
    {
        public WeatherData GetData()
        {
           var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall");
            var request = new RestRequest();
            request.AddParameter("lat", 51.10);
            request.AddParameter("lon", 81.10);
           request.AddParameter("exclude", "current,minutely,hourly,alerts");
            request.AddParameter("appid", "5dc5e54c407ef3e5cd8b521761989231");
            request.AddParameter("units", "metric");
            var response = client.Get(request);
            return JsonConvert.DeserializeObject<WeatherData>(response.Content);
        }
    }
}
