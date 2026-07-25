using System;
using System.Globalization;

namespace Core
{
    public static class ExpiryDateUtils
    {
        private static readonly CultureInfo English = new("en-US");

        public static string FormatExpiration(DateTime expiryDate)
            => $"EXP: {ToShortString(expiryDate)}";

        public static string ToLongString(DateTime dateTime)
            => dateTime.ToString("HH:00 MMMM dd yyyy", English);

        public static string ToShortString(DateTime dateTime)
            => dateTime.ToString("dd MMM yy", English).ToUpperInvariant();
    }
}