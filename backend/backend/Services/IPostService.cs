using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataObjects;

namespace backend.Services
{
    interface IPostService
    {
        Task<ICollection<PostObject>> GetAllPost(int limit);
        Task<PostObject> GetPost(int id);
        Task<int> CreatePost(PostObject postObj);
        Task<int> UpdatePost(PostObject postObj, int id);
        Task<int> DeletePost(int id);

    }
}
