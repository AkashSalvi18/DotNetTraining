using CustomerOrderWebApp.Models;

namespace CustomerOrderWebApp.ViewModels
{
    public class OrderItemViewModel
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = string.Empty;// For display only
        public string ItemDesc { get; set; } = string.Empty;// For display only

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Cost => Quantity * UnitPrice;
    }

    public class OrderFormViewModel
    {
        // Customer details
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ModeOfPayment { get; set; }

        // Items for selection
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
        public List<Item> AvailableItems { get; set; } = new List<Item>();

    }
}
