using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Entity
{
    public class mapCapPh
    {
        QLTHIETBIEntities db = new QLTHIETBIEntities();

        public CAP_PHAT ThemPhieuCP(CAP_PHAT phieucp)
        {
            CAP_PHAT phieucapp = db.CAP_PHAT.Find(phieucp.MaCP);
            if (phieucapp == null)
            {
                db.CAP_PHAT.Add(phieucp);
                db.SaveChanges();
                return phieucp; 
            }
            return phieucp;  
        }

        public CAP_PHAT CapNhatCP(CAP_PHAT phieucp)
        {
            CAP_PHAT phieucapp = db.CAP_PHAT.Find(phieucp.MaCP);
            if (phieucapp != null)
            {
                db.CAP_PHAT.Add(phieucp);
                db.SaveChanges();
                return phieucp;
            }
            return phieucp;
        }

        public CAP_PHAT sreach(int maCP)
        {
            CAP_PHAT cp = db.CAP_PHAT.Find(maCP); 
            if (cp != null)
            {
                return cp;
            }
            return null;
        }

        public List<CAP_PHAT> LoadsPhieuCp()
        {
            var phieucp = db.CAP_PHAT.ToList();
            return phieucp;
        }

        public THIET_BI DSThietBicp3(int maCP)
        {
            var cp = db.THIET_BI.Find(maCP); 
            if (cp != null)
            {
                return cp; 
            }
            return null;
        }

        public void CapPhat(int maTB, int maCP, int maDV)
        {
            var thietbi = db.THIET_BI.Find(maTB);
            if(thietbi != null)
            {
                thietbi.MaCP = maCP;
                thietbi.MaDV = maDV;
                thietbi.TinhTrang = "Cấp phát";
                db.SaveChanges();
            }
        }
        public List<KHO> GetKhoByLoai(int maLoai)
        {
            return (from tb in db.THIET_BI
                    join k in db.KHO on tb.MaKho equals k.MaKho
                    where tb.MaLoai == maLoai
                    select k).Distinct().ToList();
        }

        // Lấy danh sách thiết bị theo loại và kho
        public List<THIET_BI> GetThietBiByKho(int maLoai, int maKho)
        {
            return db.THIET_BI.Where(tb => tb.MaLoai == maLoai && tb.MaKho == maKho).ToList();
        }

        // Cấp phát thiết bị và cập nhật thông tin
        public void CapPhatThietBi(int maTB, int maCP, int maDV, int maKho)
        {
            var capPhat = db.CAP_PHAT.FirstOrDefault(cp => cp.MaCP == maCP);
            if (capPhat != null)
            {
                // Phiếu cấp phát đã tồn tại, cập nhật thông tin của nó
                capPhat.MaCP = maCP;
                capPhat.MaDV = maDV;
                capPhat.MaKho = maKho;
            }
            else
            {
                // Phiếu cấp phát chưa tồn tại, tạo mới nó
                capPhat = new CAP_PHAT
                {
                    MaCP = maCP,
                    MaTB = maTB,
                    MaDV = maDV,
                    MaKho = maKho
                };
                db.CAP_PHAT.Add(capPhat);
            }

            // Cập nhật thông tin của thiết bị
            var thietBi = db.THIET_BI.FirstOrDefault(tb => tb.MaTB == maTB);
            if (thietBi != null)
            {
                thietBi.MaCP = maCP;
                thietBi.MaDV = maDV;
                thietBi.TinhTrang = "Cấp phát";
            }

            db.SaveChanges();
        }
    }
}
