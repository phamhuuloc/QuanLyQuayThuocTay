using System;
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

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmThemThuoc.xaml
    /// </summary>
    public partial class frmThemNhanVien : Window
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
        }
        private void TextBox_TextChanged_SDT(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra xem nội dung của TextBox có chứa chữ không
            if (ContainsLetters(textBox.Text))
            {
                MessageBox.Show("Vui lòng chỉ nhập số.");
                textBox.Text = ""; // Xóa nội dung của TextBox
            }
        }
        private void TextBox_TextChanged_CMND(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // Kiểm tra xem nội dung của TextBox có chứa chữ không
            if (ContainsLetters(textBox.Text))
            {
                MessageBox.Show("Vui lòng chỉ nhập số.");
                textBox.Text = ""; // Xóa nội dung của TextBox
            }
        }
        private bool ContainsLetters(string text)
        {
            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnThemNhanVien(object sender, RoutedEventArgs e)
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
                ComboBoxItem selectedItem = (ComboBoxItem)cbRole.SelectedItem;
                string cbRoleSelectedValue = selectedItem.Content.ToString();
                // Tìm
                DataTable idCuaHang = DataProvider.Instance.ExecuteQuery("Select IdCuaHang from CuaHang Where TenCuaHang = N'" + cbSelected + "'");
                DataRow rowidCuaHang = idCuaHang.Rows[0];
                int updateIdCuaHang = (int)rowidCuaHang["IdCuaHang"];
                DataProvider.Instance.ExecuteQuery("INSERT INTO TaiKhoan (TenDangNhap, TenHienThi, SoDienThoai, IdCuaHang, MatKhau, CMND, DiaChi, VaiTro) VALUES (N'" + txtTenDangNhap.Text + "', N'" + txtTenHienThi.Text + "', '" + txtSDT.Text + "', " + updateIdCuaHang + ", '123', '" + txtCMND.Text + "', N'" + txtDiaChi.Text + "', '" + cbRoleSelectedValue + "')");
                //DataProvider.Instance.ExecuteQuery("INSERT into  TaiKhoan (TenDangNhap , TenHienThi, SoDienThoai,IdCuaHang,MatKhau,CMND,DiaChi,VaiTro) VALUES ('locpham','phamloc','93432423',1,'123','0234324','sdfasd','Admin')");
                this.Close();
            }
        }

        private void btnHuyThemNhanVien(object sender, RoutedEventArgs e)
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
