using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.DAO
{
    public class DonViDAO
    {
        public DonViDAO() { }

        private static DonViDAO instance;

        public static DonViDAO Instance
        {
            get
            {
                if (instance == null) { instance = new DonViDAO(); }
                return instance;
            }
            set { DonViDAO.instance = value; }
        }
    }
}
