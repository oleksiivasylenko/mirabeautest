using System;

namespace Airports.Base.Extensions
{
    public static class EnumExtension
    {
        public static T ToEnum<T>(this string value, T defaultValue) where T  : struct
        {
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;

            return Enum.TryParse(value, true, out T result) ? result : defaultValue;
        }
    }
}
