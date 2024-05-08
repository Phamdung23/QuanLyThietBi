using DATA;
using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThietBi.Controllers
{
    public class QLTrangBiController : Controller
    {
        // 1. Phiếu nhập
        // Danh sách phiếu nhập 
        public ActionResult NhapVao()
        {
            var map = new mapQLTB();
            var data = map.LoaddsPhieuNhap();
            return View(data);
        }

        // Thêm phiếu nhập 
        public ActionResult ThemPhieuNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemPhieuNhap(TANG Model)
        {
            var map = new mapQLTB();
            map.ThemPhieuNhap(Model); 
            return RedirectToAction("ThemPhieuNhap"); 
        }

        // Chi tiết phiếu nhập
        public ActionResult ChiTietPhieu(int maTang)
        {
            var map = new mapQLTB();
            var model = map.ChitietPhieu(maTang);
            return View(model);
        }

        // Xóa phiếu nhập
        public ActionResult XoaPhieuNhap(int maTang)
        {
            var map = new mapQLTB();
            map.XoaPhieuNhap(maTang);
            return RedirectToAction("NhapVao"); 
        }

        // Sửa phiếu nhập 
        public ActionResult SuaPhieuNhap(int maTang)
        {
            var map = new mapQLTB();
            var phieunhap =map.SuaPhieuNhap_get(maTang);
            return View(phieunhap); 
        }

        [HttpPost]  
        public ActionResult SuaPhieuNhap(TANG model)
        {
            var map = new mapQLTB(); 
            map.SuaPN(model);
            return View(model); 
        }


        // 2. Thiết bị
        // Thêm thiết bị 
        public ActionResult ThemThietBi (int maTang, int maLoai)
        {
            var map = new mapQLTB();
            var model = map.Themthietbi_get(maTang, maLoai);
            return View(model); 
        }

        [HttpPost]
        public ActionResult ThemThietBi(THIET_BI Model)
        {
            var map = new mapQLTB ();
            map.ThemThietBi(Model);
            return View(Model); 
        }
        
        // Chi tiết thiết bị
        public ActionResult ChiTietThietBi(int maTB)
        {
            var map = new mapQLTB();
            var model = map.ChitietTB(maTB);
            return View(model); 
        }

        // Xóa thiết bị 
        public ActionResult XoaThietBi(int maTB, int maTang)
        {
            var map = new mapQLTB(); 
            map.XoathietBi(maTB);
            return RedirectToAction("ChitietPhieu", new { maTang = maTang });
        }

        // Sửa thiết bị
        public ActionResult SuaThietBi(int maTB)
        {
            var map = new mapQLTB();
            var model = map.SuaThietBi_get(maTB);
            return View(model);
        }

        [HttpPost]
        public ActionResult SuaThietBi(THIET_BI model)
        {
            var map = new mapQLTB();
            map.SuaTB(model); 
            return View(model);
        }
    }   
}