using System;
using System.Collections.Generic;
using System.Linq;

namespace Rat.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static Dictionary<int, string> GetEnumDictionary<TEnum>() where TEnum : struct
        {
            if (typeof(TEnum).IsEnum)
            {
                var enumValues = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                                 select enumValue;

                return enumValues.Cast<TEnum>()
                    .ToDictionary(ev => Convert.ToInt32(ev), ev => ev.ToString());
            }

            return new Dictionary<int, string>();
        }

        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = false)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value, ignoreCase);
        }
    }
}
