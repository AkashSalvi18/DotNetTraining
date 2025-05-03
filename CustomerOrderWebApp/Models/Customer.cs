using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ModeOfPayment { get; set; }

        public ICollection<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();
    }
}
