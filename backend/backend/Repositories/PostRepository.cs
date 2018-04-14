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
    public class PostRepository : IPostRepository
    {

        private DatabaseContext _database;

        public PostRepository(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<ICollection<Post>> GetAllPosts(int limit)
        {
            return await _database.Posts.Include(x => x.Comments).Take(limit).ToArrayAsync();
        }

        public async Task<Post> GetPost(long id)
        {
            return await _database.Posts.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<long> CreatePost(PostObject postObj)
        {
            var post = new Post()
            {
                Author = postObj.Author,
                Title = postObj.Title,
                Text = postObj.Text,
                CreateDate = DateTime.Now
            };
            await _database.AddAsync(post);
            await _database.SaveChangesAsync();
            return post.Id;
        }

        public async Task<long> UpdatePost(PostObject post, long id)
        {
            var oldPost = await _database.Posts.FirstOrDefaultAsync(x => x.Id == id);
            if (oldPost == null)
            {
                id = -1;

            }
            else
            {
                oldPost.Title = post.Title;
                oldPost.Author = post.Author;
                oldPost.Text = post.Text;
                oldPost.CreateDate = DateTime.Now;
                _database.Posts.Update(oldPost);
                await _database.SaveChangesAsync();
            }
            
            return id;
        }

        public async Task<long> DeletePost(long id)
        {
            long callBack = 1;
            var post = await _database.Posts.Where(i => i.Id == id).FirstOrDefaultAsync();
            if (post == null)
            {
                callBack = -1;
            }
            else
            {
                _database.Remove(post);
                var allComments = await _database.Comments.Where(i => i.PostId == id).ToArrayAsync();

                foreach (var comment in allComments)
                {
                    _database.Remove(comment);
                }
            }

            await _database.SaveChangesAsync();
            return callBack;
        }
    }
}
