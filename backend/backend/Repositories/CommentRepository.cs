using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;
using backend.DB;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
    //    private DatabaseContext _database;

    //    public PostRepository(DatabaseContext database)
    //    {
    //        _database = database;
    //    }

        private DatabaseContext _database;

        public CommentRepository(DatabaseContext database)
        {
            _database = database;
        }
        public async Task<ICollection<Comment>> GetAllComments(int limit, long postId)
        {
            return await _database.Comments.Where(i => i.PostId == postId).Take(limit).ToArrayAsync();
        }

        public async Task<Comment> GetComment(long commentId)
        {
            return await _database.Comments.FirstOrDefaultAsync(i => i.Id==commentId);
        }

        public async Task<long> CreateComment(CommentObject comObj, long postId)
        {
            var post = await _database.Posts.FirstOrDefaultAsync(i => i.Id == postId);
            if (post == null) return -1;

            var comment = new Comment()
            {
                Author = comObj.Author,
                Text = comObj.Text,
                CreateDate = DateTime.Now,
                PostId = postId,
                Post = post
            };
            post.CommentCount++;
            await _database.AddAsync(comment);
            await _database.SaveChangesAsync();
            return comment.Id;
        }

        public async Task<long> UpdateComment(CommentObject comObj, long id)
        {
            var comment = await _database.Comments.FirstOrDefaultAsync(i => i.Id == id);
            if (comment == null) return -1;

            comment.Author = comObj.Author;
            comment.CreateDate = DateTime.Now;
            comment.Text = comObj.Text;
            await _database.SaveChangesAsync();

            return comment.Id;
        }

        public async Task<int> DeleteComment(long id)
        {
            var comment = await _database.Comments.FirstOrDefaultAsync(i => i.Id == id);
            if (comment == null) return -1;
            var post = await _database.Posts.FirstOrDefaultAsync(i => i.Id == comment.PostId);
            if (post == null) return -1;
            post.CommentCount--;
            _database.Remove(comment);

            await _database.SaveChangesAsync();

            return 1;
        }
    }
}
