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
        public ForumRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public Post GetPostById(int id)
        {
            var post = context.ForumPosts
                .Where(post => post.PostId == id)
                .SingleOrDefault();
            return post;
        }
        public List<Post> PopulateForum()
        {
            return context.ForumPosts.OrderByDescending(post => post.DatePosted).ToList();
        }
        public int StorePost(Post model)
        {
            model.DatePosted = DateTime.Now;
            context.ForumPosts.Add(model);
            return context.SaveChanges();
        }
    }
}
