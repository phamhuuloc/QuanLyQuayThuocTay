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
using System.Data.SqlClient;
using System.Data;

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for editAccount.xaml
    /// </summary>
    public partial class editAccount : Window
    {
        private string _tk;

        public string Tk { get => _tk; set => _tk = value; }

        public editAccount()
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

        private void CapNhatThongTin()
        {
            // Đọc dữ liệu được chọn ở combobox
            string tenCuaHang = cbChiNhanh.SelectedValue.ToString();
            // Truy vấn tên của hàng đó
            DataTable idCuaHang =  DataProvider.Instance.ExecuteQuery("Select IdCuaHang from CuaHang Where TenCuaHang = N'" + tenCuaHang +"'");
            DataRow rowidCuaHang = idCuaHang.Rows[0];
            int updateIdCuaHang = (int)rowidCuaHang["IdCuaHang"];
            DataProvider.Instance.ExecuteQuery("UPDATE TaiKhoan SET TenHienThi = N'" + txtEditTenHienThi.Text + "' , SoDienThoai = N'" + txtEditSoDienThoai.Text + "' , IdCuaHang = "+updateIdCuaHang+" WHERE TenDangNhap = N'" + Tk + "'");
            MessageBox.Show("Cập nhật thành công!");
            this.Close();
            
        }
        private void XacNhanSuaTaiKhoan(object sender, RoutedEventArgs e)
        {
            // Kiểm tra form trống
            if(txtEditSoDienThoai.Text==""||txtEditTenHienThi.Text=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!");
            }
            else
            {
                CapNhatThongTin();
            }

        }

        private void EditAcountLoad(object sender, RoutedEventArgs e)
        {
            DataTable dataCombobox = DataProvider.Instance.ExecuteQuery("Select IdCuaHang,TenCuaHang From CuaHang");
            foreach(DataRow row in dataCombobox.Rows)
            {
                string newAdd = (string)row["TenCuaHang"];
                cbChiNhanh.Items.Add(newAdd);
            }
        }

        private void cHuy(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
