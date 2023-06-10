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
    /// Interaction logic for frmThemDonVi.xaml
    /// </summary>
    public partial class frmThemDonVi : Window
    {
        public frmThemDonVi()
        {
            InitializeComponent();
        }

        private void XoaDonVi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ThemDonVi(object sender, RoutedEventArgs e)
        {
            // Kiểm tra rỗng
            if (txtThemDonVi.Text == "")
            {
                MessageBox.Show("Tên đơn vị không được để trống!");
            }
            else
            {
                DataProvider.Instance.ExecuteQuery("Insert DonVi values (N'" + txtThemDonVi.Text + "')");
                this.Close();
            }
        }
    }
}
