using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using BenWilson295nTermProject.Data;
using AspNetCore;

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
            Post post = new Post();
            return View(post);
        }

        public IActionResult Boards(Post.Board boardProperty)
        {
            List<Post> posts = repo.PopulateForum();
            posts = posts.Where(post => post.BoardProperty == boardProperty).ToList();
            return View(posts);
        }
        public IActionResult Post(int PostId)
        {

            Post post = repo.GetPostById(PostId);

            return View(post);
        }

        public IActionResult Forum(Post.Board boardProperty)
        {
            Post post = new Post();
            post.BoardProperty = boardProperty;
            return View(post);
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
                return View(model);
            }
        }
    }
}
