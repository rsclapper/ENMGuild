using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models;
using GuildENM.Models.Repositories;
using System.Linq;

namespace GuildENM.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly Uow _uow;

        // If you are using Dependency Injection, you can delete the following constructor
        public CompaniesController() : this(new Uow())
        {
        }

        public CompaniesController(Uow uow)
        {
            this._uow = uow;
        }

        //
        // GET: /Companies/

        public ViewResult Index()
        {
            return View(_uow.Companies.All);
        }

        //
        // GET: /Companies/Details/5

        public ViewResult Details(int id)
        {
            return View(_uow.Companies.Find(id));
        }

        //
        // GET: /Companies/Create

        public ActionResult Create()
        {
            return View(new CreateCompanyVM());
        }

        //
        // POST: /Companies/Create

        [HttpPost]
        public ActionResult Create(CreateCompanyVM model)
        {
            if (ModelState.IsValid)
            {
                ILocationRepository locationRepo = new LocationRepository();
                _uow.Companies.InsertOrUpdate(model.Company);
                _uow.Save();
                model.Contact.CompanyId = model.Company.Id;
                _uow.Contacts.InsertOrUpdate(model.Contact);
                _uow.Save();

                model.Location.Company = model.Company;
                _uow.Locations.InsertOrUpdate(model.Location);
                model.Company.DefaultContact = model.Contact;
                _uow.Companies.InsertOrUpdate(model.Company);


                _uow.Save();
                return RedirectToAction("Edit", new { id = model.Company.Id });
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /Companies/Edit/5
        [HttpPost]
        public ActionResult CreateContact(int id, Contact model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                model.CompanyId = id;
                _uow.Contacts.InsertOrUpdate(model);
                _uow.Save();
            return RedirectToAction("Edit", new { id = id });
            }
            return RedirectToAction("Edit", new { id = id });

        }
        [HttpPost]
        public ActionResult CreateAddress(Location model)
        {
            if (ModelState.IsValid)
            {
                _uow.Locations.InsertOrUpdate(model);
                _uow.Save();
                return RedirectToAction("Edit", new { id = model.CompanyId });
            }
            return RedirectToAction("Edit", new { id = model.CompanyId });

        }
        public ActionResult Edit(int id)
        {
            IQueryable<Company> query = _uow.Companies.AllIncluding(p => p.Contacts);
            Company m = query.FirstOrDefault(r => r.Id == id);
            return View(m);
        }

        //
        // POST: /Companies/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _uow.Companies.InsertOrUpdate(company);
                _uow.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //
        // GET: /Companies/Delete/5

        public ActionResult Delete(int id)
        {
            return View(_uow.Companies.Find(id));
        }

        //
        // POST: /Companies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.Companies.Delete(id);
            _uow.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

