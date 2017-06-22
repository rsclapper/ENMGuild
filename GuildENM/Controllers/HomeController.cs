using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildENM.Data;
using GuildENM.Models.Repositories;

namespace GuildENM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILocationRepository locationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IPostRepository postRepository;

        // If you are using Dependency Injection, you can delete the following constructor
        public HomeController() : this(new LocationRepository(), new CompanyRepository(), new PostRepository())
        {
        }
        public HomeController(ILocationRepository locationRepository, ICompanyRepository companyRepository, IPostRepository postRepository)
        {
            this.locationRepository = locationRepository;
            this.companyRepository = companyRepository;
            this.postRepository = postRepository;
        }
        public ActionResult Index()
        {
            return View(postRepository.AllIncluding(post => post.Location, post => post.Company, post => post.Comments).Where(p => p.PostDate <= DateTime.Now).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}