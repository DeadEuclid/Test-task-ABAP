using Api;
using System;

namespace UI
{
    class Program
    {
      static  WeatherApi weather = new WeatherApi();
        static void Main(string[] args)
        {
            Console.WriteLine(weather.GetData());
            Console.ReadLine();
        }
    }
}
