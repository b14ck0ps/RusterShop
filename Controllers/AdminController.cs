﻿using RusterShop.EF;
using System.Linq;
using System.Web.Mvc;
using RusterShop.Models;

namespace RusterShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly RusterEntities _db = new RusterEntities();

        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        public ActionResult CreateNewProduct()
        {
            ViewBag.Category = _db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewProduct(ViewModelProducts product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Category = _db.Categories.ToList();
                return View(product);
            }

            _db.Products.Add(AutoMapper.Mapper.Map<ViewModelProducts, Product>(product));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditProduct(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return HttpNotFound();
            ViewBag.Category = _db.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid) return View(product);
            var productInDb = _db.Products.Find(product.ProductID);
            if (productInDb == null) return RedirectToAction("Index");
            productInDb.ProductName = product.ProductName;
            productInDb.CategoryID = product.CategoryID;
            productInDb.Price = product.Price;
            productInDb.quantity = product.quantity;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductDetails(int id)
        {
            var product = _db.Products.Find(id);
            return product == null ? (ActionResult)HttpNotFound() : View(product);
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);
            if (product == null) return HttpNotFound();
            _db.Products.Remove(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddCategory()
        {
            return View(_db.Categories.ToList());
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (!ModelState.IsValid) return View();
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("AddCategory");
        }
    }
}