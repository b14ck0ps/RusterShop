//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RusterShop.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductsOrder
    {
        public int ProductsOrdersID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> quantity { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
