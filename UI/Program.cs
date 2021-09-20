using Api;
using System;
using System.Linq;

namespace UI
{
    class Program
    {
        static readonly WeatherApi weather = new WeatherApi();
        static void Main()
        {
            var core = new Core();
            Console.WriteLine(core.GetResultString(weather.GetData()));
            Console.ReadLine();
        }

    }
    class Core
    {
        public string GetResultString(WeatherData data)
        {


            var days = data.Daily.Take(5);
            var dayMaxLenght = days.First(date => data.Daily.Max(date => date.Sunset - date.Sunrise) == (date.Sunset - date.Sunrise));
            var minNightDiffTemp = days.Min(date => date.Temp.Night - date.Feels_like.Night);
            var dayMinNightDiffTemp = UnixTimeStampToDateTime(days.First(date=> minNightDiffTemp==(date.Temp.Night - date.Feels_like.Night)).Time);
            return string.Format("В период с {1} по {2}" +
            "{0} В Змеиногорске {6} ожидается минимальная разница ощущаемой и фактической ночной температуры " +
            "{0} она составит {3} °С" +
            "{0} Максимальная продолжительность светогого дня за данный период составит {4}" +
            "{0} и будет достигнута {5}",
            Environment.NewLine,
            UnixTimeStampToDateTime(days.First().Time).ToString("d"),
            UnixTimeStampToDateTime(days.Last().Time).ToString("d"),
            Math.Round(minNightDiffTemp, 2),
            UnixTimeStampToDateTime(dayMaxLenght.Sunset).Subtract(UnixTimeStampToDateTime(dayMaxLenght.Sunrise)).ToString(),
            UnixTimeStampToDateTime( dayMaxLenght.Time).ToString("d"),
            dayMinNightDiffTemp.ToString("d")
          );
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }

}
