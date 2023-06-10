using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QuanLyHieuThuoc.DTO
{
    public class CuaHang
    {
        public CuaHang(int idCuaHang,string tenCuaHang, string diaChi)
        {
            this.IdCuaHang = idCuaHang;
            this.TenCuaHang = tenCuaHang;
            this.DiaChi = diaChi;
        }
        public CuaHang(DataRow row)
        {
            this.IdCuaHang = (int)row["idCuaHang"];
            this.TenCuaHang = (string)row["tenCuaHang"];
            this.DiaChi = (string)row["diaChi"];
        }
        private int idCuaHang;
        private string tenCuaHang;
        private string diaChi;

        public int IdCuaHang { get => idCuaHang; set => idCuaHang = value; }
        public string TenCuaHang { get => tenCuaHang; set => tenCuaHang = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
    }
}
