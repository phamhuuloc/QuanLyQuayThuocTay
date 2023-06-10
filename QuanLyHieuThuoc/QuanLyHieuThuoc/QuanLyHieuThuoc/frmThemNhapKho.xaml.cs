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
    /// Interaction logic for frmThemNhapKho.xaml
    /// </summary>
    public partial class frmThemNhapKho : Window
    {
        private int idPhieuNhapKho;

        public int IdPhieuNhapKho { get => idPhieuNhapKho; set => idPhieuNhapKho = value; }

        public frmThemNhapKho()
        {
            InitializeComponent();
        }
        public frmThemNhapKho(int IdPhieuNhapKho)
        {
            this.IdPhieuNhapKho = IdPhieuNhapKho;
            InitializeComponent();
        }

        private void HuyThemNhapKho(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        private void ThemNhapKho(object sender, RoutedEventArgs e)
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
                DataProvider.Instance.ExecuteQuery("insert ChiTietPhieuNhapKho values (" + IdPhieuNhapKho + "," + idThuoc.ToString() + "," + txtSoLuong.Text + ")");
                DataProvider.Instance.ExecuteQuery("update Thuoc Set SoLuong = SoLuong + " + txtSoLuong.Text + " Where IdThuoc=" + idThuoc.ToString());
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
