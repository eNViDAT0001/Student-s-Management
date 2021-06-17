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

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for PhieuBaoDiem.xaml
    /// </summary>
    public partial class PhieuBaoDiem : Window
    {
        public PhieuBaoDiem()
        {
            InitializeComponent();
        }
        public PhieuBaoDiem(string hoTen, string ngaySinh, string diaChiBaoTin, string noiSinh, string soBaoDanh, string diemMon1, string diemMon2, string diemMon3, string tongDiem, string trungTuyen) : this()

        {

            txtHo_ten.Text = hoTen;
            txtNgay_Sinh.Text = ngaySinh;
            txtDia_chi_bao_tin.Text = diaChiBaoTin; 
            txtNoi_sinh.Text = noiSinh;
            txtSo_bao_danh.Text = soBaoDanh;
            txtDiemMon1.Text = diemMon1;
            txtDiemMon2.Text = diemMon2;
            txtDiemMon3.Text = diemMon3;
            txtTongDiem.Text = tongDiem;
            txtTrungTuyen.Text = trungTuyen;
            
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    btnPrint.Visibility = Visibility.Collapsed;
                    printDialog.PrintVisual(phieuBaoDiem, "Info");
                }
            }
            finally
            {
                btnPrint.Visibility = Visibility.Visible;

            }

        }
    }
}
