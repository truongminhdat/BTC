using baitapcuoiki.DAO;
using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class KhachHangsController : BaseController
    {
        // GET: Admin/KhachHangs
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new KhachHangDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        //public ActionResult Index(int page = 1, int pagesize = 2)
        //{
        //    var user = new UserDao();
        //    var model = user.ListAll();
        //    return View(model.ToPagedList(page, pagesize));
        //}
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new KhachHangDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new KhachHangDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(KHACHHANG model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new KhachHangDao();
                    if (string.IsNullOrEmpty(model.MAKH))
                    {
                        SetAlert("Không để trống mã khách hàng", "warning");
                        return View();
                    }
                   
                    String result = "";
                    result = dao.Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "KhachHangs");

                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", "error");
                    }

                }

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("KhachHangs", "Create-Post", ex.ToString());
            }
            return View();
        }
        //[HttpGet]
        public ActionResult Delete(string MAKH)
        {
            var dao = new KhachHangDao().Delete(MAKH);
            return RedirectToAction("Index");

        }
    }
}