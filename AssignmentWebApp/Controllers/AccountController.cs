using AssignmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulate authentication (no DB)
                if ((model.Username == "admin" && model.Password == "password")|| (model.Username == "akash" && model.Password == "password"))
                {
                    // Store Username in session
                    HttpContext.Session.SetString("Username", model.Username);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Username or Password doesn't exist");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}
