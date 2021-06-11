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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using UI_for_Project.Controller;
using System.Printing;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using UI_for_Project.Model;

namespace UI_for_Project
{
    /// <summary>
    /// Interaction logic for CandidateList.xaml
    /// </summary>
    public partial class CandidateList : Page
    {

        public CandidateList()
        {
            InitializeComponent();
        }

        //SqlConnection connection;
        //SqlCommand command;
        //string str = @"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();
        private DataGridTextColumn AddColumn(string header, string nameBinding,int width)
        {
            //<DataGridTextColumn Binding="{Binding so_bao_danh }" Header="so_bao_danh" Width="80"/>
            DataGridTextColumn tc = new DataGridTextColumn();
            tc.Header = header;
            tc.Width = width;
            Binding tcBinding = new Binding(nameBinding);
            tc.Binding = tcBinding;
            return tc;
        }

        void setConfirm_to_LoadData()
        {
            // ĐÃ CHẤM HẾT ĐIỂM CHƯA
            if(confirmEditScoring.confirmAllSubject()== true)
            {
                // THÊM DỮ LIỆU VÀO BẢNG KET_QUA_TUYEN_SINH KHI ĐÃ CHẤM ĐIỂM XONG 
                confirmEditScoring.insertKET_QUA_TUYEN_SINH();

                datagridCandidateList.Columns.Add(AddColumn("so_bao_danh", "so_bao_danh", 80));
                datagridCandidateList.Columns.Add(AddColumn("ma_nganh", "ma_nganh", 130));
                datagridCandidateList.Columns.Add(AddColumn("tong_diem", "tong_diem", 120));
                datagridCandidateList.Columns.Add(AddColumn("trung_tuyen", "trung_tuyen", 90));

                string Get_Data = "select * from KET_QUA_TUYEN_SINH";
                string getTable = "KET_QUA_TUYEN_SINH";

                Upload_Data_fromSql_toDataGrid uploadData_candidatalist = new Upload_Data_fromSql_toDataGrid(Get_Data, datagridCandidateList, getTable);
                uploadData_candidatalist.setData();

            }
            else
            {
                // NẾU CHƯA CONFIRM HẾT TÚI CHẤM THI THÌ HIỂN THỊ NHƯ NÀY
                if (confirmEditScoring.confirmAllSubject() == false)
                {
                    datagridCandidateList.Columns.Add(AddColumn("so_bao_danh", "so_bao_danh", 80));
                    datagridCandidateList.Columns.Add(AddColumn("ho_ten", "ho_ten", 130));
                    datagridCandidateList.Columns.Add(AddColumn("ngay_thi", "ngay_thi", 120));
                    datagridCandidateList.Columns.Add(AddColumn("so_phong_thi", "so_phong_thi", 90));
                    datagridCandidateList.Columns.Add(AddColumn("dia_diem_thi", "dia_diem_thi", 200));

                    string Get_Data = "select THI_SINH.so_bao_danh,ho_ten, ngay_thi,so_phong_thi,dia_diem_thi from THI_SINH, GIAY_BAO_THI";
                    string getTable = "THI_SINH,GIAY_BAO_THI";

                    Upload_Data_fromSql_toDataGrid uploadData_candidatalist = new Upload_Data_fromSql_toDataGrid(Get_Data, datagridCandidateList, getTable);
                    uploadData_candidatalist.setData();
                }
                // CÒN CONFIRM HẾT RỒI THÌ HIỂN THỊ NHƯ NÀY 
                else
                {
                   
                }
            }
        }
        void loadData()
        {
            setConfirm_to_LoadData();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            loadData();
        }

        private void txtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            bool selected = false;
            // nhấn enter cái khung serch thì mình sẽ tìm theo tên hoặc theo số báo danh
            if (e.Key == Key.Enter)
            {
                datagridCandidateList.SelectedItems.Clear();

                foreach (DataRowView row in datagridCandidateList.ItemsSource)
                {
                    if (row["so_bao_danh"].Equals(txtBoxSearch.Text))
                    {
                        //datagridCandidateList.SelectedItem = row;
                        //datagridCandidateList.ScrollIntoView(row);
                        //datagridCandidateList.Focus();

                        // chọn tất cả các số báo banh giống với cái đc nhập
                        datagridCandidateList.SelectedItems.Add(row);
                        datagridCandidateList.Focus();
                        selected = true;
                    }
                }

                foreach (DataRowView row in datagridCandidateList.ItemsSource)
                {
                    if (toLowerName(row["ho_ten"].ToString()).Contains(toLowerName(txtBoxSearch.Text)))
                    {
                        //datagridCandidateList.SelectedItem = row;
                        //datagridCandidateList.ScrollIntoView(row);
                        //datagridCandidateList.Focus();

                        // chọn tất cả các tên giống với cái đc nhập
                        datagridCandidateList.SelectedItems.Add(row);
                        datagridCandidateList.Focus();
                        selected = true;
                    }
                }
                // nếu k có cái nào cần tìm thì thông báo k tìm đc
                if (selected == false)
                    MessageBox.Show("There is no item that matches your request.\n\nPlease re - enter.");

            }
        }
        public string toLowerName(string name)
        {
            string[] arrname = name.Split(" ");
            string arrnameLower = "";


            for (int i = 0; i < arrname.Length; i++)
            {
                arrnameLower += arrname[i].ToLower() + " ";
            }

            return arrnameLower.Trim();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            //ExportToExcelAndCsv();

            datagridCandidateList.ExportToExcel(this.ToString());
        }
    }
}
