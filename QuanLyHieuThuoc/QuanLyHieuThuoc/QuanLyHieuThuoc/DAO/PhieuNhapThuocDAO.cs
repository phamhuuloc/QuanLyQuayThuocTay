using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DAO
{
    public class PhieuNhapThuocDAO
    {
        public PhieuNhapThuocDAO() { }

        private static PhieuNhapThuocDAO instance;

        public static PhieuNhapThuocDAO Instance
        {
            get
            {
                if (instance == null) { instance = new PhieuNhapThuocDAO(); }
                return instance;
            }
            set { PhieuNhapThuocDAO.instance = value; }
        }
    }
}
