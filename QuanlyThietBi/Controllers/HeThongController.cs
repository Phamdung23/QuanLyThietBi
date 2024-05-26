using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanlyThietBi.Controllers
{
    public class HeThongController : Controller
    {
        // GET: HeThong
        public ActionResult TaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TaiKhoan(string newPassword)
        {
            // Lấy tên đăng nhập từ session
            string username = Session["Username"] as string;

            if (!string.IsNullOrEmpty(username))
            {
                // Tìm kiếm người dùng trong cơ sở dữ liệu bằng username
                mapTaiKhoan map = new mapTaiKhoan();
                var user = map.TimKiem(username);

                if (user != null)
                {
                    // Cập nhật mật khẩu cho người dùng
                    user.PassWord = newPassword;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    if (map.CapNhat(user))
                    {
                        // Đổi mật khẩu thành công, chuyển hướng đến trang thông báo hoặc trang chính
                        return RedirectToAction("ChangePasswordSuccess");
                    }
                }
            }

            // Nếu có lỗi xảy ra hoặc không tìm thấy người dùng, chuyển hướng đến trang lỗi hoặc trang chính
            return RedirectToAction("ChangePasswordFailed");
        }

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult ChangePasswordFailed()
        {
            return View();
        }

        public ActionResult TroGiup()
        {
            return View();
        }
    }
}