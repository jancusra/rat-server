namespace Rat.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convert first char of string to lower case
        /// </summary>
        /// <param name="str">input string</param>
        /// <returns>string with first char in lower case</returns>
        public static string FirstCharToLowerCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }
    }
}
