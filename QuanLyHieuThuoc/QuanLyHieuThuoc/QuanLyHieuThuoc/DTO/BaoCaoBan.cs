using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QuanLyHieuThuoc.DTO
{
    public class BaoCaoBan
    {
        private string tenThuoc;
        private int soLuong;
        private string tenDonVi;
        private decimal gia;
        private DateTime ngay;
        private decimal thanhTien;

        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
        public decimal Gia { get => gia; set => gia = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public BaoCaoBan(DataRow row)
        {
            this.TenThuoc = (string)row["TenThuoc"];
            this.SoLuong = (int)row["SoLuongBan"];
            this.TenDonVi = (string)row["TenDonVi"];
            this.Gia = (decimal)row["GiaBan"];
            this.Ngay = (DateTime)row["NgayBan"];
            this.ThanhTien = (decimal)row["ThanhTien"];
        }
    }
}
