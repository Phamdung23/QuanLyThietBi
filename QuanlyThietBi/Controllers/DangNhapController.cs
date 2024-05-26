using DATA;
using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThietBi.Controllers
{
    public class DangNhapController : Controller
    {
        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Login(TAI_KHOAN Modeltaikhoan) 
        {
            mapTaiKhoan map = new mapTaiKhoan();
            var user = map.TimKiem(Modeltaikhoan.UserName, Modeltaikhoan.PassWord); 
            if(user != null)
            {
                Session["Username"] = Modeltaikhoan.UserName;
                return RedirectToAction("Trangchu", "Home");
            }
            return View();
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(TAI_KHOAN Modeltaikhoan)
        {
            mapTaiKhoan map = new mapTaiKhoan();
            if(map.ThemMoi(Modeltaikhoan) == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(Modeltaikhoan);
            }
        }
    }
}