namespace MSMQHealthCheck.Extensions
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            return char.ToLower(str[0]) + str.Substring(1);
        }
    }
}