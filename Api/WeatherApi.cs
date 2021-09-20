using System;
using RestSharp;


namespace Api
{
    public class WeatherApi
    {
        public string GetData()
        {
           var client = new RestClient("https://api.openweathermap.org/data/2.5/onecall");
            var request = new RestRequest();
            request.AddParameter("lat", 51.10);
            request.AddParameter("lon", 81.10);
           request.AddParameter("exclude", "current,minutely,hourly,alerts");
            request.AddParameter("appid", "5dc5e54c407ef3e5cd8b521761989231");
            var response = client.Get(request);
            return response.Content;
        }
    }
}
