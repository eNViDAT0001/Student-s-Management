using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI_for_Project.Model;
using System.Data;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for PhieuBaoThi.xaml
    /// </summary>
    public partial class PhieuBaoThi : Window
    {

        //string hoTen, ngaySinh, diaChiBaoTin, diaDiemThi, ngayThi, noiSinh, soBaoDanh, soPhongThi, lePhiThi;
        public PhieuBaoThi()
        {
            InitializeComponent();
        }

        public PhieuBaoThi(string hoTen, string ngaySinh, string diaChiBaoTin, string diaDiemThi, string ngayThi, string noiSinh, string soBaoDanh, string soPhongThi, string lePhiThi) : this()

        {
            
            txtHo_ten.Text = hoTen;
            txtNgay_Sinh.Text = ngaySinh;
            txtDia_chi_bao_tin.Text = diaChiBaoTin;
            txtDia_diem_thi.Text = diaDiemThi;
            txtNgay_thi.Text = ngayThi;
            txtNoi_sinh.Text = noiSinh;
            txtSo_bao_danh.Text = soBaoDanh;
            txtSo_phong_thi.Text = soPhongThi;
            txtLe_phi_thi.Text = lePhiThi;
        }



        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    btnPrint.Visibility = Visibility.Collapsed;
                    printDialog.PrintVisual(phieuBaoThi, "Info");
                }
            }
            finally
            {
               
                this.Visibility = Visibility.Visible;

            }
        }
    }
}
