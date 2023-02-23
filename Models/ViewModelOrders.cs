using System.Collections.Generic;

namespace RusterShop.Models
{
    public class ViewModelOrders
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalPrice { get; set; }
        public ViewModelCustomer Customer { get; set; }
        public ICollection<ViewModelProductsOrders> ProductsOrders { get; set; }
    }
}