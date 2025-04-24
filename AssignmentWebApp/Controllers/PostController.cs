using AssignmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index(int id = 1)
        {
            var post = new PostViewModel
            {
                Id = 1,
                Title = "What is ASP.NET Core",
                Author = "Shailendra Chauhan",
                Body = "ASP.NET Core is an open-source framework..."
            };
            return View(post);
        }
    }
}
