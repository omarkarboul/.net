using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Services
{
    public static class StrExtension
    {
        public static void UpperCase(this string s)
        {
            Console.WriteLine(char.ToUpper(s[0]) + s.Substring(1));
        }
    }
}
