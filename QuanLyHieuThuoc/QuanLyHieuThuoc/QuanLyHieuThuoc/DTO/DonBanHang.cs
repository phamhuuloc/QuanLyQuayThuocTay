using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHieuThuoc.DTO
{
    public class DonBanHang
    {
        private int idChiTietDonBanHang;
        private int idThuoc;
        private string tenThuoc;
        private int soLuongBan;
        private string tenDonVi;
        private DateTime hanSuDung;
        private decimal giaBan;
        private decimal thanhTien;

        public int IdChiTietDonBanHang { get => idChiTietDonBanHang; set => idChiTietDonBanHang = value; }
        public int IdThuoc { get => idThuoc; set => idThuoc = value; }
        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public int SoLuongBan { get => soLuongBan; set => soLuongBan = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
        public DateTime HanSuDung { get => hanSuDung; set => hanSuDung = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }

        public DonBanHang(DataRow row)
        {
            this.IdChiTietDonBanHang = (int)row["IdChiTietDonBanHang"];
            this.IdThuoc = (int)row["IdThuoc"];
            this.TenThuoc = (string)row["TenThuoc"];
            this.SoLuongBan = (int)row["SoLuongBan"];
            this.TenDonVi = (string)row["TenDonVi"];
            this.HanSuDung = (DateTime)row["HanSuDung"];
            this.GiaBan = (decimal)row["GiaBan"];
            this.ThanhTien = (decimal)row["ThanhTien"];
        }
    }
}
