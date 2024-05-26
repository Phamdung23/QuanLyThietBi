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

        public TAI_KHOAN TimKiem(string username)
        {
            var user = db.TAI_KHOAN.Where(m => m.UserName == username).ToList();

            if (user.Count > 0)
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

        // Cập nhật tài khoản
        // 4. Cập nhật thông tin tài khoản
        public bool CapNhat(TAI_KHOAN tk)
        {
            try
            {
                // Tìm kiếm tài khoản trong cơ sở dữ liệu
                var existingUser = db.TAI_KHOAN.FirstOrDefault(u => u.UserName == tk.UserName);

                // Nếu tài khoản tồn tại, cập nhật thông tin
                if (existingUser != null)
                {
                    existingUser.UserName = tk.UserName; // Cập nhật tên đăng nhập
                    existingUser.PassWord = tk.PassWord; // Cập nhật mật khẩu
                    existingUser.Email = tk.Email; // Cập nhật email

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SaveChanges();

                    return true;
                }
                else
                {
                    // Không tìm thấy tài khoản để cập nhật
                    return false;
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi nếu có
                return false;
            }
        }

    }
}
