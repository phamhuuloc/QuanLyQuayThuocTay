   M S B A M L   `   `   `  ����J  FQuanLyHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:QuanLyHieuThuocQuanLyHieuThuoc  5   	   !    QuanLyHieuThuoc.frmSuaThuoc   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:QuanLyHieuThuoc     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  Sửa thuốc��5   	   $	��550��6   $	��300��6(    � 
ResizeMode$ NoResize=�64    � WindowStartupLocation$ CenterScreen=�6J      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      � .+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Bold"�6   .��6*   ID Thuốc:66   �� 5      -   5         ��Name$ 
txtIdThuoc��5      $
��Bold"�60   $��Center=�6B   6_   5      �� 5      $
��Bold"�6   .��6&   Tên thuốc (*):66   �� 5      -   5         ��Name$ txtTenThuoc��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên thuốc��5       % !MaterialDesignFloatingHintTextBox#��[ 5      �� 5      $
��Bold"�6   .��6&   Hạn sử dụng:64   (  "System.Windows.Controls.DatePicker  5      -   5        	  Name$	 dtpHanSuDung��5   @   $	��280��6   $
��Left=�6%   6@   �� 5      $
��Bold"�6   .��6&   Số lượng (*):65   �� 5      -   5        $ 
txtSoLuong��5      $ Nhập số lượng��5       #��[ 5!      �� 5"      $
��Bold"�6   .��6&   Đơn vị (*):63   �� 5#      -   5        
 ��Name$
 cbDonVi��5#       �� SelectedIndex$ 0��6(   5$      �� 5&      $
��Bold"�6   .��6&   Giá nhập (*):65   �� 5'      -   5        $ 
txtGiaNhap��5'      $ Nhập giá nhập��5(      #��[ 5)      �� 5*      $
��Bold"�6   .��6&   Giá bán (*):64   �� 5+      -   5        $ 	txtGiaBan��5+      $ Nhập giá bán��5,      #��[ 5-      �� 5.      $
��Bold"�6   .��6&   	Ghi chú:60   �� 5/      -	   5        $ 	txtGhiChu��5/      $! Nhập ghi chú cho thuốc��50      #��[ 51      � 53       � ColumnDefinitions 54      �� 55      $	��150 �6'   65   �� 56      $	��150 �6'   65   .+�58      � $��0��6   .+�59      �� -
   5          MaterialDesignRaisedButton#��[ 5:      $	��100��5;      .��6%   Sửa5=      5>      � 5?      $��1��6   .+�5@      �� -   5        #��[ 5A      $	��100��5B      .��6(   Hủy5D      5E      5F      5G      5H      5I      