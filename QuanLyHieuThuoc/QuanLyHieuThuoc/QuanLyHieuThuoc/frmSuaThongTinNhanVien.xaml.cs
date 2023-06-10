﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using QuanLyHieuThuoc.DTO;

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmThemThuoc.xaml
    /// </summary>
    public partial class frmSuaThongTinNhanVien : Window
    {
        private int idTK;
        public frmSuaThongTinNhanVien()
        {
            InitializeComponent();
        }
        public frmSuaThongTinNhanVien(TaiKhoan item)
        {
            InitializeComponent();
            txtTenDangNhap.Text = item.TenDangNhap.ToString();
            txtMatKhau.Text = item.MatKhau.ToString();
            txtTenHienThi.Text = item.TenHienThi;
            txtSDT.Text = item.SoDienThoai.ToString();
            txtCMND.Text = item.CMND.ToString();
            txtDiaChi.Text = item.DiaChi.ToString();
            IdTK = item.IdTaiKhoan;
        }

        public int IdTK { get => idTK; set => idTK = value; }

        private void btnSuaThongTin(object sender, RoutedEventArgs e)
        {
            // Kiểm tra rỗng
            if (txtTenDangNhap.Text == "" || txtTenHienThi.Text=="" || txtSDT.Text =="")
            {
                MessageBox.Show("Các trường dấu sao không được bổ trống!");
            }
            else
            {
                //if (txtGiaBan.Text == "")
                //    txtGiaBan.Text = "0";
                // Đọc đơn vị được chọn ở combobox
                string cbSelected = cbCuaHang.SelectedValue.ToString();
                //string cbRoleSelected = cbRole.SelectedValue.ToString();
                ComboBoxItem selectedItem = (ComboBoxItem)cbRole.SelectedItem;
                string cbRoleSelectedValue = selectedItem.Content.ToString();
  
                // Tìm
                DataTable idCuaHang = DataProvider.Instance.ExecuteQuery("Select IdCuaHang from CuaHang Where TenCuaHang = N'" + cbSelected + "'");
                DataRow rowidCuaHang = idCuaHang.Rows[0];
                int updateIdCuaHang = (int)rowidCuaHang["IdCuaHang"];
                DataProvider.Instance.ExecuteQuery("UPDATE TaiKhoan SET TenDangNhap = N'" + txtTenDangNhap.Text + "', TenHienThi = N'" + txtTenHienThi.Text + "', SoDienThoai = '" + txtSDT.Text + "', MatKhau = '" + txtMatKhau.Text + "', VaiTro = '" + cbRoleSelectedValue + "', IdCuaHang = " + updateIdCuaHang + ", CMND = '" + txtCMND.Text + "', DiaChi = N'" + txtDiaChi.Text + "' WHERE IdTaiKhoan = " + IdTK);

                this.Close();

              
            }
        }

        private void btnHuyThaoTac(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadChiNhanh(object sender, RoutedEventArgs e)
        {
            DataTable dataCombobox = DataProvider.Instance.ExecuteQuery("Select IdCuaHang,TenCuaHang From CuaHang");
            foreach (DataRow row in dataCombobox.Rows)
            {
                string newAdd = (string)row["TenCuaHang"];
                cbCuaHang.Items.Add(newAdd);
            }
        }
      

    }
}
