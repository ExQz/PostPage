using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Comment
    {
        public long Id { get; set; }

        public string CommentAuthor { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public long PostId { get; set; }

    }
}
