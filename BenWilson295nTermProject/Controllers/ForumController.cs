using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
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
            /*Post post = new Post();*/
            Board board = new Board();
            return View(board);
        }

        public IActionResult Boards(BoardOptions boardProperty)
        {
            /*List<Post> posts = repo.PopulateForum();
            posts = posts.Where(post => post.BoardProperty == boardProperty).ToList();
            return View(posts);*/
            Board board = repo.Boards.FirstOrDefault(board => board.BoardSubject == boardProperty) ??
                new Board() { BoardSubject = boardProperty };
                return View(board);
        }

        public IActionResult Post(int PostId)
        {
            Post post = repo.GetPostById(PostId);

            return View(post);
        }

        public IActionResult Forum(BoardOptions boardProperty)
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
