using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QuanLyHieuThuoc.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(int IdTaiKhoan,string TenDangNhap,string MatKhau, string TenHienThi, string SoDienThoai, string TenCuaHang, string CMND , string DiaChi,string VaiTro)
        {
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.TenHienThi = TenHienThi;
            this.SoDienThoai = SoDienThoai;
            this.CMND = CMND;
            this.DiaChi = DiaChi;
            this.TenCuaHang = TenCuaHang;
            this.VaiTro = VaiTro;
            this.IdTaiKhoan = IdTaiKhoan;
        }

        public TaiKhoan (DataRow row)
        {
            this.idTaiKhoan = (int)row["IdTaiKhoan"];
            this.tenDangNhap = (string)row["TenDangNhap"];
            this.matKhau = (string)row["MatKhau"];
            this.tenHienThi = (string)row["TenHienThi"];
            this.SoDienThoai = (string)row["SoDienThoai"];
            this.cmnd = (string)row["CMND"];
            this.diaChi = (string)row["DiaChi"];
            this.tenCuaHang = (string)row["TenCuaHang"];
            this.vaiTro = (string)row["VaiTro"];
            //this.CuaHang = (int)row["CuaHang"];
        }
        private int idTaiKhoan;
        private string tenDangNhap;
        private string matKhau;
        private string tenHienThi;
        private string soDienThoai;
        private string cmnd;
        private string diaChi;
        private string tenCuaHang;
        private string vaiTro;
        public int IdTaiKhoan { get => idTaiKhoan; set => idTaiKhoan = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string TenHienThi { get => tenHienThi; set => tenHienThi = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string CMND { get => cmnd; set => cmnd = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TenCuaHang { get => tenCuaHang; set => tenCuaHang = value; }

        public string VaiTro { get => vaiTro; set => vaiTro = value; }
    }
}
