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
        public ActionResult ShoppingCar()
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
        public ActionResult NewOrder(int id)
        {
            Order new_order = new Order();
            new_order.CustomerID = (int)TempData["userid"];
            new_order.CommodityID = id;
            new_order.State = "未结算";
            TempData.Keep("userid");
            db.Order.Add(new_order);
            db.SaveChanges();
            return RedirectToAction("ShoppingCar", "User");

        }
        public ActionResult Delivered(int id)
        {
            Order t_order = db.Order.FirstOrDefault(s => s.ID == id);
            t_order.State = "订单完成";
            t_order.FinishTime = DateTime.Now.ToLocalTime();
            Commodity t_commodity = db.Commodity.FirstOrDefault(s => s.ID == t_order.CommodityID);
            t_commodity.Sales.Count++;
            t_commodity.Sales.Amount += t_commodity.Price;
            db.Entry(t_commodity).State = System.Data.Entity.EntityState.Modified;
            db.Entry(t_order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("OrderStatu2", "User");
        }
        public ActionResult DeliverInfo(int id)
        {
            Order t_order = db.Order.FirstOrDefault(s => s.ID == id);
            return View(t_order);
         }

        [HttpPost]
        public ActionResult DeliverInfo(Order update)
        {
            //调用更新操作
            update.State = "待发货";
            update.OrderTime= DateTime.Now.ToLocalTime();
            db.Entry(update).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return RedirectToAction("ShoppingCar", "User");
            }
            return View();
        }

    }
}