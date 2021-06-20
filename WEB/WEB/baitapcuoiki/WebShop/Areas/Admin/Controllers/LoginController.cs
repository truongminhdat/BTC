using baitapcuoiki.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Admin.Data;
using System.Configuration;
using WebShop.Common;

namespace WebShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public object Encryptor { get; private set; }

        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.login(
                    user.UserName, Common.Encryptor.EncryptMD5(user.Password));


                if (result == 1)
                {
                   /* ModelState.AddModelError("", "Đăng nhập thành công");*/
                    Session.Add(Constants.USER_SESSION,user);                  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}