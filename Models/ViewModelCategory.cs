using System.Collections.Generic;

namespace RusterShop.Models
{
    public class ViewModelCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ViewModelProducts> Products { get; set; }
    }
}