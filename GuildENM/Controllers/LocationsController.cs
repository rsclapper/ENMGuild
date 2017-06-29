using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ICompanyRepository _companyRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public LocationsController() : this(new LocationRepository(), new CompanyRepository())
        {
        }

        public LocationsController(ILocationRepository locationRepository, ICompanyRepository companyRepository)
        {
            this._locationRepository = locationRepository;
            this._companyRepository = companyRepository;
        }

        //
        // GET: /Locations/

        public ViewResult Index()
        {
            return View(_locationRepository.All);
        }

        //
        // GET: /Locations/Details/5

        public ViewResult Details(int id)
        {
            return View(_locationRepository.Find(id));
        }

        public JsonResult ByCompanyId(int id)
        {
            return Json(_locationRepository.All.Where(location => location.CompanyId == id), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Locations/Create

        public ActionResult Create()
        {
            ViewBag.AvailableCompanies = new SelectList(_companyRepository.All.Select(r => new { r.Id, r.Name }), "Id", "Name");

            return View(new Location());
        }

        //
        // POST: /Locations/Create

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.InsertOrUpdate(location);
                _locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AvailableCompanies = new SelectList(_companyRepository.All.Select(r => new { r.Id, r.Name }), "Id", "Name");
                return View(location);
            }
        }

        //
        // GET: /Locations/Edit/5

        public ActionResult Edit(int id)
        {
                ViewBag.AvailableCompanies = new SelectList(_companyRepository.All.Select(r => new { r.Id, r.Name }), "Id", "Name");
            return View(_locationRepository.Find(id));
        }

        //
        // POST: /Locations/Edit/5

        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.InsertOrUpdate(location);
                _locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AvailableCompanies = new SelectList(_companyRepository.All.Select(r => new { r.Id, r.Name }), "Id", "Name");
                return View(location);
            }
        }

        //
        // GET: /Locations/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_locationRepository.Find(id));
        }

        //
        // POST: /Locations/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _locationRepository.Delete(id);
            _locationRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

