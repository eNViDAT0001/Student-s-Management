using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UI_for_Project.Model;

namespace UI_for_Project.Controller
{
    static class getNumberOfSubject
    {
        public static string getNumberOfSubject_sql(string Subject)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            // câu lệnh cần thực hiện
            //string Get_Data = "select THI_SINH.so_bao_danh,ho_ten, ngay_thi,so_phong_thi,dia_diem_thi from THI_SINH, GIAY_BAO_THI";

            SqlCommand cmd = con.CreateCommand();
            string Query = "select ten_mon, count(TUI_CHAM_THI.ma_tui) count_tuichamthi from BAI_THI, TUI_CHAM_THI, MON_THI where TUI_CHAM_THI.ma_mon = MON_THI.ma_mon and BAI_THI.ma_tui = TUI_CHAM_THI.ma_tui group by ten_mon";
            

            cmd.CommandText = Query;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("BAI_THI, TUI_CHAM_THI, MON_THI");
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["ten_mon"] == Subject)
                {
                    //MessageBox.Show(Convert.ToString(row["count_tuichamthi"]));
                   
                    return Convert.ToString(row["count_tuichamthi"]);
                }
            }
            return "0";

        }
    }
}
