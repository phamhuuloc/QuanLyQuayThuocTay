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
    /// Interaction logic for frmSuaDonVi.xaml
    /// </summary>
    public partial class frmSuaDonVi : Window
    {
        private int idDonVi;
        private string tenDonVi;

        public frmSuaDonVi()
        {
            InitializeComponent();
        }
        public frmSuaDonVi(int idDonvi, string tenDonVi)
        {
            this.IdDonVi = idDonvi;
            this.TenDonVi = tenDonVi;
            InitializeComponent();
        }
        public int IdDonVi { get => idDonVi; set => idDonVi = value; }
        public string TenDonVi { get => tenDonVi; set => tenDonVi = value; }

        private void btnHuySuaDonVi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSuaDonVi(object sender, RoutedEventArgs e)
        {
            // Kiểm tra tên đơn vị trống không
            if (txtSuaDonVi.Text == "")
                MessageBox.Show("Tên đơn vị không được để trống!");
            else
            {
                DataProvider.Instance.ExecuteQuery("Update DonVi SET TenDonVi = N'" + txtSuaDonVi.Text + "' WHERE IdDonVi = " + txtMaDonVi.Text);
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
        }

        private void loadThongTinDonVi(object sender, RoutedEventArgs e)
        {
            txtMaDonVi.Text = IdDonVi.ToString();
            txtSuaDonVi.Text = TenDonVi;
        }
    }
}
