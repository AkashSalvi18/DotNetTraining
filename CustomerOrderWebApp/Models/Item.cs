using System.ComponentModel.DataAnnotations;

namespace CustomerOrderWebApp.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal Price { get; set; }
    }
}
