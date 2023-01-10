using Microsoft.AspNetCore.Mvc;
using BenWilson295nTermProject.Models;
using System.Linq;
using BenWilson295nTermProject.Data;
using System.Collections.Generic;

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
            Board board = repo.Boards.FirstOrDefault(board => board.BoardSubject == boardProperty) ??
                new Board() 
                { 
                    BoardSubject = boardProperty 
                };
            return View(board);
        }

        public IActionResult Post(int PostId)
        {
            Post post = repo.GetPostById(PostId);

            return View(post);
        }

        public IActionResult Forum(BoardOptions boardProperty)
        {
            Post post = new Post()
            {
                BoardProperty = boardProperty
            };
            return View(post);
        }

        [HttpPost]
        public IActionResult Forum(Post post)
        {
            
            Board board = repo.Boards.FirstOrDefault(board => board.BoardSubject == post.BoardProperty);
            if (board == null)
            {
                board = new Board();
                board.BoardSubject = post.BoardProperty;

                repo.Boards.Add(board);
            }
            if (board.BoardPosts == null)
            {
                board.BoardPosts = new List<Post>();
            }
            board.BoardPosts.Add(post);
            repo.UpdateBoard(board);
            return View("Boards", board);
        }
    }
}
