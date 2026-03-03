using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Models;
using System.Linq;

namespace TablicaOgloszen.Controllers
{
    public class PostsController : Controller
    {
        private readonly AppDbContext _context;

        public PostsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int page = 1)
        {
            DateTime now = DateTime.Now;
            DateTime sinseWhen = now.AddDays(-10);

            var posts = _context.Posty
                .Where(p => p.Date >= sinseWhen)
                .OrderByDescending(p => p.Date);

            int pageSize = 2;
            var postsReturn = await posts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;

            return View(postsReturn);
        }


        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Details/:id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _context.Posty
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // GET: Posts/ConfirmPost
        public async Task<IActionResult> ConfirmPost(Post post)
        {
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }
    }
}
