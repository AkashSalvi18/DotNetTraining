using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApp.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public Item Item { get; set; }
        public CustomerOrder Order { get; set; }
    }
}
