using backend.DataObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
    public interface ICommentRepository
    {
        Task<ICollection<Comment>> GetAllComments(int limit, long postId);
        Task<Comment> GetComment(long commentId);
        Task<long> CreateComment(CommentObject comObj, long postId);
        Task<long> UpdateComment(CommentObject comObj, long id);
        Task<int> DeleteComment(long id);
    }
}
