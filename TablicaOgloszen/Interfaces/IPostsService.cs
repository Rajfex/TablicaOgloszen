using TablicaOgloszen.Models;

namespace TablicaOgloszen.Interfaces
{
    public interface IPostsService
    {
        Task<List<Post>> GetRecentPosts(int days, int page, int pageSize);
        Task<Post?> GetPostById(int id);
        Task CreatePost(Post post);
    }
}
