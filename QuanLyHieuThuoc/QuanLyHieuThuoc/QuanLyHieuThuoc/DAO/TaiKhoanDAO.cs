using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoanDAO() { }

        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get
            {
                if (instance == null) { instance = new TaiKhoanDAO(); }
                return instance;
            }
            set { TaiKhoanDAO.instance = value; }
        }
    }
}
