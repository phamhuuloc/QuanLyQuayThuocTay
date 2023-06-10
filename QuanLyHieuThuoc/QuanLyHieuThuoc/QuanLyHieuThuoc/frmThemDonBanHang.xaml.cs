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
using QuanLyHieuThuoc.DTO;

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmThemDonBanHang.xaml
    /// </summary>
    public partial class frmThemDonBanHang : Window
    {
        private int idDonBanHang;

        public int IdDonBanHang { get => idDonBanHang; set => idDonBanHang = value; }

        public frmThemDonBanHang()
        {
            InitializeComponent();
        }
        public frmThemDonBanHang(int idDonBanHang)
        {
            this.IdDonBanHang = idDonBanHang;
            InitializeComponent();
        }
        private void LoadGrid()
        {
            DataTable dataCombobox = DataProvider.Instance.ExecuteQuery("Select * From Thuoc Order by TenThuoc ASC");
            foreach (DataRow row in dataCombobox.Rows)
            {
                string newAdd = (string)row["TenThuoc"];
                cboThuoc.Items.Add(newAdd);
            }
        }
        private void HuyThemBanHang(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThemBanHang(object sender, RoutedEventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Số lượng nhập không được bỏ trống!");
            }
            else
            {
                // tìm kiếm ID thuốc

                string cbSeclected = cboThuoc.SelectedValue.ToString();
                DataTable table = DataProvider.Instance.ExecuteQuery("Select IdThuoc from Thuoc Where TenThuoc = N'" + cbSeclected + "'");
                DataRow item = table.Rows[0];
                int idThuoc = (int)item["idThuoc"];

                // Thêm chi tiết phiếu nhập kho
                DataProvider.Instance.ExecuteQuery("insert ChiTietDonBanHang values (" + IdDonBanHang + "," + idThuoc.ToString() + "," + txtSoLuong.Text + ")");
                DataProvider.Instance.ExecuteQuery("update Thuoc Set SoLuong = SoLuong - " + txtSoLuong.Text + " Where IdThuoc=" + idThuoc.ToString());
                this.Close();
            }
        }

        private void ThemThuoc(object sender, RoutedEventArgs e)
        {
            frmThemThuoc newfrmThemThuoc = new frmThemThuoc();
            newfrmThemThuoc.ShowDialog();
            LoadGrid();
        }

        private void LoadGridThuoc(object sender, RoutedEventArgs e)
        {
            LoadGrid();
        }
    }
}
