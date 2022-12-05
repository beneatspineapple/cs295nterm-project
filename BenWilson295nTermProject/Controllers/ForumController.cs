using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenWilson295nTermProject.Controllers
{
    public class ForumController : Controller
    {
        AppDbContext context;

        public ForumController(AppDbContext c)
        {
            context = c;
        }

        public IActionResult Index()
        {
            List<Post> posts = context.ForumPosts.OrderByDescending(post => post.DatePosted).ToList();

            return View(posts);
        }
        public IActionResult Post(int PostId)
        {

            Post post = context.ForumPosts.Find(PostId);

            return View(post);
        }

        public IActionResult Forum()
        {
            /*PostModel newPost = new PostModel();
            return View(newPost);*/
            return View();
        }

        [HttpPost]
        public IActionResult Forum(Post model)
        {
            model.DatePosted = DateTime.Now;
            context.ForumPosts.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
