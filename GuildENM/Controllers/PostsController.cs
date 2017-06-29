using System;
using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models;
using GuildENM.Models.Repositories;

namespace GuildENM.Controllers
{   
    public class PostsController : Controller
    {
		private readonly ILocationRepository locationRepository;
		private readonly ICompanyRepository companyRepository;
		private readonly IPostRepository postRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PostsController() : this(new LocationRepository(), new CompanyRepository(), new PostRepository())
        {
        }

        public PostsController(ILocationRepository locationRepository, ICompanyRepository companyRepository, IPostRepository postRepository)
        {
			this.locationRepository = locationRepository;
			this.companyRepository = companyRepository;
			this.postRepository = postRepository;
        }

        //
        // GET: /Posts/

        public ViewResult Index()
        {
            return View(postRepository.AllIncluding(post => post.Location, p => p.Location.Company));
        }

        //
        // GET: /Posts/Details/5

        public ViewResult Details(int id)
        {
            return View(postRepository.Find(id));
        }

        //
        // GET: /Posts/Create

        public ActionResult Create()
        {
			ViewBag.PossibleLocations = locationRepository.All;
			ViewBag.PossibleCompanies = companyRepository.All;
            return View(new Post(){PostDate = DateTime.Now, LastEdit = DateTime.Now});
        } 

        //
        // POST: /Posts/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid) {
                postRepository.InsertOrUpdate(post);
                postRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleLocations = locationRepository.All;
				ViewBag.PossibleCompanies = companyRepository.All;
				return View();
			}
        }
        
        //
        // GET: /Posts/Edit/5
 
        public ActionResult Edit(int id)
        {
			ViewBag.PossibleLocations = locationRepository.All;
			ViewBag.PossibleCompanies = companyRepository.All;
             return View(postRepository.Find(id));
        }

        //
        // POST: /Posts/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid) {
                postRepository.InsertOrUpdate(post);
                postRepository.Save();
                return RedirectToAction("Index");
            } else {
				ViewBag.PossibleLocations = locationRepository.All;
				ViewBag.PossibleCompanies = companyRepository.All;
				return View();
			}
        }

        //
        // GET: /Posts/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(postRepository.Find(id));
        }

        //
        // POST: /Posts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            postRepository.Delete(id);
            postRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                locationRepository.Dispose();
                companyRepository.Dispose();
                postRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

