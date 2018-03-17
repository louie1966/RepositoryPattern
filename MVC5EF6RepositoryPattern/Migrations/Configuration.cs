namespace MVC5EF6RepositoryPattern.Migrations
{
    using MVC5EF6RepositoryPattern.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5EF6RepositoryPattern.DAL.FlightContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC5EF6RepositoryPattern.DAL.FlightContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Flights.AddOrUpdate(
                f => f.ID,
                new Flight { ID = 1, Description = "Flight 1", Duration = 20, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 2, Description = "Flight 2", Duration = 15, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 3, Description = "Flight 3", Duration = 10, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Sunny },
                new Flight { ID = 4, Description = "Flight 4", Duration = 12, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 5, Description = "Flight 5", Duration = 3, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 6, Description = "Flight 6", Duration = 30, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 7, Description = "Flight 7", Duration = 5, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Sunny },
                new Flight { ID = 8, Description = "Flight 8", Duration = 6, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 9, Description = "Flight 9", Duration = 6, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 10, Description = "Flight 10", Duration = 4, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 11, Description = "Flight 11", Duration = 3, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 12, Description = "Flight 12", Duration = 2, TakeOff = DateTime.Parse("2018-02-02 15:30"), Weather = Weather.Sunny });
        }
    }
}
