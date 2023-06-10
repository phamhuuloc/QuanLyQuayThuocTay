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
    public partial class frmThemThuoc : Window
    {
        public frmThemThuoc()
        {
            InitializeComponent();
        }

        private void btnThemThuoc(object sender, RoutedEventArgs e)
        {
            // Kiểm tra rỗng
            if (txtTenThuoc.Text == "" || txtSoLuong.Text=="" || txtGiaNhap.Text =="")
            {
                MessageBox.Show("Các trường dấu sao không được bổ trống!");
            }
            else
            {
                if (txtGiaBan.Text == "")
                    txtGiaBan.Text = "0";
                // Đọc đơn vị được chọn ở combobox
                string cbSelected = cbDonVi.SelectedValue.ToString();
                // Tìm
                DataTable idDonVi = DataProvider.Instance.ExecuteQuery("Select IdDonVi from DonVi Where TenDonVi = N'" + cbSelected + "'");
                DataRow rowidDonVi = idDonVi.Rows[0];
                int updateIdDonVi = (int)rowidDonVi["IdDonVi"];
                DataProvider.Instance.ExecuteQuery("INSERT INTO Thuoc VALUES (N'" + txtTenThuoc.Text + "', '" + dtpHanSuDung.Text + "'," + txtSoLuong.Text + "," + updateIdDonVi + "," + txtGiaNhap.Text + "," + txtGiaBan.Text + ", N'" + txtGhiChu.Text + "')");

                this.Close();
            }
        }

        private void btnHuyThemThuoc(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadDonVi(object sender, RoutedEventArgs e)
        {
            DataTable dataCombobox = DataProvider.Instance.ExecuteQuery("Select IdDonVi,TenDonVi From DonVi");
            foreach (DataRow row in dataCombobox.Rows)
            {
                string newAdd = (string)row["TenDonVi"];
                cbDonVi.Items.Add(newAdd);
            }
        }

    }
}
