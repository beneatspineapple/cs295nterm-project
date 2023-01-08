using System;
using System.ComponentModel.DataAnnotations;

namespace BenWilson295nTermProject.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public BoardOptions BoardProperty { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
