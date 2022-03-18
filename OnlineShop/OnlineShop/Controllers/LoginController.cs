using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    //数据库连接上下文
    public class LoginController : Controller
    {
        private OnlineShoppingEntities db = new OnlineShoppingEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String username,String password)
        {
            if (String.IsNullOrEmpty(username))
            {
                ViewBag.notice = "用户名不能为空";
            }
            else if (String.IsNullOrEmpty(password))
            {
                ViewBag.notice = "密码不能为空";
            }
            else
            {
                Users loginuser = db.Users.FirstOrDefault(p => p.Name == username);
                if (loginuser == null)
                    ViewBag.notice = "用户名不存在";
                else if (loginuser.Password != password)
                    ViewBag.notice = "密码错误";
                else
                {
                    if (loginuser.Power == 1)
                        return RedirectToAction("AdminIndex", "Admin");
                    else
                    {
                        return RedirectToAction("UsersIndex", "User",new { id=loginuser.ID});
                    }
                }
            }
            return View();
        }
    }
}