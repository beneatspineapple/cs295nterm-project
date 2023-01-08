using System;

namespace BenWilson295nTermProject.Models
{
    public class PostReply
    {
        public int PostReplyId { get; set; }
        public string Text { get; set; }
        public string Name { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
