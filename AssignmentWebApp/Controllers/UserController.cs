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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            DemoRepository.DeleteUser(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = DemoRepository.Users.FirstOrDefault(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = DemoRepository.Users.FirstOrDefault(u => u.UserId == user.UserId);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Update any other fields if necessary
                }
                return RedirectToAction("List");
            }
            return View(user);
        }

    }
}
