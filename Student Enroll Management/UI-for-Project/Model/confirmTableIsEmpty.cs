using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace UI_for_Project.Model
{
    static class confirmTableIsEmpty
    {
        public static bool getBool(string nameTable)
        {
            int a = 3;

            string Query = string.Format("select count(*) count from {0}", nameTable);
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);
            foreach (DataRow row in dt.Rows)
            {
                a = (int)row["count"];
            }
            if (a == 0)
                return true;
            return false;
        }
    }
}
