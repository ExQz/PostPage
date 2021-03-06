﻿using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DataObjects;

namespace backend.Services
{
    public interface IPostService
    {
        Task<ICollection<Post>> GetAllPosts(int limit);
        Task<Post> GetPost(long id);
        Task<long> CreatePost(PostObject postObj);
        Task<long> UpdatePost(PostObject postObj, long id);
        Task<long> DeletePost(long id);

    }
}
