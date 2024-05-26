using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThietBi.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        public ActionResult DanhMucMenu()
        {
            return View();
        }

        public ActionResult NhomThietBi() {
            return View();
        }

        public ActionResult HangSanXuat() {
            return View();
        }

        public ActionResult DonVi()
        {
            return View();
        } 

        public ActionResult ThemMoiLoaiTB()
        {
            return View();
        }
    }
}