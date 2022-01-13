using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.UI.Extensions
{
    public static class StringExtension
    {
        public static bool IsNumber(this string str)
        {
            if (str == String.Empty)
            {
                return false;
            }
            else if (Int32.TryParse(str, out int num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static (bool isNumber, int number) IsNumberInRange(this string str, int from, int to)
        {
            if (str.IsNumber())
            {
                str = str.TrimStart();
                str = str.TrimEnd();
                var number = int.Parse(str);
                if (number >= from && number <= to)
                {
                    return (true, int.Parse(str));
                }
                else
                {
                    return (false, 0);
                }
            }
            else
            {
                return (false, 0);
            }
        }
    }
}
