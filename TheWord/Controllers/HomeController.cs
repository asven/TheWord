using SubSonic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWord.Models;

namespace TheWord.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SimpleRepository repo = new SimpleRepository("TheWord", SimpleRepositoryOptions.RunMigrations);

            List<GaryPost> posts = repo.All<GaryPost>().OrderByDescending(gp => gp.PostedDate).ToList();
            return View();
        }
    }
}
