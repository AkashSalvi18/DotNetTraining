using CustomerOrderWebApp.Data;
using CustomerOrderWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderWebApp.Controllers
{
    public class OrderSearchController : Controller
    {
        private readonly CustOrderContext _context;

        public OrderSearchController(CustOrderContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm) 
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View(new List<CustomerOrder>());
            }
            var orders = await _context.CustomerOrders
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Item)
                .Where(o => o.Customer.Name.Contains(searchTerm))
                .ToListAsync();

            return View(orders);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
