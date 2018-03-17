using MVC5EF6RepositoryPattern.DAL;
using MVC5EF6RepositoryPattern.DAL.Repository;
using MVC5EF6RepositoryPattern.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC5EF6RepositoryPattern.Controllers
{
    public class FlightRepoController : Controller
    {
        private IFlightRepository flightRepository;

        public FlightRepoController()
        {
            this.flightRepository = new FlightRepository(new FlightContext());
        }

        // GET: FlightRepo
        public ActionResult Index() => View(flightRepository
            .GetFlights());

        // GET: FlightRepo
        public ActionResult Top10LongestFlights() => View(flightRepository
            .FindFlights(f => f.Duration >= 10)
            .OrderByDescending(f => f.Duration)
            .Take(5));

        public ActionResult SunnyFlights() => View(flightRepository
            .FindFlights(f => f.Weather == Weather.Sunny)
            .OrderByDescending(f => f.TakeOff).Take(5));

        // GET: FlightRepo/Details/5
        public ActionResult Details(int id)
        {
            if(flightRepository.GetFlightById(id) == null)
            {
                return HttpNotFound();
            }
            return View(flightRepository.GetFlightById(id));
        }

        // GET: FlightRepo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FlightRepo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,TakeOff,Weather,Duration")] Flight flight)
        {
            if(ModelState.IsValid)
            {
                flightRepository.InsertFlight(flight);
                flightRepository.SaveFlight();
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // GET: FlightRepo/Edit/5
        public ActionResult Edit(int id)
        {
            Flight flight = flightRepository.GetFlightById(id);
            if(flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: FlightRepo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,TakeOff,Weather,Duration")] Flight flight)
        {
            if(ModelState.IsValid)
            {
                flightRepository.UpdateFlight(flight);
                flightRepository.SaveFlight();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: FlightRepo/Delete/5
        public ActionResult Delete(int id)
        {

            Flight flight = flightRepository.GetFlightById(id);
            if(flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: FlightRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            flightRepository.DeleteFlight(id);
            flightRepository.SaveFlight();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            flightRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
