using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Controllers
{   
    public class CompaniesController : Controller
    {
		private readonly ICompanyRepository companyRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public CompaniesController() : this(new CompanyRepository())
        {
        }

        public CompaniesController(ICompanyRepository companyRepository)
        {
			this.companyRepository = companyRepository;
        }

        //
        // GET: /Companies/

        public ViewResult Index()
        {
            return View(companyRepository.AllIncluding(company => company.Posts));
        }

        //
        // GET: /Companies/Details/5

        public ViewResult Details(int id)
        {
            return View(companyRepository.Find(id));
        }

        //
        // GET: /Companies/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Companies/Create

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid) {
                companyRepository.InsertOrUpdate(company);
                companyRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Companies/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(companyRepository.Find(id));
        }

        //
        // POST: /Companies/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid) {
                companyRepository.InsertOrUpdate(company);
                companyRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Companies/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(companyRepository.Find(id));
        }

        //
        // POST: /Companies/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            companyRepository.Delete(id);
            companyRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                companyRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

