using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UI_for_Project.Model
{
    static class sqlExamRegister
    {
        public static void deleteItemSelected_KET_QUA_CHAM_THI(string so_bao_danh)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            string delete = string.Format("delete from KET_QUA_CHAM_THI where so_bao_danh = N'{0}'",so_bao_danh);
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
        }
        public static void deleteItemSelected_BAI_THI(string so_bao_danh)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            string delete = string.Format("delete from BAI_THI where so_bao_danh = N'{0}'", so_bao_danh);
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
        }
        public static void deleteItemSelected_GIAY_BAO_THI(string so_bao_danh)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            string delete = string.Format("delete from GIAY_BAO_THI where so_bao_danh = N'{0}'", so_bao_danh);
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
        }
        public static void deleteItemSelected_THI_SINH(string so_bao_danh)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            string delete = string.Format("delete from THI_SINH where so_bao_danh = N'{0}'", so_bao_danh);
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
        }
        public static void deletItemSelectede_PHIEU_DKDT(string ho_ten, string noi_sinh, string dia_chi_bao_tin)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            string delete = string.Format("delete from PHIEU_DKDT where ho_va_ten = N'{0}' and noi_sinh = N'{1}' and dia_chi_bao_tin = N'{2}'", ho_ten,noi_sinh,dia_chi_bao_tin);
            cmd.CommandText = delete;
            cmd.ExecuteNonQuery();
        }
    }
}
