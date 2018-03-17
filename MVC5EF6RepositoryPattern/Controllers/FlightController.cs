using MVC5EF6RepositoryPattern.DAL;
using MVC5EF6RepositoryPattern.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVC5EF6RepositoryPattern.Controllers
{
    public class FlightController : Controller
    {
        private FlightContext db = new FlightContext();

        // GET: Flight
        public ActionResult Index()
        {
            return View(db.Flights.ToList());
        }

        // GET: Flight
        public ActionResult Top10LongestFlights()
        {
            var flights = db.Flights
                .Where(f => f.Duration >= 10)
                .OrderByDescending(f => f.Duration)
                .Take(5)
                .ToList();

            return View(flights);
        }

        // GET: Flight
        public ActionResult SunnyFlights()
        {
            var flights = db.Flights
                .Where(f => f.Weather == Weather.Sunny)
                .OrderByDescending(f => f.TakeOff)
                .Take(5).
                ToList();

            return View(flights);
        }

        // GET: Flight/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if(flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,TakeOff,Weather,Duration")] Flight flight)
        {
            if(ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // GET: Flight/Edit/5
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if(flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,TakeOff,Weather,Duration")] Flight flight)
        {
            if(ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flight/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if(flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
