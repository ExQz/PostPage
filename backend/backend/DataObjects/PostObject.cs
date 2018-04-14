using System;

namespace backend.DataObjects
{
    public class PostObject
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public int CommentCount { get; set; }
    }
}
