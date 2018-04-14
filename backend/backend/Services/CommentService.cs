using backend.DataObjects;
using backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Repositories;

namespace backend.Services
{
    public class CommentService : ICommentService
    {

        private ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<ICollection<Comment>> GetAllComments(int limit, long postId)
        {
            return await _commentRepository.GetAllComments(limit, postId);
        }

        public async Task<Comment> GetComment(long commentId)
        {
            return await _commentRepository.GetComment(commentId);
        }

        public async Task<long> CreateComment(CommentObject comObj, long postId)
        {
            return await _commentRepository.CreateComment(comObj, postId);
        }

        public async Task<long> UpdateComment(CommentObject comObj, long id)
        {
            return await _commentRepository.UpdateComment(comObj, id);
        }

        public async Task<int> DeleteComment(long id)
        {
            return await _commentRepository.DeleteComment(id);
        }
    }
}
