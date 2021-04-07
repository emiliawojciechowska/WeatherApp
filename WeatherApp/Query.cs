using System;
using System.Collections.Generic;
using System.Text;
using System.Net;





namespace WeatherApp
{
    class Query
    {
        private string _key;
          

        public Query(string key)
        {
            _key = key;

        }
        public string GetForecast(string City,int TimeStamps,string Units)
        {
            
          return new WebClient().DownloadString("http://api.openweathermap.org/data/2.5/forecast"+MakeQuery(City,TimeStamps, Units));
        
          
        }
        private string MakeQuery(string City, int TimeStamps, string Units)
        {
            return "?" + "q=" + City + "&cnt=" + TimeStamps.ToString() + "&units=" + Units + "&appid="+_key;
        }

    }
}
