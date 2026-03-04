using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Interfaces;
using TablicaOgloszen.Models;

namespace TablicaOgloszen.Services
{
    public class PostsService : IPostsService
    {
        private readonly AppDbContext _context;

        public PostsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetRecentPosts(int days, int page, int pageSize)
        {
            DateTime sinceWhen = DateTime.Now.AddDays(-days);

            return await _context.Posts
                .Where(p => p.Date >= sinceWhen)
                .OrderByDescending(p => p.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Post?> GetPostById(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
    }
}
