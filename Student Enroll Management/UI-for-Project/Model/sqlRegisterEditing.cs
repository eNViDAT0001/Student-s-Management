using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UI_for_Project.Model
{
    static class sqlRegisterEditing
    {
        // LẤY SỐ PHÁCH TỪ BÀI THI ( 3 SỐ PHÁCH) TƯƠNG ỨNG ĐỂ ĐIỀN VÀO KET_QUA_CHAM_THI
        public static int getSoPhach_from_BAI_THI(string so_bao_danh, int ma_mon)
        {
            int so_phach = 0;
            string Query = "select * from BAI_THI";
            string nameTable = "BAI_THI";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                string ma_tui = "T00" + ma_mon;
                if ((string)row["so_bao_danh"] == so_bao_danh && (string)row["ma_tui"] == ma_tui)
                    so_phach = (int)row["so_phach"];
            }
            return so_phach;
        }
        // TẠO SỐ PHIẾU MỚI BẰNG CÁCH LÁY SỐ PHIẾU CUỐI CỘNG CHO 1
        public static string getNumber_Last_SoPhieu()
        {
            string a = "";
            string Query = "select * from PHIEU_DKDT";
            string nameTable = "THI_SINH";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = (string)row["so_phieu"];
            }
            string b = "";
            for (int i = 2; i < a.Length; i++)
            {
                b += a[i];
            }
            int ia = int.Parse(b) + 1;

            return "DK" + ia;
        }

        public static string getNumber_Last_So_Bao_Danh()
        {
            int a = 0;
            string Query = "select * from THI_SINH";
            string nameTable = "THI_SINH";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a =int.Parse( (string)row["so_bao_danh"]);
            }
            return (a + 1).ToString();
        }
        public static int getNumber_Last_So_Phach()
        {
            int a = 0;
            string Query = "select * from BAI_THI";
            string nameTable = "BAI_THI";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = (int)row["so_phach"];
            }
            return (a + 1);
        }
        public static string getKhoi_Thi(string khoi_thi)
        {
            string a = "";
            switch (khoi_thi)
            {
                case "A00":
                    a = "1 4 5";
                    break;
                case "A01":
                    a = "1 3 4";
                    break;
                case "D01":
                    a = "1 2 3";
                    break;
                case "D07":
                    a = "1 3 5";
                    break;
                case "C20":
                    a = "2 8 9";
                    break;
                case "C12":
                    a = "2 6 7";
                    break;

            }
            return a;
        }
    }
}
