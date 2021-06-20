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
    public class CategoryController : BaseController
    {
 
            //GET: Admin/User
            public ActionResult Index(int page = 1, int pagesize = 10)
            {
                var user = new CategoryDao();
                var model = user.ListAll();
                return View(model.ToPagedList(page, pagesize));
            }
            [HttpPost]
            public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
            {
                var user = new CategoryDao();
                var model = user.ListWhereAll(searchString, page, pagesize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pagesize));
            }

            //[HttpGet]
            //public ActionResult Create()
            //{
            //    return View();
            //}
            [HttpGet]
            public ActionResult Create(string user)
            {
                var dao = new CategoryDao();
                var result = dao.Find(user);
                if (result != null)
                    return View(result);
                return View();
            }
            [HttpPost]
            public ActionResult Create(Category model)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (string.IsNullOrEmpty(model.CategoryID))
                        {
                            SetAlert("Không được để trống mã sản phẩm  ", "warning");
                            return View();
                        }
                        var dao = new CategoryDao();
                    

                        string result = "";
                   

                        result = dao.Insert(model);


                        if (!string.IsNullOrEmpty(result))
                        {
                            SetAlert("Cập nhật thành công", "success");
                            return RedirectToAction("Index", "Category");
                        }
                        else
                        {
                            SetAlert("Cập nhật không thành công", "error");

                        }
                    }

                }
                catch (Exception ex)
                {
                    Common.Common.WriteLog("Category", "Create-Post", ex.ToString());
                }
                return View();

            }

            [HttpDelete]
            public ActionResult Delete(string ID)
            {
                var dao = new CategoryDao().Delete(ID);
                return RedirectToAction("Index");

            }
        





    }
    }
