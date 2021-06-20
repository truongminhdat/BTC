using baitapcuoiki.DAO;
using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Areas.Admin.Data;
using WebShop.Common;

namespace WebShop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        //GET: Admin/User
        public ActionResult Index(int page = 1 , int pagesize=2)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page,pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page=1, int pagesize =2)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page,pagesize));
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpGet]
        public ActionResult Create(string user )
        {
            var dao = new UserDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.Password))
                    {
                        SetAlert("Không để mật khẩu trống", "warning");
                        return View();
                    }
                    var dao = new UserDao();
                    var pass = Encryptor.EncryptMD5(model.Password);
                    model.Password = pass;
                    string result = "";
                    // tìm tên đăng nhập có trùng ko 
                    //Nếu trùng thì trả về 
                   
                    result = dao.Insert(model);


                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", "error");
                        //ModelState.AddModelError("", "Tạo người dùng không thành công");
                    }
                }
              
            }
            catch(Exception ex)
            {
                Common.Common.WriteLog("User", "Create-Post", ex.ToString());
            }
            return View();

        }
        //[HttpPost]
        public ActionResult Delete(string Username)
        {
            var dao = new UserDao().Delete(Username);
            return RedirectToAction("Index");
           
        }
    }
}