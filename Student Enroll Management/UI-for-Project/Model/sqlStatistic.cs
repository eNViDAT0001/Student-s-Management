using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using UI_for_Project.Controller;

namespace UI_for_Project.Model
{

    // CÓ CÁC CÂU LỆNH LIÊN QUAN ĐỂ SỬ DỤNG TRONG GIAO DIỆN STATISTIC
    static class sqlStatistic
    {
        public static string number_Candidate()
        {
            string a = "0";
            string Query = "select count(ho_ten) count_ho_ten from THI_SINH";
            string nameTable = "THI_SINH";

            DataTable dt= sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = ((int)row["count_ho_ten"]).ToString();
            }
            return a;
        }
        public static string number_Candidate_Elect()
        {
            string a = "0";


            return a;
        }
        //tỉ lệ trúng tuyển
        public static string Matriculation_Rate()
        {
            string a = "0";


            return a;
        }

        public static string Name_MaxPoint_Subject(string subject)
        {
            string a = "0";
            int numberSubject = getNumber_TuongUng_Subject.getNumber(subject);
            string Query = string.Format(" select top 1 ho_ten, THI_SINH.so_bao_danh,diem_thi , ma_mon from KET_QUA_CHAM_THI, THI_SINH where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh and ma_mon = '{0}' order by diem_thi desc", numberSubject);
            string nameTable = "KET_QUA_CHAM_THI, THI_SINH";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = ((string)row["ho_ten"]).ToString();
            }
            return a;
        }
        public static string Point_MaxPoint_Subject(string subject)
        {
            string a = "0";
            int numberSubject = getNumber_TuongUng_Subject.getNumber(subject);
            string Query =string.Format( " select top 1 ho_ten, THI_SINH.so_bao_danh,diem_thi , ma_mon from KET_QUA_CHAM_THI, THI_SINH where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh and ma_mon = '{0}' order by diem_thi desc",numberSubject);
            string nameTable = "KET_QUA_CHAM_THI, THI_SINH";

            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = ((double)row["diem_thi"]).ToString();
            }
            return a;
        }
        public static string Name_MaxPoint()
        {
            string a = "0";
            string Query = "select top 1 ho_ten, THI_SINH.so_bao_danh,sum(diem_thi) sum_diem_thi from KET_QUA_CHAM_THI, THI_SINH where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh group by ho_ten,THI_SINH.so_bao_danh order by sum(diem_thi) desc";
            string nameTable = "KET_QUA_CHAM_THI, THI_SINH";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a = (string)row["ho_ten"];
            }
            return a;
        }

        public static string Point_MaxPoint()
        {
            string a = "0";
            string Query = "select top 1 ho_ten, THI_SINH.so_bao_danh,sum(diem_thi) sum_diem_thi from KET_QUA_CHAM_THI, THI_SINH where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh group by ho_ten,THI_SINH.so_bao_danh order by sum(diem_thi) desc";
            string nameTable = "KET_QUA_CHAM_THI, THI_SINH";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                a =( (double)row["sum_diem_thi"]).ToString();
            }
            return a;
        }


    }
}
