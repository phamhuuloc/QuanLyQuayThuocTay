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

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmThemCuaHang.xaml
    /// </summary>
    public partial class frmThemCuaHang : Window
    {
        public frmThemCuaHang()
        {
            InitializeComponent();
        }

        private void btnHuyThemCuaHang(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnThemCuaHang(object sender, RoutedEventArgs e)
        {
            // Kiểm tra xem tên cửa hàng trống không
            if (txtTenCuaHang.Text == "")
                MessageBox.Show("Tên của hàng không được để trống!");
            else
            {
                DataProvider.Instance.ExecuteQuery("Insert CuaHang values (N'" + txtTenCuaHang.Text + "' , N'" + txtDiaChi.Text + "')");
                this.Close();
            }
        }
    }
}
