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
    public class SanPhamsController : BaseController
    {
        // GET: Admin/SanPhams

        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var user = new SanPhamDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var user = new SanPhamDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public ActionResult Create(string user)
        {
            var dao = new SanPhamDao();
            var result = dao.Find(user);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(SANPHAM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new SanPhamDao();
                    if (dao.Find(model.MASP) != null)
                    {
                        SetAlert("Đã tồn tại", "warning");
                        return RedirectToAction("Create", "SanPhams");

                    }
                    string result = dao.Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Đã tồn tại", "warning");
                        return RedirectToAction("Index", "SanPhams");

                    }
                    else
                    {
                        SetAlert("Thêm không thành công", "error");
                    }

                }

            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("SanPhams", "Create-Post", ex.ToString());
            }
            return View();
        }
        //[HttpGet]
        public ActionResult Delete(string MASP)
        {
            var dao = new SanPhamDao().Delete(MASP);
            return RedirectToAction("Index");
        }
    }
}