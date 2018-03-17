using System;

namespace MVC5EF6RepositoryPattern.Models
{
    public class Flight
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime TakeOff { get; set; }

        public Weather Weather { get; set; }

        public int Duration { get; set; }

    }

    public enum Weather
    {
        Sunny, Windy, Hazy, Overcast
    }
}