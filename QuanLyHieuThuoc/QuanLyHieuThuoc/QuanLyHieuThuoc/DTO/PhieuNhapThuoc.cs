using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyHieuThuoc.DTO
{
    public class PhieuNhapThuoc
    {
        private int idChiTietPhieuNhapKho;
        private int idThuoc;
        private string tenThuoc;
        private int soLuongNhap;
        private string tenDonVi;
        private DateTime hanSuDung;
        private decimal giaNhap;
        private decimal thanhTien;

        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        public DateTime HanSuDung { get => hanSuDung; set => hanSuDung = value; }
        public decimal GiaNhap { get => giaNhap; set => giaNhap = value; }
        public decimal ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }
        public int IdChiTietPhieuNhapKho { get => idChiTietPhieuNhapKho; set => idChiTietPhieuNhapKho = value; }
        public int IdThuoc { get => idThuoc; set => idThuoc = value; }

        public PhieuNhapThuoc(DataRow row)
        {
            this.IdChiTietPhieuNhapKho = (int)row["IdChiTietPhieuNhapKho"];
            this.IdThuoc = (int)row["IdThuoc"];
            this.TenThuoc = (string)row["TenThuoc"];
            this.SoLuongNhap = (int)row["SoLuongNhap"];
            this.TenDonVi = (string)row["TenDonVi"];
            this.HanSuDung = (DateTime)row["HanSuDung"];
            this.GiaNhap = (decimal)row["GiaNhap"];
            this.ThanhTien = (decimal)row["ThanhTien"];
        }
    }
}
