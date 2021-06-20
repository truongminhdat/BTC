using baitapcuoiki.DAO;
using baitapcuoiki.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public object db { get; private set; }

        //GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            var user = new ProductDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var user = new ProductDao();
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
            var dao = new ProductDao();
            var result = dao.Find(user);
            SetViewBag();
            if (result != null)
                return View(result);
         
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(model.ID))
                    {
                        SetAlert("Không được để trống mã sản phẩm  ", "warning");
                        return View();
                    }
                    var dao = new ProductDao();
                  
                    string result = "";
                    // tìm tên đăng nhập có trùng ko 
                    //Nếu trùng thì trả về 

                    result = dao.Insert(model);
                    SetViewBag();

                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Cập nhật thành công", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        SetAlert("Cập nhật không thành công", "error");
                        
                    }
                }
             

            }
            catch (Exception ex)
            {
               
                Common.Common.WriteLog("Product", "Create-Post", ex.ToString());
            }
            return View();

        }
      
        [HttpDelete]
        public ActionResult Delete(string name)
        {
            var dao = new ProductDao().Delete(name);
            return RedirectToAction("Index");

        }
      
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "CategoryID", "Name", selectedId);
        }




    }
}