using baitapcuoiki.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class DanhmucController : Controller
    {

        // GET: Danhmuc
        public ActionResult Index()
        {
            var user = new ProductDao();
            var danhmuc = user.ListAll();
            return PartialView(danhmuc);
          
        }
    }
}