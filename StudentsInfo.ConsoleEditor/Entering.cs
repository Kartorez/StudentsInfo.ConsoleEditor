using System;

namespace StudentsInfo
{
    public static class Entering
    {
        public static string format = "{0,40}: ";

        public static int EnterInt32(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            int value = int.Parse(s);
            return value;
        }

        public static string EnterString(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return s.Trim();
        }

        public static string EnterStringOrNull(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            s = s.Trim();
            return s == "" ? null : s;
        }
        public static DateTime EnterDate(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            DateTime value = DateTime.Parse(s);
            return value;
        }
        public static double? EnterNullableDouble(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return (s == "") ? (double?)null : Convert.ToDouble(s);
        }

        public static decimal? EnterNullableDecimal(string prompt)
        {
            Console.Write(format, prompt);
            string s = Console.ReadLine();
            return (s == "") ? (decimal?)null : Convert.ToDecimal(s);
        }
    }
}
