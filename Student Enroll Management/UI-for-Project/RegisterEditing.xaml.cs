using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for RegisterEditing.xaml
    /// </summary>
    public partial class RegisterEditing : Window
    {
        public RegisterEditing()
        {
            InitializeComponent();
            txtbSo_phieu.IsReadOnly = true;

            // HÀM CÓ CÓ TÁC DỤNG TÌM SỐ PHIẾU CUỐI CÙNG VÀ LẤY PHẦN SỐ +1 ĐỂ RA SỐ PHIẾU MỚI
            txtbSo_phieu.Text = sqlRegisterEditing.getNumber_Last_SoPhieu();
        }
        //string so_phieu = "";
        string khoi_thi = "";
        //string ho_va_ten = "";
        //string he_dao_tao = "";
        //int nam_tot_nghiep = 0;
        string khu_vuc = "Khu vực 2NT";
        string dang_khi_thi = "CB";
        string ma_truong = "";
        int ma_nganh = 7340122;
        //string ngay_sinh = "";
        //string noi_sinh = "";
        //string dia_chi_bao_tin = "";

        string so_bao_danh;
        string dia_diem_thi = "Trường đại học Khoa Học Tự Nhiên";
        string so_phong_thi = "A301";

        int so_phach;

        private void cbxMa_nganh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string subject = cbxMa_nganh.SelectedItem.ToString();
            string[] arr = subject.Split(":");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 1)
                {
                    ma_nganh = int.Parse(arr[i].Trim());
                    //MessageBox.Show(int.Parse(arr[i].Trim()).ToString());
                }
            }
        }

        private void cbxDang_ki_thi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string subject = cbxDang_ki_thi.SelectedItem.ToString();
            string[] arr = subject.Split(":");
            for (int i = 0; i < arr.Length; i++)
                dang_khi_thi = arr[i].Trim();
        }
        private void cbxKhu_vuc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string subject = cbxKhu_vuc.SelectedItem.ToString();
            string[] arr = subject.Split(":");
            for (int i = 0; i < arr.Length; i++)
                khu_vuc = arr[i].Trim();
        }
        private void cbxKhoi_thi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string subject = cbxKhoi_thi.SelectedItem.ToString();
            string[] arr = subject.Split(":");
            for (int i = 0; i < arr.Length; i++)
                khoi_thi = arr[i].Trim();
        }

        private void cbxMa_truong_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string subject = cbxMa_truong.SelectedItem.ToString();
            string[] arr = subject.Split(":");
            for (int i = 0; i < arr.Length; i++)
                ma_truong = arr[i].Trim();
            string[] b = ma_truong.Split(' ');
            ma_truong = b[0];
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            if (Dien_Het_Chua() == false || DUNG_CU_PHAP() != 0)
            {
                string mess = "";
                if (DUNG_CU_PHAP() == 3)
                    mess = "Incorrect 'Nam tot nghiep','Ngay sinh'";

                else if (DUNG_CU_PHAP() == 2)
                    mess = "Incorrect 'Nam tot nghiep'";
                else
                    mess = "Incorrect 'Ngay Sinh'";
                var Result = MessageBox.Show(mess, "Watch out!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {

                }
                else if (Result == MessageBoxResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                txtbHe_dao_tao.Text = dang_khi_thi;

                INSERT_SQL_PHIEU_DKDT();
                INSERT_SQL_THI_SINH();
                INSERT_SQL_GIAY_BAO_THI();
                INSERT_SQL_BAI_THI();
                INSERT_SQL_KET_QUA_CHAM_THI();
                MessageBox.Show("Submited. Please press 'Load from database' to update.");
                this.Close();
            }
        }
        // THÊM VÀO 5 BẢNG LÀ BẢNG PHIEU_DKDT, THI_SINH, GIAY_BAO_THI,BAI_THI, KET_QUA_CHAM_THI
        public void INSERT_SQL_PHIEU_DKDT()
        {
            // PHIEU_DKDT
            string Query = string.Format("insert into PHIEU_DKDT values ('{0}','{1}', N'{2}', N'{3}', {4},N'{5}', NULL, N'{6}', '{7}', '{8}',CONVERT(smalldatetime,cast('{9}' as date),103), N'{10}', N'{11}')", txtbSo_phieu.Text, khoi_thi, txtbHo_va_ten.Text, khu_vuc.ToString(),int.Parse( txtNam_tot_nghiep.Text), txtbHe_dao_tao.Text, dang_khi_thi, ma_truong, ma_nganh, txtNgay_sinh.Text, txtNoi_sinh.Text, txtDia_chi_bao_tin.Text);
            Debug.WriteLine(Query);

            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
            
            cmd.ExecuteNonQuery();
        }
        public void INSERT_SQL_THI_SINH()
        {
            so_bao_danh = sqlRegisterEditing.getNumber_Last_So_Bao_Danh();
            string Query = string.Format("insert into THI_SINH values('{0}',N'{1}',CONVERT(smalldatetime,cast('{2}' as date)),N'{3}',N'{4}')", so_bao_danh, txtbHo_va_ten.Text, txtNgay_sinh.Text, txtNoi_sinh.Text, txtDia_chi_bao_tin.Text);

            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
           
            cmd.ExecuteNonQuery();
        }
        public void INSERT_SQL_GIAY_BAO_THI()
        {
            // Cho thi tại trường đã đăng kí lun
            if (ma_truong == "QSC")
                dia_diem_thi = "Trường ĐH Công Nghệ Thông Tin";
            else
                dia_diem_thi = "Trường ĐH Khoa Học Tự Nhiên";
            string Query = string.Format("insert into GIAY_BAO_THI values ('{0}',CONVERT(smalldatetime,cast('{1}' as date)), N'{2}', 'C101', 30000.0000)", so_bao_danh, txtNgay_sinh.Text,dia_diem_thi.ToString());

            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;
           
            cmd.ExecuteNonQuery();
        }

        
        public void INSERT_SQL_BAI_THI()
        {
            string arr_ma_mon= sqlRegisterEditing.getKhoi_Thi(khoi_thi);
            string[] arr = arr_ma_mon.Split(" ");
            for(int i = 0; i < arr.Length; i++)
            {
                string ma_tui = "T00" + arr[i];
                so_phach = sqlRegisterEditing.getNumber_Last_So_Phach();
                string Query = string.Format("insert into BAI_THI values({0}, '{1}', '{2}')",so_phach, so_bao_danh, ma_tui);

                SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = Query;
               
                cmd.ExecuteNonQuery();
            }
            
        }
        public void INSERT_SQL_KET_QUA_CHAM_THI()
        {
            string arr_ma_mon = sqlRegisterEditing.getKhoi_Thi(khoi_thi);
            string[] arr = arr_ma_mon.Split(" ");
            for (int i = 0; i < arr.Length; i++)
            {
                int ma_mon = int.Parse(arr[i]);
                int so_phach_real = sqlRegisterEditing.getSoPhach_from_BAI_THI(so_bao_danh, ma_mon);
                string Query = string.Format("insert into KET_QUA_CHAM_THI values({0},0,'{1}',{2})",so_phach_real,so_bao_danh,ma_mon);

                SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = Query;
               
                cmd.ExecuteNonQuery();
            }
        }



        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public bool Dien_Het_Chua()
        {
            if (txtNgay_sinh.Text == ""   || txtbHo_va_ten.Text == ""|| txtNoi_sinh.Text=="" || txtDia_chi_bao_tin.Text=="" || txtNam_tot_nghiep.Text=="")
            {
                return false;
            }
            else
                return true;
        }
        public int DUNG_CU_PHAP()
        {

            int daugach = 0;
            int ngaythangnam = 0;
            
            string ngaysinh = txtNgay_sinh.Text.ToString();
            for(int i = 0; i < ngaysinh.Length; i++)
            {
                if (ngaysinh[i].ToString().Equals("/"))
                    daugach++;
            }

            string [] arr= ngaysinh.Split(new[] { '/' });
            for (int i = 0; i < arr.Length; i++)
            {
                int my;
                if (int.TryParse(arr[i], out my))
                    ngaythangnam++;
            }
            int my1;
            if (daugach == 2 && ngaythangnam == 3 && int.TryParse(txtNam_tot_nghiep.Text, out my1))
                return 0;
            else if (daugach != 2 || ngaythangnam != 3)
                return 1;
            else if (int.TryParse(txtNam_tot_nghiep.Text, out my1) == false)
                return 2;
            else
                return 3;


        }

    }
}
