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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI_for_Project.Controller;
using UI_for_Project.Model;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for CandidateList.xaml
    /// </summary>
    public partial class EditScoring : Page
    {
        public EditScoring()
        {
            InitializeComponent();

        }
        string subName = "";
        public EditScoring(string namesub)
        {

            InitializeComponent();
            subName = namesub;
            //MessageBox.Show("edit scoring");
        }

        public int convertSub(string name)
        {
            int int_sub = 0;
            switch (name)
            {
                case "Toán":
                    int_sub = 1;
                    break;
                case "Ngữ Văn":
                    int_sub = 2;
                    break;
                case "Anh Văn":
                    int_sub = 3;
                    break;
                case "Vật Lý":
                    int_sub = 4;
                    break;
                case "Hóa Học":
                    int_sub = 5;
                    break;
                case "Sinh Học":
                    int_sub = 6;
                    break;
                case "Lịch Sử":
                    int_sub = 7;
                    break;
                case "Địa Lý":
                    int_sub = 8;
                    break;
                case "GDCD":
                    int_sub = 9;
                    break;
            }
            return int_sub;
        }
        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int a = convertSub(subName);

            Query = "select so_phach, diem_thi,ma_mon from KET_QUA_CHAM_THI where ma_mon =" + a;
            nameTable = "KET_QUA_CHAM_THI";

            // NẾU MÀ ADMIN NHẤN NÚT CONFIRM RỒI THÌ K CHO USER NHẬP NỮA
            if (confirmEditScoring.confirmed(a) == true)
            {
                if (confirmPerson.getPersonPermission() == "USER")
                {
                    btnConfirm.IsEnabled = false;
                    datagridScore.IsReadOnly = true;
                }
            }
            else if (confirmEditScoring.confirmed(a) == false)
            {
                if (confirmPerson.getPersonPermission() == "USER")
                {
                    btnConfirm.IsEnabled = true;
                    datagridScore.IsReadOnly = false;
                }
            }
            if (confirmPerson.getPersonPermission() == "ADMIN")
                btnConfirm.Content = "Confirm";
            if (confirmPerson.getPersonPermission() == "USER")
                btnConfirm.Content = "Finish";

            loadData();
        }


        string Query;
        string nameTable;
        DataTable dt;
        SqlDataAdapter da;
        SqlConnection con;
        public void loadData()
        {
            con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            // câu lệnh cần thực hiện
            //string Get_Data = "select THI_SINH.so_bao_danh,ho_ten, ngay_thi,so_phong_thi,dia_diem_thi from THI_SINH, GIAY_BAO_THI";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = Query;


            da = new SqlDataAdapter(cmd);
            dt = new System.Data.DataTable(nameTable);
            da.Fill(dt);

            // load data lên datagrid
            datagridScore.ItemsSource = dt.DefaultView;
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // XÉT XEM ĐÃ NHẬP ĐIỂM HẾT CHƯA, NHẬP HẾT RÒI MỚI CHO ADMIN BẤM NÚT CONFIRM
            if (confirmPerson.getPersonPermission() == "ADMIN")
            {
                if (confirmEditScoring.Diem_Nhap_Het_Chua(convertSub(subName)) == true)
                {
                    if (confirmEditScoring.confirmed(convertSub(subName)) == true)
                    {
                        confirmEditScoring.confirmSubject(convertSub(subName), false);
                    }
                    else if (confirmEditScoring.confirmed(convertSub(subName)) == false)
                    {
                        confirmEditScoring.confirmSubject(convertSub(subName), true);
                    }

                }
                else
                {
                    MessageBox.Show("You must complete data entry.");
                }
            }
            // CLICK THÌ SẼ LƯU DỮ LIỆU NHẬP VÀO SQL
            // SẼ CÓ 1 HÀM KIỂM TRA DỮ LIỆU NHẬP
            else if (confirmPerson.getPersonPermission() == "USER")
            {
                MessageBox.Show("Saved.");
            }
        }

        private void datagridScore_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            //HÀM NÀY CÓ TÁC DỤNG LÀ TABLE THAY ĐỔI LÀ TỰ ĐỘNG CẬP NHẬP SQL NÊN K CẦN CLICK  BUTTON, CHỈ CẦN THÔNG BÁO LÀ ĐC
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            da.UpdateCommand = builder.GetUpdateCommand();
            da.Update(dt);
            con.Close();
        }
    }
}
