﻿using RusterShop.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RusterShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly RusterEntities _db = new RusterEntities();
        public ActionResult Index()
        {
            ViewBag.Cart = Session["Cart"];
            return View(_db.Products.ToList());
        }
    }
}