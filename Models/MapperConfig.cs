using System;
using RusterShop.EF;

namespace RusterShop.Models
{
    public class MapperConfig
    {
        [Obsolete("Obsolete")]
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ViewModelCustomer, Customer>();
                cfg.CreateMap<Customer, ViewModelCustomer>();
                cfg.CreateMap<ViewModelOrders, Order>();
                cfg.CreateMap<Order, ViewModelOrders>();
                cfg.CreateMap<ViewModelCategory, Category>();
                cfg.CreateMap<Category, ViewModelCategory>();
                cfg.CreateMap<ViewModelProducts, Product>();
                cfg.CreateMap<Product, ViewModelProducts>();
                cfg.CreateMap<ViewModelProductsOrders, ProductsOrder>();
                cfg.CreateMap<ProductsOrder, ViewModelProductsOrders>();
            });
        }
    }
}