using DATA;
using DATA.Entity;
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
        
        // Loại thiết bị
        public ActionResult NhomThietBi() {
            var map = new mapDanhMuc();
            var data = map.DSLoaiThietBi();
            return View(data);
        }      
        
        public ActionResult ThietBi_NTB(int maLoai)
        {

            return View();
        } 

        public ActionResult ThemMoiLoaiTB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiLoaiTB(LOAI_THIET_BI Model)
        {
            var map = new mapDanhMuc();
            map.ThemLoaiThietBi(Model);
            return RedirectToAction("ThemMoiLoaiTB");
        }


        // Hãng sản xuất
        public ActionResult HangSanXuat()
        {
            var map = new mapDanhMuc();
            var data = map.DSHangSanXuat(); 
            return View(data);
        }

        public ActionResult ThemMoiHSX()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiHSX(HANG_SX Model)
        {
            var map = new mapDanhMuc();
            map.ThemHSX(Model); 
            return RedirectToAction("ThemMoiHSX");
        }


        // Đơn vị
        public ActionResult DonVi()
        {
            var map = new mapDanhMuc();
            var data = map.DSDonVi();   
            return View(data);
        }

        public ActionResult ThemMoiDonVi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoiDonVi(DON_VI Model)
        {
            var map = new mapDanhMuc();
            map.ThemDonVi(Model);
            return RedirectToAction("ThemMoiDonVI");
        }
    }
}