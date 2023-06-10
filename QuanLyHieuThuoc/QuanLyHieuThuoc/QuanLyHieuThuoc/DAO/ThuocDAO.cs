using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DAO
{
    public class ThuocDAO
    {
        public ThuocDAO() { }

        private static ThuocDAO instance;

        public static ThuocDAO Instance
        {
            get
            {
                if (instance == null) { instance = new ThuocDAO(); }
                return instance;
            }
            set { ThuocDAO.instance = value; }
        }
    }
}
