using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;

namespace backend.Services
{
    interface ICommentService
    {
        Task<ICollection<CommentObject>> GetAllComments(int limit, int postId);
        Task<CommentObject> GetComment(int commentId);
        Task<int> CreateComment(CommentObject comObj, int postId);
        Task<int> UpdateComment(CommentObject comObj, int id);
        Task<int> DeleteComment(int id);
    }
}
