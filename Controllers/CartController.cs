using RusterShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RusterShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            List<Product> cart = new List<Product>();
            if (Session["Cart"] != null)
            {
                cart = (List<Product>)Session["Cart"];
            }
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {
            List<Product> cart = new List<Product>();
            if (Session["Cart"] != null)
            {
                cart = (List<Product>)Session["Cart"];
            }
            using (RusterEntities db = new RusterEntities())
            {
                cart.Add(db.Products.Find(id));
            }
            Session["Cart"] = cart;
            int count = 0;
            decimal? total = 0;
            foreach (Product p in cart)
            {
                count++;
                total += p.Price;
            }
            Session["CartCount"] = count;
            Session["total"] = total;

            return RedirectToAction("Index", "Home");
        }
    }
}