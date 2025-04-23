using AssignmentWebApp.Data;
using AssignmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user) {
            if (ModelState.IsValid)
            {
                DemoRepository.Users.Add(user);
                return RedirectToAction("List");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult List()
        {
            var users = DemoRepository.Users;
            return View(users);
        }
    }
}
