using SubSonic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheWord.Common;
using TheWord.Models;

namespace TheWord.Controllers
{
    public class PostsController : Controller
    {

        public ActionResult Index()
        {
            SimpleRepository repo = new SimpleRepository("TheWord");

            return View(GaryPostManager.GetUsersPosts(User.Identity.Name));
        }


        public ActionResult AddNewPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult SavePost([System.Web.Http.FromBody] GaryPost garyPost)
        {
            GaryPostManager.SavePost(garyPost, User.Identity.Name);

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult EditPost(int garyPostId)
        {
            return View(GaryPostManager.GetPostById(garyPostId));
        }

        [Authorize]
        [System.Web.Http.HttpPost]
        public ActionResult DeletePost(int garyPostId)
        {
            GaryPostManager.DeletePost(garyPostId);

            return RedirectToAction("Index");
        }

    }
}
