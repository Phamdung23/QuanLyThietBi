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
    }
}
