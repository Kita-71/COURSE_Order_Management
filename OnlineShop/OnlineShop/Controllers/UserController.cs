using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class UserController : Controller
    {
        private OnlineShoppingEntities db = new OnlineShoppingEntities();
        // GET: User
        public ActionResult UsersIndex2()
        {
            TempData.Keep("userid");
            return View();
        }
        public ActionResult UsersIndex(int id)
        {
            TempData["userid"] = id;
            TempData.Keep("userid");
            return View();
        }
        public ActionResult OrderStatu1()
        {
            ViewBag.userid= (int)TempData["userid"];
            TempData.Keep("userid");
            return View(db.Order.ToList());
        }
        public ActionResult OrderStatu2()
        {
            ViewBag.userid = (int)TempData["userid"];
            TempData.Keep("userid");
            return View(db.Order.ToList());
        }
        public ActionResult OrderStatu3()
        {
            ViewBag.userid = (int)TempData["userid"];
            TempData.Keep("userid");
            return View(db.Order.ToList());
        }
        public ActionResult OrderInfo(int id)
        {
            Order t_order = db.Order.FirstOrDefault(s => s.ID == id);
            TempData["orderid"] = id;
            TempData.Keep("orderid");
            return View(t_order);
        }
    }
}