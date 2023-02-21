using RusterShop.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RusterShop.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = new List<Product>();
            if (Session["Cart"] != null)
            {
                cart = (List<Product>)Session["Cart"];
            }
            return View(cart);
        }

        public ActionResult AddToCart(int id, string single)
        {
            decimal? total = 0;
            var cart = new List<Product>();
            if (Session["Cart"] != null)
            {
                cart = (List<Product>)Session["Cart"];
            }
            if (Session["total"] != null)
            {
                total = (decimal)Session["total"];
            }

            //check if item already exist in cart session
            if (cart.Any(x => x.ProductID == id))
            {
                //if exist then increase quantity and update total
                foreach (var item in cart.Where(item => item.ProductID == id))
                {
                    item.quantity++;
                    total += item.Price;
                }
            }
            else
            {
                //add a new item to cart session and update total
                using (var db = new RusterEntities())
                {
                    var product = db.Products.Find(id);
                    if(product == null) return RedirectToAction("Index", "Home");
                    product.quantity = 1;
                    cart.Add(product);
                    total += product.Price * product.quantity;
                }

            }

            var name = cart.FirstOrDefault(x => x.ProductID == id)?.ProductName;
            var quantity = cart.FirstOrDefault(x => x.ProductID == id)?.quantity;
            Session["Cart"] = cart;
            Session["CartCount"] = cart.Count;
            Session["total"] = total;
            TempData["Success"] = $"{quantity}X ({name}) added to cart";
            return single != null ? RedirectToAction("Index") : RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id)
        {
            //remove a item from cart
            List<Product> cart;
            if (Session["cart"] != null)
            {
                cart = (List<Product>)Session["cart"];
            }
            else
            {
                return RedirectToAction("Index");
            }

            if (cart.Any(x => x.ProductID == id))
            {
                foreach (var item in cart.Where(item => item.ProductID == id))
                {
                    item.quantity--;
                    decimal? totalPrice = (decimal)Session["total"];
                    totalPrice -= item.Price;
                    Session["total"] = totalPrice;
                    if (item.quantity != 0) continue;
                    cart.Remove(item);
                    Session["CartCount"] = cart.Count;
                    break;
                }
            }
            var name = cart.FirstOrDefault(x => x.ProductID == id)?.ProductName;
            TempData["removed"] = $"1X {name} removed from cart";
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
        public ActionResult Clear()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}