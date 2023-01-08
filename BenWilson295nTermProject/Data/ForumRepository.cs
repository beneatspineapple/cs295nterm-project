using BenWilson295nTermProject;
using BenWilson295nTermProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BenWilson295nTermProject.Data
{
    public class ForumRepository : IForumRepository
    {
        private AppDbContext context;
        public List<Post> Posts { get; set; }
        public List<Board> Boards { get; set; }
        public ForumRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
            Posts = context.ForumPosts.ToList();
            Boards = context.Boards.ToList();
            if (!context.Boards.Any())
            {
                Board touring = new Board() { BoardSubject = BoardOptions.Touring };
                Board bmx = new Board() { BoardSubject = BoardOptions.Bmx };
                Board bikePacking = new Board() { BoardSubject = BoardOptions.Bikepacking };

                context.Boards.AddRange(touring, bmx, bikePacking);
                context.SaveChanges();
            }
        }

        public Post GetPostById(int id)
        {
            var post = context.ForumPosts
                .Where(post => post.PostId == id)
                .SingleOrDefault();
            return post;
        }
        /*public List<Post> PopulateForum()
        {
            return context.ForumPosts.OrderByDescending(post => post.DatePosted).ToList();
        }*/

        public int StoreBoard(Board board)
        {
            context.Boards.Add(board);
            return context.SaveChanges();
        }

        public int StorePost(Post model)
        {
            context.ForumPosts.Add(model);
            return context.SaveChanges();
        }

        public int UpdateBoard(Board board)
        {
            context.Boards.Update(board);
            return context.SaveChanges();
        }

        public int UpdatePost(Post post)
        {
            context.ForumPosts.Update(post);
            return context.SaveChanges();
        }
    }
}
