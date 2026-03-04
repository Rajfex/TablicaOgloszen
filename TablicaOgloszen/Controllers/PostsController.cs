using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TablicaOgloszen.Models;
using System.Linq;
using TablicaOgloszen.Interfaces;

namespace TablicaOgloszen.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService _postsService;

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        // GET: Posts
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 2;
            var posts = await _postsService.GetRecentPosts(10, page, pageSize);
            ViewBag.CurrentPage = page;
            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description")] Post post)
        {
            if (ModelState.IsValid)
            {
                await _postsService.CreatePost(post);
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Details/:id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var post = await _postsService.GetPostById(id.Value);
            if (post == null)
                return NotFound();

            return View(post);
        }

        // GET: Posts/ConfirmPost
        public IActionResult ConfirmPost(Post post)
        {
            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
