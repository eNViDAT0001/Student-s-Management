using System;
using System.Collections.Generic;
using System.Text;

namespace UI_for_Project.Controller
{
    static class getNumber_TuongUng_Subject
    {
        public static int getNumber(string subject)
        {
            int a = -1;
            switch (subject)
            {
                case "Toán":
                    a = 1;
                    break;
                case "Ngữ Văn":
                    a = 2;
                    break;
                case "Anh Văn":
                    a = 3;
                    break;
                case "Vật Lý":
                    a = 4;
                    break;
                case "Hóa Học":
                    a = 5;
                    break;
                case "Sinh Học":
                    a = 6;
                    break;
                case "Lịch Sử":
                    a = 7;
                    break;
                case "Địa Lý":
                    a = 8;
                    break;
                case "GDCD":
                    a = 9;
                    break;
            }
            return a;
        }
    }
}
