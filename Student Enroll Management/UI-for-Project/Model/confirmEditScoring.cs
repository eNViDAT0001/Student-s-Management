using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UI_for_Project.Model
{
    static class confirmEditScoring
    {
        public static bool Diem_Nhap_Het_Chua(int ma_mon)
        {
            string Query = string.Format("select so_phach, diem_thi,ma_mon from KET_QUA_CHAM_THI where ma_mon ={0}", ma_mon);
            string nameTable = "KET_QUA_CHAM_THI";
            DataTable dt= sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                if ((double)row["diem_thi"] == 0)
                    return false;
            }
            return true;
        }
        public static bool confirmed(int ma_mon)
        {
            bool a = false;
            string Query = "select * from confirmTui_Cham_Thi";
            string nameTable = "confirmTui_Cham_Thi";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);
            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["ma_mon"] == ma_mon)
                {
                    if ((string)row["confirm"] == "true" || (string)row["confirm"] == "True")
                        a= true;
                    else
                        a= false;
                }
            }
            return a;
        }
        public static void confirmSubject(int ma_mon, bool confirm)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            // câu lệnh cần thực hiện
            //string Get_Data = "select THI_SINH.so_bao_danh,ho_ten, ngay_thi,so_phong_thi,dia_diem_thi from THI_SINH, GIAY_BAO_THI";

            SqlCommand cmd = con.CreateCommand();
            string Query = "select * from confirmTui_Cham_Thi";

            cmd.CommandText = Query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("confirmTui_Cham_Thi");
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["ma_mon"] == ma_mon)
                {

                    string update = string.Format("update confirmTui_Cham_Thi set confirm='{0}' where ma_mon ={1}", confirm, ma_mon);
                    cmd.CommandText = update;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool confirmAllSubject()
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            string Query = "select * from confirmTui_Cham_Thi";



            cmd.CommandText = Query;


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("confirmTui_Cham_Thi");
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["confirm"] == "false" || (string)row["confirm"] == "False")
                {
                    return false;
                }
            }
            return true;
        }

        public static void insertKET_QUA_TUYEN_SINH()
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            string Query = "select THI_SINH.so_bao_danh,sum(diem_thi) sum_diem_thi , ma_nganh from KET_QUA_CHAM_THI, THI_SINH , PHIEU_DKDT where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh and PHIEU_DKDT.ho_va_ten = THI_SINH.ho_ten group by THI_SINH.so_bao_danh , ma_nganh order by sum(diem_thi) desc";

            cmd.CommandText = Query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("KET_QUA_CHAM_THI, THI_SINH , PHIEU_DKDT");
            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                string so_bao_danh = (string)row["so_bao_danh"];
                string ma_nganh = (string)row["ma_nganh"];
                double sum_diem_thi = (double)row["sum_diem_thi"];
                string confirm_DAU_ROT="";
                if (DiemChuan.Dau_Rot(so_bao_danh) == true)
                    confirm_DAU_ROT = "ĐẬU";
                else
                    confirm_DAU_ROT = "RỚT";

                string INSERT = string.Format("insert into KET_QUA_TUYEN_SINH values ('{0}','{1}',{2},'{3}')", so_bao_danh, ma_nganh, sum_diem_thi, confirm_DAU_ROT);

                cmd.CommandText = INSERT;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
