using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyHieuThuoc.DTO
{
    public class Thuoc
    {
        private int idThuoc;
        private string tenThuoc;
        private DateTime hanSuDung;
        private int soLuong;
        private string tenDonVi;
        private decimal giaNhap;
        private decimal giaBan;
        private string ghiChu;

        public int IdThuoc { get => idThuoc; set => idThuoc = value; }
        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public DateTime HanSuDung { get => hanSuDung; set => hanSuDung = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public decimal GiaNhap { get => giaNhap; set => giaNhap = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }

        public Thuoc(int idThuoc, string tenThuoc, DateTime hanSuDung, int soLuong, string tenDonVi, decimal giaNhap, decimal giaBan)
        {
            this.IdThuoc = idThuoc;
            this.TenThuoc = tenThuoc;
            this.HanSuDung = hanSuDung;
            this.SoLuong = soLuong;
            this.TenDonVi = tenDonVi;
            this.GiaNhap = giaNhap;
            this.GiaBan = giaBan;
            this.ghiChu = GhiChu;
        }
        public Thuoc(DataRow row)
        {
            this.IdThuoc = (int)row["idThuoc"];
            this.TenThuoc = (string)row["tenThuoc"];
            this.HanSuDung = (DateTime)row["hanSuDung"];
            this.SoLuong = (int)row["soLuong"];
            this.TenDonVi = (string)row["tendonVi"];
            this.GiaNhap = (decimal)row["giaNhap"];
            this.GiaBan = (decimal)row["giaBan"];
            this.GhiChu = (string)row["ghiChu"];
        }
    }
}
