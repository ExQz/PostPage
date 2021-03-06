﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;
using backend.Models;

namespace backend.Services
{
    public interface ICommentService
    {
        Task<ICollection<Comment>> GetAllComments(int limit, long postId);
        Task<Comment> GetComment(long commentId);
        Task<long> CreateComment(CommentObject comObj, long postId);
        Task<long> UpdateComment(CommentObject comObj, long id);
        Task<int> DeleteComment(long id);
    }
}
