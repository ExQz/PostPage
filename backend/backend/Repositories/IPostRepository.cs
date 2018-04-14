using backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.DataObjects;

namespace backend.Repositories
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPosts(int limit);
        Task<Post> GetPost(long id);
        Task<long> CreatePost(PostObject pos);
        Task<long> UpdatePost(PostObject post, long id);
        Task<long> DeletePost(long id);

    }
}
