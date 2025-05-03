using CustomerOrderWebApp.Data;
using CustomerOrderWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrderWebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly CustOrderContext _context;

        public ItemController(CustOrderContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(item);
                _context.SaveChanges();
                return RedirectToAction("Index", "Item");
            }
            return View(item);
        }

        public IActionResult Index()
        {
            var items = _context.Items.ToList();
            return View(items);
        }
    }
}
