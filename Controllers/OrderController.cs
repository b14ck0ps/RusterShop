using RusterShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RusterShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly RusterEntities _db = new RusterEntities();
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = new List<Order>();
            orders = _db.Orders.Where(o => o.CustomerID == 1).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            Order order = _db.Orders.Find(id);
            List<ProductsOrder> productsOrders = _db.ProductsOrders.Where(po => po.OrderID == id).ToList();
            List<Product> products = new List<Product>();
            foreach (ProductsOrder po in productsOrders)
            {
                Product product = _db.Products.Find(po.ProductID);
                products.Add(product);
            }
            ViewBag.Order = order;
            return View(products);
        }
        public ActionResult Checkout()
        {
            var cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Order order = new Order
            {
                OrderDate = DateTime.Now,
                CustomerID = 1

            };
            _db.Orders.Add(order);
            _db.SaveChanges();

            foreach (Product p in cart)
            {
                ProductsOrder po = new ProductsOrder
                {
                    OrderID = order.OrderID,
                    ProductID = p.ProductID,
                };
                _db.ProductsOrders.Add(po);
                _db.SaveChanges();
            }
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}