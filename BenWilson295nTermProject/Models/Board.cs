using System;
using System.Collections.Generic;

namespace BenWilson295nTermProject.Models
{
    public class Board
    {
        public int BoardID { get; set; }
        public List<Post> BoardPosts { get; set; } = default!;
        public BoardOptions BoardSubject { get; set; } = default!;
    }
}
