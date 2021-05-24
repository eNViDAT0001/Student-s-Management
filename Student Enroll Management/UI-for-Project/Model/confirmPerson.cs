using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UI_for_Project.Model
{
    static class confirmPerson
    {

        // ADMIN, USER, NONE
        public static string getPersonPermission()
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            string Query = "select * from System_Login";
            cmd.CommandText = Query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("System_Login");
            da.Fill(dt);

            string name="";
            foreach (DataRow row in dt.Rows)
            {
                 name = (string)row["permission"];
            }
            return name;
        }
        public static void setPersonPermission(string person)
        {
            SqlConnection con = new SqlConnection(sqlConnection.CONNECTION);
            //con.ConnectionString = ConfigurationManager.ConnectionStrings[@"Data Source=PCHIEU\SQLEXPRESS;Initial Catalog=QLTuyenSinh;Integrated Security=True"].ConnectionString;
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            string Query = string .Format("update System_Login set permission='{0}' ",person);
            cmd.CommandText = Query;
            cmd.ExecuteNonQuery();

        }
    }
}
