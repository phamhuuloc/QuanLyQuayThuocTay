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
    /// Interaction logic for frmSuaCuaHang.xaml
    /// </summary>
    public partial class frmSuaCuaHang : Window
    {
        private int idCuaHang;
        private string tenCuaHang;
        private string diaChi;
        public frmSuaCuaHang()
        {
            InitializeComponent();
        }
        public frmSuaCuaHang(int idCuaHang, string tenCuaHang, string diaChi)
        {
            this.IdCuaHang = idCuaHang;
            this.TenCuaHang = tenCuaHang;
            this.DiaChi = diaChi;
            InitializeComponent();
        }

        public int IdCuaHang { get => idCuaHang; set => idCuaHang = value; }
        public string TenCuaHang { get => tenCuaHang; set => tenCuaHang = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        private void btnHuySuaCuaHang(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSuaCuaHang(object sender, RoutedEventArgs e)
        {
            // Kiểm tra tên cửa hàng trống không
            if (txtTenCuaHang.Text == "")
                MessageBox.Show("Tên cửa hàng không được để trống!");
            else
            {
                DataProvider.Instance.ExecuteQuery("Update CuaHang SET TenCuaHang = N'" + txtTenCuaHang.Text + "', DiaChi = N'" + txtDiaChi.Text + "' WHERE IdCuaHang = " + txtIdCuaHang.Text);
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
        }

        private void LoadSuaThongTinCuaHang(object sender, RoutedEventArgs e)
        {
            txtIdCuaHang.Text = IdCuaHang.ToString();
            txtTenCuaHang.Text = TenCuaHang;
            txtDiaChi.Text = DiaChi;
        }
    }
}
