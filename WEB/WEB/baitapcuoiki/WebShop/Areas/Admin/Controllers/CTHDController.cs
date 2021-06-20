using baitapcuoiki.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class CTHDController : Controller
    {
        // GET: Admin/CTHD
        public ActionResult Index()
        {
            var user = new CTDHDao();
            var model = user.ListAll();
            return View(model);

        }
    }
}