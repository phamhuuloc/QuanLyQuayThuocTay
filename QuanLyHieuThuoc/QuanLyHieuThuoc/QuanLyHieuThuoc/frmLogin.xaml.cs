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
using System.Security.Cryptography;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        // Kết nối CSDL 
        //public SqlConnection conn = null;
        //string strConn = "Server=DESKTOP-H6R3L2Q;Database=QuanLyCuaHangThuoc_V2;User id=sa;pwd=ndthang";
        public frmLogin()
        {
            InitializeComponent();
        }
        private void lbThoat(object sender, MouseButtonEventArgs e)
        {
            var diaThoat = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Hệ thống quản lý cửa hàng bán thuốc", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == diaThoat)
                this.Close();
        }


        private void BtnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            //string passEncode = MD5Hash(Base64Encode(txtMatKhau.Password.ToString()));
            DataTable data = DataProvider.Instance.ExecuteQuery("exec dataDangNhap @username , @password", new object[] { txtTenDangNhap.Text, txtMatKhau.Password.ToString() });

            if (data.Rows.Count <= 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }
            else
            {
                this.Hide();
                frmMain newForm = new frmMain();
                newForm.TK = txtTenDangNhap.Text;
                newForm.MK = txtMatKhau.Password.ToString();
                newForm.ShowDialog();
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
