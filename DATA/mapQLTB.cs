using DATA.Entity;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class mapQLTB
    {
        QLTHIETBIEntities db = new QLTHIETBIEntities();

        // 1. Phiếu nhập

        // Hàm lấy dữ liệu
        public List<TANG> LoaddsPhieuNhap()
        {
            var phieunhap = db.TANGs.ToList(); 
            return phieunhap;  
        }

        public List<TANG> LoadPage(int page, int size)
        {
            var danhssach = db.TANGs.ToList().Skip((page-1)*size).Take(size).ToList();
            return danhssach; 
        }

        // Hàm thêm phiếu nhập 
        public void ThemPhieuNhap(TANG phieunhap)
        {
            TANG phieutang = db.TANGs.Find(phieunhap.MaTang);
            if(phieutang == null) {
                db.TANGs.Add(phieunhap);
                db.SaveChanges();
            }
        }

        //  Hàm chi tiết phiếu nhập
        public TANG ChitietPhieu(int maTang)
        {
            TANG phieunhap = db.TANGs.Find(maTang);
            return phieunhap;
        }

        // Xóa phiếu nhập
        public void XoaPhieuNhap(int maTang)
        {
            var danhsach = db.THIET_BI.Where(m => m.MaTang == maTang).ToList();
            if (danhsach != null)
            {
                foreach (var thietbi in danhsach)
                {
                    db.THIET_BI.Remove(thietbi);
                    db.SaveChanges();
                }
            }

            var phieunhap = db.TANGs.Find(maTang); 
            if(phieunhap != null)
            {
                db.TANGs.Remove(phieunhap);
                db.SaveChanges();
            }
        }

        // Sửa phiếu nhập
        public TANG SuaPhieuNhap_get(int maTang)
        {
            TANG phieunhap = db.TANGs.Find(maTang);
            return phieunhap; 
        }

        public void SuaPN(TANG model)
        {
            TANG phieunhap = db.TANGs.Find(model.MaTang); 
            if(phieunhap != null)
            {
                var maphieu = phieunhap.MaTang; 
                phieunhap.MaTang = model.MaTang;
                phieunhap.NgayTang = model.NgayTang; 
                phieunhap.LyDo = model.LyDo; 
                phieunhap.NguoiLapPhieu = model.NguoiLapPhieu; 
                phieunhap.NguoiNhan = model.NguoiNhan; 
                phieunhap.MaLoai = model.MaLoai; 

                if(maphieu != model.MaTang)
                {
                    foreach(var item  in db.THIET_BI.Where(m=>m.MaTang == maphieu).ToList())
                    {
                        item.MaTang = model.MaTang; 
                    }
                }
                db.SaveChanges();
            }
        }


        // 2. Thiết bị

        // Hàm thêm một thiết bị
        public THIET_BI Themthietbi_get(int Maphieu, int Maloai)
        {
            var ThietBi = new THIET_BI();
            ThietBi.MaTang = Maphieu;
            ThietBi.MaLoai = Maloai;

            return ThietBi;
        }

        public void ThemThietBi(THIET_BI Model)
        {
            THIET_BI thietbi = db.THIET_BI.Find(Model.MaTB);
            if (thietbi == null)
            {
                db.THIET_BI.Add(Model);
                // Tìm phiếu nhập của thiết bị
                TANG phieunhap = db.TANGs.Find(Model.MaTang);
                // Cập nhập tổng tiền cho phiếu nhập sau khi thêm một thiết bị
                phieunhap.SoLuong = phieunhap.SoLuong + 1;
                phieunhap.TongTien = phieunhap.TongTien + Model.ThanhTien;
                //db.Entry(phieunhap).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Hàm chi tiết thiết bị
        public THIET_BI ChitietTB(int maTB)
        {
            THIET_BI thietbi = db.THIET_BI.Find(maTB);
            return thietbi;
        }

        // Sửa thiết bị
        public THIET_BI SuaThietBi_get(int maTB)
        {
            THIET_BI thietbi = db.THIET_BI.Find(maTB);
            return thietbi;
        }

        public void SuaTB(THIET_BI model)
        {
            THIET_BI thietbi = db.THIET_BI.Find(model.MaTB);
            if(thietbi != null)
            {
                thietbi.MaTB = model.MaTB; 
                thietbi.NgayBDSD = model.NgayBDSD;
                thietbi.MaHang = model.MaHang;
                thietbi.TenTB = model.TenTB;
                thietbi.ThanhTien = model.ThanhTien;
                db.SaveChanges();
            }
        }

        // Hàm xóa thiết bị
        public void XoathietBi(int maTB)
        {
            THIET_BI thietbi = db.THIET_BI.Find(maTB);
            if(thietbi != null)
            {
                // Tìm phiếu nhập của thiết bị
                TANG phieunhap = db.TANGs.Find(thietbi.MaTang);
                // Cập nhập tổng tiền cho phiếu nhập sau khi thêm một thiết bị
                phieunhap.SoLuong = phieunhap.SoLuong - 1;
                phieunhap.TongTien = phieunhap.TongTien - thietbi.ThanhTien;
                db.THIET_BI.Remove(thietbi);
                db.SaveChanges();
            }
        }
    }
}
