using MVC5EF6RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVC5EF6RepositoryPattern.DAL.Repository
{
    public interface IFlightRepository : IDisposable
    {
        IEnumerable<Flight> GetFlights();
        Flight GetFlightById(int flightId);
        IEnumerable<Flight> FindFlights(Expression<Func<Flight, bool>> predicate);

        void InsertFlight(Flight flight);
        void DeleteFlight(int flightId);

        void UpdateFlight(Flight flight);
        void SaveFlight();
    }
}
