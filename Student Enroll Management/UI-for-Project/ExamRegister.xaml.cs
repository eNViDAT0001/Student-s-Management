using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ExamRegister.xaml
    /// </summary>
    public partial class ExamRegister : Window
    {
        public ExamRegister()
        {
            InitializeComponent();

            // CHỈ CÓ ADMIN MỚI CÓ THỂ NHẤN BUTTON FINISH
            // XÉT CÓ LÀ ADMIN K ,NẾU K THÌ K CHO NHẤN
            if (confirmPerson.getPersonPermission() == "USER")
                btnFinishRegister.IsEnabled = false;
            else
                btnFinishRegister.IsEnabled = true;
        }
        private DataGridTextColumn AddColumn(string header, string nameBinding, int width)
        {
            //<DataGridTextColumn Binding="{Binding so_bao_danh }" Header="so_bao_danh" Width="80"/>
            DataGridTextColumn tc = new DataGridTextColumn();
            tc.Header = header;
            tc.Width = width;
            Binding tcBinding = new Binding(nameBinding);
            tc.Binding = tcBinding;
            return tc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns.Add(AddColumn("Số phiếu", "so_phieu", 80));
            dataGrid.Columns.Add(AddColumn("Khối thi", "khoi_thi", 80));
            dataGrid.Columns.Add(AddColumn("Họ và tên", "ho_va_ten", 120));
            dataGrid.Columns.Add(AddColumn("Khu vực", "khu_vuc", 120));
            dataGrid.Columns.Add(AddColumn("Năm tốt nghiệp", "nam_tot_nghiep", 80));
            dataGrid.Columns.Add(AddColumn("Hệ đào tạo", "he_dao_tao", 80));
            dataGrid.Columns.Add(AddColumn("Mã đối tượng", "ma_doi_tuong", 80));
            dataGrid.Columns.Add(AddColumn("Đăng kí thi", "dang_ki_thi", 80));
            dataGrid.Columns.Add(AddColumn("Mã trường", "ma_truong", 80));
            dataGrid.Columns.Add(AddColumn("Mã ngành", "ma_nganh", 100));
            dataGrid.Columns.Add(AddColumn("Ngày sinh", "ngay_sinh", 100));
            dataGrid.Columns.Add(AddColumn("Nơi sinh", "noi_sinh", 120));
            dataGrid.Columns.Add(AddColumn("Địa chỉ báo tin", "dia_chi_bao_tin", 120));

            Query = "select * from PHIEU_DKDT";
            nameTable = "PHIEU_DKDT";

            con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;


            da = new SqlDataAdapter(cmd);
            dt = new System.Data.DataTable(nameTable);
            da.Fill(dt);

            // load data lên datagrid
            dataGrid.ItemsSource = dt.DefaultView;
        }

        string Query;
        string nameTable;
        DataTable dt;
        SqlDataAdapter da;
        SqlConnection con;
        SqlCommand cmd;
        private void dataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //HÀM NÀY CÓ TÁC DỤNG LÀ TABLE THAY ĐỔI LÀ TỰ ĐỘNG CẬP NHẬP SQL NÊN K CẦN CLICK  BUTTON, CHỈ CẦN THÔNG BÁO LÀ ĐC
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.UpdateCommand = builder.GetUpdateCommand();
            da.Update(dt);
            
            MessageBox.Show(" da update");
        }
        public void loadSQL()
        {
            Query = "select * from PHIEU_DKDT";
            nameTable = "PHIEU_DKDT";

            con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            cmd = con.CreateCommand();
            cmd.CommandText = Query;


            da = new SqlDataAdapter(cmd);
            dt = new System.Data.DataTable(nameTable);
            da.Fill(dt);

            // load data lên datagrid
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            loadSQL();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Saved.");
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dataGrid.SelectedItem as DataRowView;
            if (drv != null)
            {
                DataView dataView = dataGrid.ItemsSource as DataView;
                hoten = drv[2].ToString();
                noisinh = drv[11].ToString();
                diachibaotin = drv[12].ToString();
                //MessageBox.Show(drv[2].ToString());
                dataView.Table.Rows.Remove(drv.Row);
            }
            // LẦN LƯỢT XÓA HẾT DỮ LIỆU CỦA CÁC BẢNG  PHIEU_DKDT, THI_SINH, GIAY_BAO_THI,BAI_THI, KET_QUA_CHAM_THI
            string delete_so_bao_danh = getSo_Bao_Danh(hoten, noisinh, diachibaotin);

            sqlExamRegister.deleteItemSelected_KET_QUA_CHAM_THI(delete_so_bao_danh);
            sqlExamRegister.deleteItemSelected_BAI_THI(delete_so_bao_danh);
            sqlExamRegister.deleteItemSelected_GIAY_BAO_THI(delete_so_bao_danh);
            sqlExamRegister.deleteItemSelected_THI_SINH(delete_so_bao_danh);
            sqlExamRegister.deletItemSelectede_PHIEU_DKDT(hoten,noisinh,diachibaotin);
        }
        string hoten;
        string noisinh;
        string diachibaotin;

        public string getSo_Bao_Danh(string ho_ten, string noi_sinh, string dia_chi_bao_tin)
        {
            string so_bao_danh = "";
            string Query = "select * from THI_SINH";
            string nameTable = "THI_SINH";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["ho_ten"] == ho_ten && (string)row["noi_sinh"] == noi_sinh && (string)row["dia_chi_bao_tin"] == dia_chi_bao_tin)
                    so_bao_danh =(string) row["so_bao_danh"];
            }
            return so_bao_danh;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editRegister = new RegisterEditing();
            editRegister.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFinishRegister_Click(object sender, RoutedEventArgs e)
        {
            if (confirmPerson.getPersonPermission() == "ADMIN")
            {
                SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
                //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                
                string update = "update CONFIRM_REGISTER set confirm = 'true'";
                cmd.CommandText = update;
                cmd.ExecuteNonQuery();
                MessageBox.Show("FINISH REGISTER.");

                var main = new MainWindow();
                main.Show();
                this.Close();
            }
            else
            {
                var Result = MessageBox.Show("Note", "You need ADMIN permission.Do you want to log out?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    var login = new Login();
                    login.Show();
                    this.Close();
                }
                else if (Result == MessageBoxResult.No)
                {
                    
                }
            }
        }

       
    }
}
