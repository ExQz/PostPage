using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;
using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class PostService : IPostService
    {

        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ICollection<Post>> GetAllPosts(int limit)
        {
            return await _postRepository.GetAllPosts(limit);
        }

        public async Task<Post> GetPost(long id)
        {
            return await _postRepository.GetPost(id);
        }

        public async Task<long> CreatePost(PostObject post)
        {
            return await _postRepository.CreatePost(post);
        }

        public async Task<long> UpdatePost(PostObject post, long id)
        {
           return await _postRepository.UpdatePost(post, id);
        }

        public async Task<long> DeletePost(long id)
        {
            return await _postRepository.DeletePost(id);
        }
    }
}

