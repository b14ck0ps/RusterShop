using System.Collections.Generic;

namespace RusterShop.Models
{
    public class ViewModelCustomer
    {
        public  int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public ICollection<ViewModelOrders> Orders { get; set; }
    }
}