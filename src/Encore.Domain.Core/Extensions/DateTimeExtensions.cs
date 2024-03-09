namespace Encore.Domain.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToEpoch(this DateTime dateTime)
        {
            DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime.ToUniversalTime() - epochStart).TotalSeconds;
        }
    }
}
