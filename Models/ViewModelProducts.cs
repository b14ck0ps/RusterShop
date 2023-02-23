using System.ComponentModel.DataAnnotations;

namespace RusterShop.Models
{
    public class ViewModelProducts
    {
        public int ProductID { get; set; }
        [Required] public string ProductName { get; set; }
        [Required] public int CategoryID { get; set; }
        [Required] public decimal Price { get; set; }
        [Required]public int quantity { get; set; }
        public ViewModelCategory Category { get; set; }
    }
}