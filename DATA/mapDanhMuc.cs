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

        // 1. Danh sách nhóm thiết bị
        public List<NHOM_TB> DanhsachnhomTB()
        {
            var dsnhomtb = db.NHOM_TB.ToList();
            return dsnhomtb; 
        }
    }
}
