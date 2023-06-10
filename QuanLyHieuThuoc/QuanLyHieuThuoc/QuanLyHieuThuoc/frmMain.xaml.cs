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
using QuanLyHieuThuoc.DTO;


namespace QuanLyHieuThuoc
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        private string _tk;
        private string _mk;
        private int idPhieuNhapKho;
        private int idDonBanHang;
        private int idCuaHang;
        private int idTaiKhoan;
        public string TK
        {
            get { return _tk; }
            set { _tk = value; }
        }
        public string MK
        {
            get { return _mk; }
            set { _mk = value; }
        }

        public int IdPhieuNhapKho { get => idPhieuNhapKho; set => idPhieuNhapKho = value; }
        public int IdDonBanHang { get => idDonBanHang; set => idDonBanHang = value; }
        public int IdCuaHang { get => idCuaHang; set => idCuaHang = value; }
        public int IdTaiKhoan { get => idTaiKhoan; set => idTaiKhoan = value; }


        public frmMain()
        {
            InitializeComponent();
        }

        #region Methods
        private void HienThiThongTinTaiKhoan()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select t.tenhienthi, t.sodienthoai,t.CMND,t.DiaChi, c.tencuahang, t.idcuahang from TaiKhoan as t join CuaHang as c on t.idcuahang=c.idcuahang where tendangnhap like N'" + TK + "'");
            DataRow row = data.Rows[0];
            txtTenDangNhap.Text = TK;
            txtTenHienThi.Text = (string)row["tenhienthi"];
            txtSoDienThoai.Text = (string)row["sodienthoai"];
            txtChiNhanh.Text = (string)row["tencuahang"];
            tieudetrangchu.Header = "Chào " + (string)row["tenhienthi"] + "!";
            IdCuaHang = (int)row["idcuahang"];

        }
        private string checkRoleTaiKhoan()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select  VaiTro from TaiKhoan where TenDangNhap = '" + TK + "'");
            DataRow row = data.Rows[0];
            return (string)row["VaiTro"];
        }
        private void NapListViewCuaHang()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from CuaHang");
            List<CuaHang> items = new List<CuaHang>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new CuaHang(row));
            }
            lsvCuaHang.ItemsSource = items;
            if (lsvCuaHang.Items.Count >= 1)
                lsvCuaHang.SelectedIndex = 0;
        }
        private void NapListViewNhanVien()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select t.*, c.TenCuaHang from TaiKhoan as t join CuaHang as c on t.idcuahang=c.idcuahang");
            List<TaiKhoan> items = new List<TaiKhoan>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new TaiKhoan(row));
            }
            lsvNhanVien.ItemsSource = items;
            if (lsvNhanVien.Items.Count >= 1)
                lsvNhanVien.SelectedIndex = 0;
        }
        private void NapListViewDonVi()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from DonVi");
            List<DonVi> items = new List<DonVi>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new DonVi(row));
            }
            lsvDonVi.ItemsSource = items;
            if (lsvDonVi.Items.Count >= 1)
                lsvDonVi.SelectedItem = 0;
        }
        private void NapListViewThuoc()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select IdThuoc,TenThuoc,HanSuDung,SoLuong,TenDonVi,GiaNhap,GiaBan,GhiChu from Thuoc Join DonVi on Thuoc.IdDonVi = DonVi.IdDonVi order by TenThuoc ASC");
            List<Thuoc> items = new List<Thuoc>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new Thuoc(row));
            }
            lsvThuoc.ItemsSource = items;
            if (lsvThuoc.Items.Count >= 1)
                lsvThuoc.SelectedItem = 0;
        }
        private void NapListViewNhapKho()
        {
            if (IdPhieuNhapKho != 0)
            {
                decimal tongTienNhap = 0;
                List<PhieuNhapThuoc> items = new List<PhieuNhapThuoc>();
                DataTable pnt = DataProvider.Instance.ExecuteQuery("select IdChiTietPhieuNhapKho,Thuoc.IdThuoc,TenThuoc,SoLuongNhap,TenDonVi,HanSuDung,GiaNhap, GiaNhap*SoLuongNhap as ThanhTien from PhieuNhapKho join ChiTietPhieuNhapKho on PhieuNhapKho.IdPhieuNhapKho=ChiTietPhieuNhapKho.IdPhieuNhapKho join Thuoc on ChiTietPhieuNhapKho.IdThuoc=Thuoc.IdThuoc join DonVi on Thuoc.IdDonVi = DonVi.IdDonVi Where PhieuNhapKho.IdPhieuNhapKho=" + IdPhieuNhapKho.ToString() + " Order by IdChitietPhieuNhapKho DESC");
                foreach (DataRow row in pnt.Rows)
                {
                    tongTienNhap += (decimal)row["ThanhTien"];
                    items.Add(new PhieuNhapThuoc(row));
                }
                lsvPhieuNhapKho.ItemsSource = items;
                if (lsvPhieuNhapKho.Items.Count >= 1)
                    lsvPhieuNhapKho.SelectedItem = 0;
                txtTongTienNhap.Text = tongTienNhap.ToString();
            }

        }
        private void NapListViewBanHang()
        {
            if (IdDonBanHang != 0)
            {
                decimal tongTienBan = 0;
                List<DonBanHang> items = new List<DonBanHang>();
                DataTable pnt = DataProvider.Instance.ExecuteQuery("select IdChiTietDonBanHang,Thuoc.IdThuoc,TenThuoc,SoLuongBan,TenDonVi,HanSuDung,GiaBan, GiaBan*SoLuongBan as ThanhTien from DonBanHang join ChiTietDonBanHang on DonBanHang.IdDonBanHang=ChiTietDonBanHang.IdDonBanHang join Thuoc on ChiTietDonBanHang.IdThuoc=Thuoc.IdThuoc join DonVi on Thuoc.IdDonVi = DonVi.IdDonVi Where DonBanHang.IdDonBanHang=" + IdDonBanHang.ToString() + " Order by IdChitietDonBanHang DESC");
                foreach (DataRow row in pnt.Rows)
                {
                    tongTienBan += (decimal)row["ThanhTien"];
                    items.Add(new DonBanHang(row));
                }
                lsvHoaDonBan.ItemsSource = items;
                if (lsvHoaDonBan.Items.Count >= 1)
                    lsvHoaDonBan.SelectedItem = 0;
                txtTongTienThu.Text = tongTienBan.ToString();
            }
        }

        #endregion


        #region Events
        private void BtnThoat_Click(object sender, RoutedEventArgs e)
        {
            var closeMain = MessageBox.Show("Bạn có muốn đăng xuất không?", "Hệ thống quản lý cửa hàng bán thuốc", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (MessageBoxResult.Yes == closeMain)
            {
                this.Hide();
                frmLogin newLogin = new frmLogin();
                newLogin.ShowDialog();
                //System.Windows.Application.Current.Shutdown();
                //this.Close();
            }

        }

        private void BtnTrangChu_Click(object sender, RoutedEventArgs e)
        {
            tabTrangChu.Visibility = Visibility.Visible;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Hidden;
            //MessageBox.Show(DataProvider.Ins.DB.TaiKhoans.First().TenDangNhap);
        }

        private void BtnNhapKho_Click(object sender, RoutedEventArgs e)
        {
            dtpNgayLamViecNhapKho.Text = DateTime.Now.ToString();
            NapListViewNhapKho();
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Visible;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Hidden;
        }

        private void BtnBanHang_Click(object sender, RoutedEventArgs e)
        {
            dtpNgayLamViecBanHang.Text = DateTime.Now.ToString();
            DataTable table = DataProvider.Instance.ExecuteQuery("select TenCuaHang from TaiKhoan join CuaHang on TaiKhoan.IdCuaHang = CuaHang.IdCuaHang where TenDangNhap = N'" + TK + "'");
            DataRow row = table.Rows[0];
            txtCuaHangLamViec.Text = (string)row["TenCuaHang"];
            NapListViewBanHang();
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Visible;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Hidden;
            tabNhanVien.Visibility = Visibility.Hidden;
        }

        private void BtnThuoc_Click(object sender, RoutedEventArgs e)
        {
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Visible;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Hidden;
            tabNhanVien.Visibility = Visibility.Hidden;
            NapListViewDonVi();
            NapListViewThuoc();
        }
        private void BtnNhanVien_Click(object sender, RoutedEventArgs e)
        {
            if (checkRoleTaiKhoan() == "Admin")
            {
                tabTrangChu.Visibility = Visibility.Hidden;
                tabNhapKho.Visibility = Visibility.Hidden;
                tabBanHang.Visibility = Visibility.Hidden;
                tabThuoc.Visibility = Visibility.Hidden;
                tabCuaHang.Visibility = Visibility.Hidden;
                tabBaoCao.Visibility = Visibility.Hidden;
                tabTaiKhoan.Visibility = Visibility.Hidden;
                tabNhanVien.Visibility = Visibility.Visible;
                NapListViewNhanVien();
            }
            else
            {
                MessageBox.Show("Bạn Không  đủ quyền hạn để truy cập vào trang này!");
            }

        }

        private void BtnCuaHang_Click(object sender, RoutedEventArgs e)
        {
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Visible;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Hidden;
            tabNhanVien.Visibility = Visibility.Hidden;
            NapListViewCuaHang();
        }

        private void BtnBaoCao_Click(object sender, RoutedEventArgs e)
        {
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Visible;
            tabTaiKhoan.Visibility = Visibility.Hidden;
            tabNhanVien.Visibility = Visibility.Hidden;
        }


        private void BtnTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            tabTrangChu.Visibility = Visibility.Hidden;
            tabNhapKho.Visibility = Visibility.Hidden;
            tabBanHang.Visibility = Visibility.Hidden;
            tabThuoc.Visibility = Visibility.Hidden;
            tabCuaHang.Visibility = Visibility.Hidden;
            tabBaoCao.Visibility = Visibility.Hidden;
            tabTaiKhoan.Visibility = Visibility.Visible;
            tabNhanVien.Visibility = Visibility.Hidden;

        }

        private void loadData(object sender, RoutedEventArgs e)
        {
            HienThiThongTinTaiKhoan();
        }

        private void SuaTaiKhoan(object sender, RoutedEventArgs e)
        {

            editAccount frmEditAccount = new editAccount();
            frmEditAccount.Tk = TK;
            frmEditAccount.ShowDialog();
            HienThiThongTinTaiKhoan();

        }

        private void DoiMatKhau(object sender, RoutedEventArgs e)
        {
            frmDoiMatKhau frmDoiMk = new frmDoiMatKhau();
            frmDoiMk.Mk = MK;
            frmDoiMk.Tk = TK;
            frmDoiMk.ShowDialog();
        }
        #endregion

        #region Other
        private void ThemCuaHang(object sender, RoutedEventArgs e)
        {
            frmThemCuaHang newfrmThemCuaHang = new frmThemCuaHang();
            newfrmThemCuaHang.ShowDialog();
            NapListViewCuaHang();
        }

        private void SuaCuaHang(object sender, RoutedEventArgs e)
        {
            if (lsvCuaHang.Items.Count >= 1)
            {
                if (lsvCuaHang.SelectedItem != null)
                {
                    CuaHang item = (CuaHang)lsvCuaHang.SelectedItem;
                    frmSuaCuaHang newfrmSuaCuaHang = new frmSuaCuaHang(item.IdCuaHang, item.TenCuaHang, item.DiaChi);
                    newfrmSuaCuaHang.ShowDialog();
                    NapListViewCuaHang();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn cửa hàng để sửa!");
                }
            }
            else
            {
                MessageBox.Show("Không có cửa hàng nào được chọn để sửa!");
            }
        }

        private void XoaCuaHang(object sender, RoutedEventArgs e)
        {
            if (lsvCuaHang.Items.Count >= 1)
            {
                if (lsvCuaHang.SelectedItem != null)
                {
                    CuaHang item = (CuaHang)lsvCuaHang.SelectedItem;
                    var dialogRes = MessageBox.Show("Bạn có muốn xóa cửa hàng " + item.TenCuaHang + " không?", "Xóa cửa hàng", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (MessageBoxResult.Yes == dialogRes)
                    {
                        DataProvider.Instance.ExecuteQuery("delete from CuaHang where IdCuaHang = " + item.IdCuaHang);
                    }
                    NapListViewCuaHang();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn cửa hàng để xóa!");
                }
            }
            else
            {
                MessageBox.Show("Chưa có cửa hàng được chọn để xóa");
            }
        }

        private void ThemDonVi(object sender, RoutedEventArgs e)
        {
            frmThemDonVi newfrmThemDonVi = new frmThemDonVi();
            newfrmThemDonVi.ShowDialog();
            NapListViewDonVi();
        }

        private void SuaDonVi(object sender, RoutedEventArgs e)
        {
            if (lsvDonVi.Items.Count >= 1)
            {
                if (lsvDonVi.SelectedItem != null)
                {
                    DonVi item = (DonVi)lsvDonVi.SelectedItem;
                    frmSuaDonVi newfrmSuaDonVi = new frmSuaDonVi(item.IdDonvi, item.TenDonVi);
                    newfrmSuaDonVi.ShowDialog();
                    NapListViewDonVi();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn đơn vị để sửa!");
                }
            }
            else
            {
                MessageBox.Show("Chưa có đơn vị được chọn để sửa!");
            }
        }

        private void XoadonVi(object sender, RoutedEventArgs e)
        {
            if (lsvDonVi.Items.Count >= 1)
            {
                if (lsvDonVi.SelectedItem != null)
                {
                    DonVi item = (DonVi)lsvDonVi.SelectedItem;
                    var dialogRes = MessageBox.Show("Bạn có muốn xóa đơn vị " + item.TenDonVi + " không?", "Xóa đơn vị", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (MessageBoxResult.Yes == dialogRes)
                    {
                        DataProvider.Instance.ExecuteQuery("delete from DonVi where  IdDonVi = " + item.IdDonvi);
                    }
                    NapListViewDonVi();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn 1 đơn vị để xóa!");
                }
            }
            else
            {
                MessageBox.Show("Chưa có đơn vị được chọn để xóa!");
            }
        }

        private void ThemThuoc(object sender, RoutedEventArgs e)
        {
            frmThemThuoc wd = new frmThemThuoc();
            wd.ShowDialog();
            NapListViewThuoc();
        }

        private void SuaThuoc(object sender, RoutedEventArgs e)
        {
            if (lsvThuoc.Items.Count >= 1)
            {
                if (lsvThuoc.SelectedItem != null)
                {
                    Thuoc item = (Thuoc)lsvThuoc.SelectedItem;
                    frmSuaThuoc newfrmSuaThuoc = new frmSuaThuoc(item);
                    newfrmSuaThuoc.ShowDialog();
                    NapListViewThuoc();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn thuốc để sửa!");
                }
            }
            else
            {
                MessageBox.Show("Danh sách thuốc rỗng!");
            }
        }

        private void XoaThuoc(object sender, RoutedEventArgs e)
        {
            if (lsvThuoc.Items.Count >= 1)
            {
                if (lsvThuoc.SelectedItem != null)
                {
                    Thuoc item = (Thuoc)lsvThuoc.SelectedItem;
                    MessageBoxResult dialogRes = MessageBox.Show("Bạn có muốn xóa thuốc " + item.TenThuoc + " không?", "Xóa thuốc", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (MessageBoxResult.Yes == dialogRes)
                    {
                        DataProvider.Instance.ExecuteQuery("delete from Thuoc where IdThuoc = " + item.IdThuoc);
                    }
                    NapListViewThuoc();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn 1 thuốc để xóa!");
                }
            }
            else
            {
                MessageBox.Show("Danh sách thuốc rỗng!");
            }
        }
        #endregion

        private void ThemNhapKho(object sender, RoutedEventArgs e)
        {
            if (IdPhieuNhapKho != 0)
            {
                frmThemNhapKho newfrmThemNhapKho = new frmThemNhapKho(IdPhieuNhapKho);
                newfrmThemNhapKho.ShowDialog();
                NapListViewNhapKho();
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo hóa đơn nhập kho!");
            }
        }

        private void XoaNhapKho(object sender, RoutedEventArgs e)
        {
            if (IdPhieuNhapKho != 0)
            {
                if (lsvPhieuNhapKho.Items.Count >= 1)
                {
                    if (lsvPhieuNhapKho.SelectedItem != null)
                    {
                        PhieuNhapThuoc item = (PhieuNhapThuoc)lsvPhieuNhapKho.SelectedItem;
                        MessageBoxResult dialogRes = MessageBox.Show("Bạn có chắc chắn muốn xóa item đã chọn không? ", "Xóa chi tiết phiếu nhập kho", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (MessageBoxResult.Yes == dialogRes)
                        {
                            DataProvider.Instance.ExecuteQuery("update Thuoc Set SoLuong = SoLuong - " + item.SoLuongNhap.ToString() + " Where IdThuoc=" + item.IdThuoc.ToString());
                            DataProvider.Instance.ExecuteQuery("delete from ChiTietPhieuNhapKho where IdChiTietPhieuNhapKho = " + item.IdChiTietPhieuNhapKho.ToString());
                        }
                        NapListViewNhapKho();
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải chọn 1 item để xóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo hóa đơn nhập kho!");
            }
        }

        private void TaoHoaDonNhap(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogRes = MessageBox.Show("Bạn có chắc chắn muốn tạo hóa đơn nhập không? ", "Tạo hóa đơn nhập kho", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialogRes == MessageBoxResult.Yes)
            {
                MessageBox.Show("Tạo thành công! Mời bạn nhập chi tiết hóa đơn nhập!");
                DataProvider.Instance.ExecuteQuery("insert PhieuNhapKho values ('" + dtpNgayLamViecNhapKho.Text + "')");
                // Hiển thị ID
                DataTable table = DataProvider.Instance.ExecuteQuery("Select * from PhieuNhapKho Order by IdPhieuNhapKho DESC");
                DataRow phieuNhapKho = table.Rows[0];
                IdPhieuNhapKho = (int)phieuNhapKho["idPhieuNhapKho"];
                GroupBoxNhapKho.Header = "Nhập kho - Mã phiếu: " + IdPhieuNhapKho.ToString();
                NapListViewNhapKho();
            }
        }

        private void TaoHoaDonBan(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dialogRes = MessageBox.Show("Bạn có chắc chắn muốn tạo hóa đơn bán không? ", "Tạo hóa đơn bán hàng", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialogRes == MessageBoxResult.Yes)
            {
                MessageBox.Show("Tạo thành công! Mời bạn nhập chi tiết hóa đơn bán hàng!");
                DataProvider.Instance.ExecuteQuery("insert DonBanHang values ('" + dtpNgayLamViecBanHang.Text + "'," + IdCuaHang.ToString() + ")");
                // Hiển thị ID
                DataTable table = DataProvider.Instance.ExecuteQuery("Select * from DonBanHang Order by IdDonBanHang DESC");
                DataRow donBanHang = table.Rows[0];
                IdDonBanHang = (int)donBanHang["idDonBanHang"];
                groupDonBanHang.Header = "Bán hàng - Mã phiếu: " + IdDonBanHang.ToString();
                NapListViewBanHang();
            }
        }

        private void ThemDonBanHang(object sender, RoutedEventArgs e)
        {
            if (IdDonBanHang != 0)
            {
                frmThemDonBanHang newfrmThemDonBanHang = new frmThemDonBanHang(IdDonBanHang);
                newfrmThemDonBanHang.ShowDialog();
                NapListViewBanHang();
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo hóa đơn bán hàng!");
            }
        }

        private void XoaDonBanHang(object sender, RoutedEventArgs e)
        {
            if (IdDonBanHang != 0)
            {
                if (lsvHoaDonBan.Items.Count >= 1)
                {
                    if (lsvHoaDonBan.SelectedItem != null)
                    {
                        DonBanHang item = (DonBanHang)lsvHoaDonBan.SelectedItem;
                        MessageBoxResult dialogRes = MessageBox.Show("Bạn có chắc chắn muốn xóa item đã chọn không?", "Xóa chi tiết đơn bán hàng", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (MessageBoxResult.Yes == dialogRes)
                        {
                            DataProvider.Instance.ExecuteQuery("update Thuoc Set SoLuong = SoLuong + " + item.SoLuongBan.ToString() + " Where IdThuoc=" + item.IdThuoc.ToString());
                            DataProvider.Instance.ExecuteQuery("delete from ChiTietDonBanHang where IdChitietDonBanHang = " + item.IdChiTietDonBanHang.ToString());
                        }
                        NapListViewBanHang();
                    }
                    else
                    {
                        MessageBox.Show("Bạn phải chọn 1 item để xóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Danh sách rỗng!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa tạo hóa đơn bán hàng!");
            }
        }

        private void BaoCaoNhapKho_Click(object sender, RoutedEventArgs e)
        {
            if (dtpNgayBatDauBaoCaoNhapKho.Text == "" || dtpNgayKetThucBaoCaoNhapKho.Text == "")
            {
                MessageBox.Show("Bạn phải chọn đầy đủ ngày bắt đầu và kết thúc!");
            }
            else
            {
                decimal tongTienNhap = 0;
                List<BaoCaoNhap> items = new List<BaoCaoNhap>();
                DataTable bcn = DataProvider.Instance.ExecuteQuery("select TenThuoc,SoLuongNhap,TenDonVi,GiaNhap,NgayNhap, SoLuongNhap*GiaNhap as ThanhTien from ChiTietPhieuNhapKho join PhieuNhapKho on PhieuNhapKho.IdPhieuNhapKho = ChiTietPhieuNhapKho.IdPhieuNhapKho join Thuoc on Thuoc.IdThuoc = ChiTietPhieuNhapKho.IdThuoc join DonVi on DonVi.IdDonVi = Thuoc.IdDonVi where NgayNhap between '" + dtpNgayBatDauBaoCaoNhapKho.Text + "' and '" + dtpNgayKetThucBaoCaoNhapKho.Text + "' order by NgayNhap DESC");
                foreach (DataRow row in bcn.Rows)
                {
                    tongTienNhap += (decimal)row["ThanhTien"];
                    items.Add(new BaoCaoNhap(row));
                }
                lsvBaoCao.ItemsSource = items;
                groupboxBaoCao.Header = "Báo cáo nhập kho - Tổng tiền nhập: " + tongTienNhap.ToString();
            }
        }

        private void BaoCaoBanHang_Click(object sender, RoutedEventArgs e)
        {
            if (dtpNgayBatDauBaoCaoBanHang.Text == "" || dtpNgayKetThucBaoCaoBanHang.Text == "")
            {
                MessageBox.Show("Bạn phải chọn đầy đủ ngày bắt đầu và kết thúc!");
            }
            else
            {
                decimal tongTienBan = 0;
                List<BaoCaoBan> items = new List<BaoCaoBan>();
                DataTable bcb = DataProvider.Instance.ExecuteQuery("select TenThuoc,SoLuongBan,TenDonVi,GiaBan,NgayBan, SoLuongBan*GiaBan as ThanhTien from ChiTietDonBanHang join DonBanHang on DonBanHang.IdDonBanHang = ChiTietDonBanHang.IdDonBanHang join Thuoc on Thuoc.IdThuoc = ChiTietDonBanHang.IdThuoc join DonVi on DonVi.IdDonVi = Thuoc.IdDonVi where NgayBan between '" + dtpNgayBatDauBaoCaoBanHang.Text + "' and '" + dtpNgayKetThucBaoCaoBanHang.Text + "' order by NgayBan DESC");
                foreach (DataRow row in bcb.Rows)
                {
                    tongTienBan += (decimal)row["ThanhTien"];
                    items.Add(new BaoCaoBan(row));
                }
                lsvBaoCao.ItemsSource = items;
                groupboxBaoCao.Header = "Báo cáo bán hàng - Tổng tiền thu: " + tongTienBan.ToString();
            }
        }
        private void ThemNhanVien(object sender, RoutedEventArgs e)
        {
            frmThemNhanVien newfrmThemNhanVien = new frmThemNhanVien();
            newfrmThemNhanVien.ShowDialog();
            NapListViewNhanVien();
        }
        private void XoaNhanVien(object sender, RoutedEventArgs e)
        {
            if (lsvNhanVien.Items.Count >= 1)
            {
                if (lsvNhanVien.SelectedItem != null)
                {
                    TaiKhoan item = (TaiKhoan)lsvNhanVien.SelectedItem;
                    var dialogRes = MessageBox.Show("Bạn có muốn xóa  nhân viên" + item.TenHienThi + " không?", "Xóa nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (MessageBoxResult.Yes == dialogRes)
                    {
                        DataProvider.Instance.ExecuteQuery("delete from TaiKhoan where IdTaiKhoan = " + item.IdTaiKhoan);
                    }
                    NapListViewNhanVien();
                }
                else
                {
                    MessageBox.Show("Bạn phải chọn nhân viên  để xóa!");
                }
            }
            else
            {
                MessageBox.Show("Chưa có nhân viên nào  được chọn để xóa");
            }
        }
        private void SuaThongTinNhanVien(object sender, RoutedEventArgs e)
        {
            if (lsvNhanVien.Items.Count >= 1)
            {
                if (lsvNhanVien.SelectedItem != null)
                {
                    TaiKhoan item = (TaiKhoan)lsvNhanVien.SelectedItem;
                    frmSuaThongTinNhanVien newfrmSuathongTinNhanVien = new frmSuaThongTinNhanVien(item);
                    newfrmSuathongTinNhanVien.ShowDialog();
                    NapListViewNhanVien();
                }
                else
                {
                    MessageBox.Show("Bạn phải  chọn nhân viên để sửa!");
                }
            }
            else
            {
                MessageBox.Show("Danh sách nhân viên rỗng!");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchTextBox.Text;

            
            DataTable data = DataProvider.Instance.ExecuteQuery("select t.*, c.TenCuaHang from TaiKhoan as t join CuaHang as c on t.idcuahang=c.idcuahang WHERE t.TenDangNhap LIKE '%" + searchText + "%'");
            List<TaiKhoan> items = new List<TaiKhoan>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new TaiKhoan(row));
            }
            lsvNhanVien.ItemsSource = items;
            if(lsvNhanVien.Items.Count <= 0)
            {
                MessageBox.Show("Không có kết quả phù hợp với tên bạn đang tìm kiếm!");
                searchTextBox.Text = "";
                NapListViewNhanVien();
            }
        }
        private void btn_TimThuoc(object sender, RoutedEventArgs e)
        {
            string searchText = tbThuoc.Text;


            DataTable data = DataProvider.Instance.ExecuteQuery("select IdThuoc,TenThuoc,HanSuDung,SoLuong,TenDonVi,GiaNhap,GiaBan,GhiChu from Thuoc Join DonVi on Thuoc.IdDonVi = DonVi.IdDonVi WHERE Thuoc.TenThuoc LIKE '%" + searchText + "%'");
            List<Thuoc> items = new List<Thuoc>();
            foreach (DataRow row in data.Rows)
            {
                items.Add(new Thuoc(row));
            }
            lsvThuoc.ItemsSource = items;
            if (lsvThuoc.Items.Count <= 0)
            {
                MessageBox.Show("Không có kết quả phù hợp với tên bạn đang tìm kiếm!");
                searchTextBox.Text = "";
                NapListViewThuoc();
            }
        }

        private void Tieudetrangchu_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
