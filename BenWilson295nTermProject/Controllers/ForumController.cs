using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BenWilson295nTermProject.Data;

namespace BenWilson295nTermProject.Controllers
{
    public class ForumController : Controller
    {
        IForumRepository repo;

        public ForumController(IForumRepository p)
        {
            repo = p;
        }

        public IActionResult Index()
        {
            List<Post> posts = repo.PopulateForum();

            return View(posts);
        }
        public IActionResult Post(int PostId)
        {

            Post post = repo.GetPostById(PostId);

            return View(post);
        }

        public IActionResult Forum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forum(Post model)
        {
            if (repo.StorePost(model) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
