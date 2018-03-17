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
                new Flight { ID = 1, Description = "Flight 1", Duration = 10, TakeOff = DateTime.Parse("2017-10-11 14:30"), Weather = Weather.Overcast },
                new Flight { ID = 2, Description = "Flight 2", Duration = 20, TakeOff = DateTime.Parse("2018-02-02 15:30"), Weather = Weather.Sunny });
        }
    }
}
