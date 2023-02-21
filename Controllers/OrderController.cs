using RusterShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RusterShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly RusterEntities _db = new RusterEntities();

        // GET: Order
        public ActionResult Index()
        {
            var orders = _db.Orders.Where(o => o.CustomerID == 1).ToList();
            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var order = _db.Orders.Find(id);
            var productsOrders = _db.ProductsOrders.Where(po => po.OrderID == id).ToList();
            var products = new List<Product>();
            foreach (var po in productsOrders)
            {
                var product = _db.Products.Find(po.ProductID);
                if (product == null) continue;
                product.quantity = po.quantity;
                products.Add(product);
            }

            ViewBag.Order = order;
            return View(products);
        }

        public ActionResult Checkout()
        {
            var cart = (List<Product>)Session["Cart"];
            if (cart == null) return RedirectToAction("Index", "Home");
            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = (decimal)Session["total"],
                CustomerID = 1
            };
            _db.Orders.Add(order);
            _db.SaveChanges();

            foreach (var productsOrder in cart.Select(p => new ProductsOrder
                     {
                         OrderID = order.OrderID,
                         ProductID = p.ProductID,
                         quantity = p.quantity
                     }))
            {
                _db.ProductsOrders.Add(productsOrder);
                _db.SaveChanges();
            }

            Session.Clear();
            TempData["Message"] = "Thank you for your order!";
            return RedirectToAction("Index");
        }
    }
}