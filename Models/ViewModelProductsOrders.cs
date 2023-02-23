namespace RusterShop.Models
{
    public class ViewModelProductsOrders
    {
        public int ProductsOrdersID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int quantity { get; set; }
        public ViewModelProducts Product { get; set; }
        public ViewModelOrders Order { get; set; }
    }
}