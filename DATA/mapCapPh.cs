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
    }
}
