using System;
using System.Collections.Generic;

namespace backend.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public int CommentCount { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}
