using System;
using System.ComponentModel.DataAnnotations;

namespace BenWilson295nTermProject.Models
{
    public class Post
    {
        public enum Board
        {
            Touring,
            Bmx,
            Bikepacking
        }
        public int PostId { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public Board BoardProperty { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
