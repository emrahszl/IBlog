using Microsoft.AspNetCore.Mvc;

namespace IBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PostController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var post = _db.Posts.Find(id);

            if (post == null)
                return NotFound();

            return View(post);
        }
    }
}
