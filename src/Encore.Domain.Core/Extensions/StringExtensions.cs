namespace Encore.Domain.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str) {  return str.ToCamelCase(); }
        public static string ToLowerTrim(this string str) { return str.ToLower().Trim(); }
    }
}
