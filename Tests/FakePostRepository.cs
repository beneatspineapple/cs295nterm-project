using BenWilson295nTermProject.Data;
using BenWilson295nTermProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FakePostRepository : IForumRepository
    {
        private List<Post> posts = new List<Post> { new Post { PostId = 1 } };

        /*private PostModel p = new PostModel();
        p = 1;*/
        public List<Post> PopulateForum()
        {
            return posts;
        }
        public Post GetPostById(int id)
        {
            Post post = posts.Find(p => p.PostId == id);

            return post;
        }

        public int StorePost(Post model)
        {
            int status = 0;
            if (model != null)
            {
                model.PostId = posts.Count + 1;
                posts.Add(model);
                status = 1;
            }
            return status;
        }
    }
}
