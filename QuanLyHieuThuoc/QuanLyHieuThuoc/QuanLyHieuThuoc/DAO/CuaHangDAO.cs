using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DAO
{
    public class CuaHangDAO
    {
        public CuaHangDAO() { }

        private static CuaHangDAO instance;

        public static CuaHangDAO Instance
        {
            get
            {
                if (instance == null) { instance = new CuaHangDAO(); }
                return instance;
            }
            set { CuaHangDAO.instance = value; }
        }
    }
}
