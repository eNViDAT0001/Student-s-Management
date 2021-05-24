using System;
using System.Collections.Generic;
using System.Text;

namespace UI_for_Project.Controller
{
    static class static_confirmPerson
    {
        // LƯU Ý : CHỈ CÓ 3 PERSON ADMIN, USER, NONE

        private static string Person;
        public static void setPerson(string person)
        {
            Person = person;
        }
        public static string getPerson()
        {
            return Person;
        }
    }
}
