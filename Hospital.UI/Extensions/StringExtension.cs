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
    }
}
