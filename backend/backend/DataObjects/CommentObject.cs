using System;
using backend.Models;

namespace backend.DataObjects
{
    public class CommentObject
    {

        public long Id { get; set; } // table id

        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public long PostId { get; set; }

        public Post Post { get; set; }

    }
}
