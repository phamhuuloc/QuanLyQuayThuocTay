   M S B A M L   `   `   `  ����J  FQuanLyHieuThuoc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:QuanLyHieuThuocQuanLyHieuThuoc  5   	   !    QuanLyHieuThuoc.frmSuaDonVi   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:QuanLyHieuThuoc     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          � Title$  Sửa đơn vị��5   	   $	��250��6   $	��250��6)    � 
ResizeMode$ NoResize=�65    � WindowStartupLocation$ CenterScreen=�6K      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   .��5      � $	��230��6   $	��200��6    � RowDefinitions 5   
   �� 5      $	��100 �6   6+   �� 5      $��50 �6   6*   .+�5   
   � $��0��6   .+�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $
��Bold"�6   .��6.   Mã đơn vị:6;   �� 5      -   5         ��Name$ 
txtMaDonVi��5       $
��Bold"�64   {�. $��Center=�6W   6t   5      �� 5      $
��Bold"�6   .��6*   Nhập tên đơn vị:6<   �� 5      -   5         ��Name$ txtSuaDonVi��5      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Nhập tên đơn vị��5       % !MaterialDesignFloatingHintTextBox#��[ 5      5       5!      � 5"   
   $��1��6   
 � ColumnDefinitions
 5#      �� 5$      $	��100 �6#   61   �� 5%      $	��100 �6#   61   .+�5'      � $��0��6   $
��Left=�6#   .+�5(      �� -   5          MaterialDesignRaisedButton#��[ 5)      $	��100��5*      .��6%   Sửa5,      5-      � 5.      $��1��6   $��Right=�6#   .+�5/      �� -   5        #��[ 50      $	��100��51      .��6(   Hủy53      54      55      56      57      