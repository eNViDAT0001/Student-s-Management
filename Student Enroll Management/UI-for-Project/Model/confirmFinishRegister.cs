using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace UI_for_Project.Model
{
    static class confirmFinishRegister
    {
        public static bool getConfirm()
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            try
            {
                con.Open();
            }
            catch
            {
                string Message = "SQL Connection failed.";
                string Title = "Error";
                MessageBox.Show(Message, Title);
                
            }
            SqlCommand cmd = con.CreateCommand();
            string Query = "select * from CONFIRM_REGISTER";
            cmd.CommandText = Query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("CONFIRM_REGISTER");
            da.Fill(dt);

            string name = "";
            foreach (DataRow row in dt.Rows)
            {
                name = (string)row["confirm"];
            }
            if (name == "false")
                return false;
            else if (name == "true")
                return true;

            return false;
            
        }
    }
}
