using BenWilson295nTermProject.Models;
using System.Collections.Generic;

namespace BenWilson295nTermProject.Data
{
    public interface IForumRepository
    {
        public Post GetPostById(int id);
        public int StorePost(Post post);
        public List<Post> PopulateForum();
    }
}
