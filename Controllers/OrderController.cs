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
        // GET: Order
        public ActionResult Index()
        {
            List<Order> orders = new List<Order>();
            using (RusterEntities db = new RusterEntities())
            {
                orders = db.Orders.Where(o => o.CustomerID == 1).ToList();
            }
            return View(orders);
        }

        public ActionResult Checkout()
        {
            var cart = (List<Product>)Session["Cart"];
            if (cart == null)
            {
                return RedirectToAction("Index", "Home");
            }
            using (RusterEntities db = new RusterEntities())
            {
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerID = 1

                };
                db.Orders.Add(order);
                db.SaveChanges();

                foreach (Product p in cart)
                {
                    ProductsOrder po = new ProductsOrder
                    {
                        OrderID = order.OrderID,
                        ProductID = p.ProductID,
                    };
                    db.ProductsOrders.Add(po);
                }
                db.SaveChanges();
            }
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}