using MVC5EF6RepositoryPattern.Models;
using System.Data.Entity;

namespace MVC5EF6RepositoryPattern.DAL
{
    public class FlightContext : DbContext
    {
        public FlightContext() : base("FlightConn")
        {
        }

        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("drone");
            base.OnModelCreating(modelBuilder);
        }


    }
}