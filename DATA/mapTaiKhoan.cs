using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA.Entity;
using Microsoft.Win32;

namespace DATA
{
    public class mapTaiKhoan
    {
        QLTHIETBIEntities db = new QLTHIETBIEntities(); 

        // 1. Tìm kiếm tài khoản
        public TAI_KHOAN TimKiem(string username, string password)
        {
            var user = db.TAI_KHOAN.Where(m => m.UserName == username && m.PassWord == password).ToList();

            if(user.Count > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }

        // 2. Dang sach tai khoan
        public List<TAI_KHOAN> Danhsach()
        {
            var user = db.TAI_KHOAN.ToList();
            return user;
        }

        // 3. Thêm mới
        // 3.a Sử dụng tham số lẻ
        public void ThemMoi(string Username, string Password, string email)
        {
            // Tạo đối tượng và gán giá trị
            TAI_KHOAN tk = new TAI_KHOAN();
            tk.UserName = Username;
            tk.PassWord = Password;
            tk.Email = email;

            // Add vào List đối tượng trong db
            db.TAI_KHOAN.Add(tk);
            // Lưu vào Database
            db.SaveChanges();
        }

        // 3.b Sử dụng đối tượng
        public bool ThemMoi(TAI_KHOAN tk)
        {
            try
            {
                // Add vào List đối tượng trong db
                db.TAI_KHOAN.Add(tk);
                // Lưu vào Database
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
