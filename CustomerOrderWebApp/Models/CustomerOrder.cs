using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApp.Models
{
    public class CustomerOrder
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
