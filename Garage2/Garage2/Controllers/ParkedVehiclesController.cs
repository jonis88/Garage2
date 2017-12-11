using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.DataAccessLayer;
using Garage2.Models;
using System.Globalization;

namespace Garage2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private RegisterContext db = new RegisterContext();

        // GET: ParkedVehicles
        public ActionResult Index()
        {
            var param = Request["sortOrder"];
            var list = db.ParkedVehicles.Select(v => v);

            if (param != null)
            {
                switch (param.ToString())
                {
                    case "Type":
                        list = list.OrderBy(v => v.TypeOf.ToString());
                        break;
                    case "Reg":
                        list = list.OrderBy(v => v.Registration);
                        break;
                    case "Color":
                        list = list.OrderBy(v => v.Color);
                        break;
                    case "Model":
                        list = list.OrderBy(v => v.Model);
                        break;
                    case "Arrival":
                        list = list.OrderBy(v => v.ArrivalTime);
                        break;
                    default:
                        list = list.OrderBy(v => v.Registration);
                        break;
                }
            }
            return View(list.ToList());
        }

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeOf,Registration,Color,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                parkedVehicle.ArrivalTime = DateTime.Now;
                parkedVehicle.Registration = parkedVehicle.Registration.ToUpper();
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeOf,Registration,Color,Model,NumberOfWheels")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);            
            db.ParkedVehicles.Remove(parkedVehicle);
            db.SaveChanges();
            TempData["parkedVehicle"] = parkedVehicle;
            return RedirectToAction("Receipt");
        }

        // GET: Vehicles/Receipt/5
        public ActionResult Receipt()
        {
            if (TempData["parkedVehicle"] != null)
            {
                ParkedVehicle vehi = TempData["parkedVehicle"] as ParkedVehicle;
                ViewBag.Registration = vehi.Registration;
                ViewBag.ArrivalTime = vehi.ArrivalTime;
                ViewBag.Departure = DateTime.Now;

                TimeSpan Duration = ViewBag.Departure.Subtract(ViewBag.ArrivalTime);
                ViewBag.Duration = String.Format("{0} dagar, {1} timmar, {2} minuter", Duration.Days, Duration.Hours, Duration.Minutes);
                var price = Math.Floor(Duration.TotalMinutes * 1);
                ViewBag.TotalPrice = price.ToString("C",
                      CultureInfo.CreateSpecificCulture("sv-SE"));

                return View();
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
