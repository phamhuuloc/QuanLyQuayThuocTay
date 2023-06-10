using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHieuThuoc.DTO
{
    public class DonVi
    {
        private int idDonvi;
        private string tenDonVi;
        public DonVi(int idDonVi, string tenDonVi)
        {
            this.IdDonvi = idDonVi;
            this.TenDonVi = tenDonVi;
        }
        public DonVi(DataRow row)
        {
            this.IdDonvi = (int)row["IdDonVi"];
            this.TenDonVi = (string)row["TenDonVi"];
        }

        public int IdDonvi { get => idDonvi; set => idDonvi = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
    }
}
