using DATA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class mapDanhMuc
    {
        QLTHIETBIEntities db = new QLTHIETBIEntities();

        public List<LOAI_THIET_BI> DSLoaiThietBi()
        {
            var danhsachLTB = db.LOAI_THIET_BI.ToList();
            return danhsachLTB;
        }

        public List<HANG_SX> DSHangSanXuat()
        {
            var danhsachHSX = db.HANG_SX.ToList();
            return danhsachHSX;
        }

        public List<DON_VI> DSDonVi()
        {
            var danhsachDV = db.DON_VI.ToList();
            return danhsachDV;
        }

        public int KiemTra(int maLoai)
        {
            LOAI_THIET_BI ltb = db.LOAI_THIET_BI.Find(maLoai);
            if(ltb != null)
            {
                return ltb.MaLoai; 
            }
            return -1;
        }

        public LOAI_THIET_BI TimKiem(int maLoai)
        {
            LOAI_THIET_BI ltb = db.LOAI_THIET_BI.Find(maLoai);
            return ltb;
        } 

        public void ThemLoaiThietBi(LOAI_THIET_BI model)
        {
            LOAI_THIET_BI ltb = db.LOAI_THIET_BI.Find(model.MaLoai);
            if( ltb == null)
            {
                db.LOAI_THIET_BI.Add(model);
                db.SaveChanges();
            }
        }

        public void ThemHSX(HANG_SX model)
        {
            HANG_SX hsx = db.HANG_SX.Find(model.MaHang);
            if (hsx == null)
            {
                db.HANG_SX.Add(model);
                db.SaveChanges();
            }
        }

        public void ThemDonVi(DON_VI model)
        {
            DON_VI dv = db.DON_VI.Find(model.MaDV);
            if (dv == null)
            {
                db.DON_VI.Add(model);
                db.SaveChanges();
            }
        }
    }
}
