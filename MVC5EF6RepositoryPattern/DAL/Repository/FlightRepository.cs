using MVC5EF6RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MVC5EF6RepositoryPattern.DAL.Repository
{
    public class FlightRepository : IFlightRepository, IDisposable
    {
        private FlightContext context;

        public FlightRepository(FlightContext context)
        {
            this.context = context;
        }

        public IEnumerable<Flight> GetFlights()
        {
            return context.Flights.ToList();
        }

        public Flight GetFlightById(int flightId)
        {
            return context.Flights.Find(flightId);
        }

        public IEnumerable<Flight> FindFlights(Expression<Func<Flight, bool>> predicate)
        {
            return context.Flights.Where(predicate);
        }

        public void DeleteFlight(int flightId)
        {
            Flight flight = context.Flights.Find(flightId);
            context.Flights.Remove(flight);
        }

        public void InsertFlight(Flight flight)
        {
            context.Flights.Add(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            context.Entry(flight).State = EntityState.Modified;
        }

        public void SaveFlight()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
