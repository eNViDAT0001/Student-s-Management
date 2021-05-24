using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UI_for_Project.Model
{
    static class DiemChuan
    {
        public static double getDiemChuan(string ma_nganh)
        {
            double a =0;
            string Query = "select * from DIEM_CHUAN";
            string nameTable = "DIEM_CHUAN";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["ma_nganh"] == ma_nganh)
                    a =((double)row["diem_chuan"]);
            }
            return a;
        }

        public static bool Dau_Rot(string so_bao_danh)
        {
            string Query = " select ho_ten, THI_SINH.so_bao_danh,sum(diem_thi) sum_diem_thi , ma_nganh from KET_QUA_CHAM_THI, THI_SINH , PHIEU_DKDT where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh and PHIEU_DKDT.ho_va_ten = THI_SINH.ho_ten group by ho_ten,THI_SINH.so_bao_danh , ma_nganh";
            string nameTable = "DIEM_CHUAN";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                if ((string)row["so_bao_danh"] == so_bao_danh)
                {
                    if ((double)row["sum_diem_thi"] >=  DiemChuan.getDiemChuan((string)row["ma_nganh"]))
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
        public static int sumDau_Rot()
        {
            int i = 0;
            string Query = " select ho_ten, THI_SINH.so_bao_danh,sum(diem_thi) sum_diem_thi , ma_nganh from KET_QUA_CHAM_THI, THI_SINH , PHIEU_DKDT where THI_SINH.so_bao_danh = KET_QUA_CHAM_THI.so_bao_danh and PHIEU_DKDT.ho_va_ten = THI_SINH.ho_ten group by ho_ten,THI_SINH.so_bao_danh , ma_nganh";
            string nameTable = "KET_QUA_CHAM_THI, THI_SINH , PHIEU_DKDT";
            DataTable dt = sqlDataTable.getDataTable(Query, nameTable);

            foreach (DataRow row in dt.Rows)
            {
                if ((double)row["sum_diem_thi"] >= DiemChuan.getDiemChuan((string)row["ma_nganh"]))
                    i++;
            }
            return i;
        }
    }
}
