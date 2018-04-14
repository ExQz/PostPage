using System;

namespace backend.Models
{
    public class Comment
    {
        
        public long Id { get; set; }

        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public long PostId { get; set; }
        public Post Post { get; set; }

    }
}
