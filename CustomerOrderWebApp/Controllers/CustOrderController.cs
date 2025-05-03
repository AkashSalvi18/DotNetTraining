using CustomerOrderWebApp.Data;
using CustomerOrderWebApp.Models;
using CustomerOrderWebApp.ViewModels;
using CustomerOrderWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerOrderDemo.Controllers
{
    public class CustOrderController : Controller
    {
        private readonly CustOrderContext _context;
        public CustOrderController(CustOrderContext _db)
        {
            _context = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var items = await _context.Items.ToListAsync();
            // Just initialize with empty one item row (or more if you like)
            var model = new OrderFormViewModel
            {
                OrderItems = new List<OrderItemViewModel > { new OrderItemViewModel() },
                AvailableItems = items
            };

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(OrderFormViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Items = new SelectList(_context.Items, "ItemId", "ItemName");
        //        return View(model);
        //    }

        //    var customer = new Customer
        //    {
        //        Name = model.Name,
        //        Address = model.Address,
        //        PhoneNumber = model.PhoneNumber,
        //        ModeOfPayment = model.ModeOfPayment
        //    };

        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();

        //    var order = new CustomerOrder
        //    {
        //        Customer = customer,
        //        OrderDate = DateTime.Now,
        //        Status = "Completed",
        //        OrderItems = new List<OrderItem>()
        //    };

        //    foreach (var item in model.OrderItems.Where(x => x.Quantity > 0))
        //    {
        //        var newItem = new Item
        //        {
        //            ItemName = item.ItemName,
        //            ItemDesc = item.ItemDesc,
        //            Price = item.UnitPrice
        //        };

        //        _context.Items.Add(newItem);
        //        await _context.SaveChangesAsync();

        //        var orderItem = new OrderItem
        //        {
        //            ItemId = newItem.ItemId,
        //            Quantity = item.Quantity
        //        };

        //        //order.OrderItems ??= new List<OrderItem>();
        //        order.OrderItems.Add(orderItem);
        //    }


        //    _context.CustomerOrders.Add(order);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Success");
        //}
        [HttpPost]
        public async Task<IActionResult> Create(OrderFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Items = new SelectList(_context.Items, "ItemId", "ItemName");
                return View(model);
            }

            // 1. Create and save customer first
            var customer = new Customer
            {
                Name = model.Name,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                ModeOfPayment = model.ModeOfPayment
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync(); // Now customer.CustomerId is generated

            // 2. Create order and link customer
            var order = new CustomerOrder
            {
                CustomerId = customer.CustomerId,  // Explicitly set FK
                OrderDate = DateTime.Now,
                Status = "Completed",
                OrderItems = new List<OrderItem>()
            };

            // 3. Add each order item
            foreach (var item in model.OrderItems.Where(x => x.Quantity > 0))
            {
                // Find or create item
                var existingItem = await _context.Items
                    .FirstOrDefaultAsync(i => i.ItemName == item.ItemName && i.ItemDesc == item.ItemDesc);

                Item linkedItem = existingItem ?? new Item
                {
                    ItemName = item.ItemName,
                    ItemDesc = item.ItemDesc,
                    Price = item.UnitPrice
                };

                // Save new item if needed
                if (existingItem == null)
                {
                    _context.Items.Add(linkedItem);
                    await _context.SaveChangesAsync();
                }

                // Create order item
                order.OrderItems.Add(new OrderItem
                {
                    ItemId = linkedItem.ItemId,
                    Quantity = item.Quantity
                });
            }

            // 4. Save order (EF will cascade OrderItems)
            _context.CustomerOrders.Add(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success");
        }



        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return View(new List<Customer>()); // Return empty list if no term provided
            }

            var matchingCustomers = await _context.Customers
                .Where(c => c.Name.Contains(searchTerm))
                .ToListAsync();

            return View(matchingCustomers);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
