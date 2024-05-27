using DATA.Entity;
using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace QuanlyThietBi.Controllers
{
    public class CapPhatController : Controller
    {
        // GET: CapPhat
        public ActionResult CapPhatvw() 
        {
            var map = new mapCapPh();
            var data = map.LoadsPhieuCp();
            return View(data); 
        }

        public ActionResult ThemPhieuCP() {
            return View();
        }

        [HttpPost]
        public ActionResult ThemPhieuCP(CAP_PHAT Model)
        {
            var map = new mapCapPh();
            CAP_PHAT model = map.ThemPhieuCP(Model);
            return RedirectToAction("DanhSachCapPhat", new { maCP = model.MaCP , maLoai = model.MaLoai, maDV = model.MaDV});  
        }

        private mapCapPh map = new mapCapPh();

        // Hiển thị danh sách các kho chứa loại thiết bị
        public ActionResult DanhSachCapPhat(int maCP, int maLoai, int maDV)
        {
            var khoList = map.GetKhoByLoai(maLoai);
            ViewBag.MaCP = maCP;
            ViewBag.MaLoai = maLoai;
            ViewBag.MaDV = maDV;
            return View(khoList);
        }

        // Hiển thị danh sách thiết bị trong kho được chọn
        public ActionResult DanhSachThietBi(int maCP, int maLoai, int maKho, int maDV)
        {
            var thietBiList = map.GetThietBiByKho(maLoai, maKho);
            ViewBag.MaCP = maCP;
            ViewBag.MaLoai = maLoai;
            ViewBag.MaKho = maKho;
            ViewBag.MaDV = maDV;
            return View(thietBiList);
        }

        // Xử lý việc cấp phát thiết bị
        [HttpPost]
        public ActionResult CapPhatThietBi(int maTB, int maCP, int maDV, int maKho)
        {
            map.CapPhatThietBi(maTB, maCP, maDV, maKho);
            //return RedirectToAction("DanhSachThietBi", new { maCP = maCP, maLoai = ViewBag.MaLoai, maKho = maKho, maDV = maDV });
            return RedirectToAction("CapPhatvw");
        }

        /*
        public ActionResult ThemPhieuCP2()   
        {  
            return View();  
        }


        [HttpPost]
        public ActionResult ThemPhieuCP2(CAP_PHAT Model)
        {
            var map = new mapCapPh();
            var model = map.sreach(Model.MaCP);
            if (model != null)
                if (model != null)
                {
                    model.MaKho = Model.MaKho;
                    return RedirectToAction("ThemPhieuCP3", new { m = model });
                }
            return View();
        }

        public ActionResult ThemPhieuCP3(CAP_PHAT model)
        {
            return View(model);     
        }
        */
    }
}