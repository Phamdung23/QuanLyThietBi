using System;
using DATA;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThietBi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Trangchu()
        {
            return View(); 
        }

        public  ActionResult DanhMuc()
        {
            return View();
        }

        public ActionResult DanhmucNhomTB()
        {
            var danhsach = new mapDanhMuc();
            danhsach.DanhsachnhomTB(); 
            return View(danhsach);  
        }

    }
}
