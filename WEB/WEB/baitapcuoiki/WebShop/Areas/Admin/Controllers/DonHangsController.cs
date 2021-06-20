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
    public class DonHangsController : BaseController
    {
        // GET: Admin/DonHangs
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new DonHangDao();
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
            var user = new DonHangDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new DonHangDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(HOADON model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new DonHangDao();
                    if (dao.Find(model.SOHD) != null)
                    {
                        SetAlert("Đã tồn tại", "warning");
                        return RedirectToAction("Create", "KhachHangs");

                    }
                    string result = dao.Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index", "KhachHangs");

                    }
                    else
                    {
                        SetAlert("Thêm không thành công", "error");
                    }

                }

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("KhachHangs", "Create-Post", ex.ToString());
            }
            return View();
        }
    }
}