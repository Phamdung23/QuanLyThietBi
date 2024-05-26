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
            return RedirectToAction("ThemPhieuCP2", new {maCP = model.MaCP}); 
        }

        public ActionResult ThemPhieuCP2(int maCP)
        {
            var map = new mapCapPh();
            CAP_PHAT model = map.sreach(maCP);
            return View(model); 
        }



        public ActionResult ThemPhieuCP3(int maCP)
        {
            var map = new mapCapPh();
            CAP_PHAT Model = map.sreach(maCP);
            return View(Model); 
        }
    }
}