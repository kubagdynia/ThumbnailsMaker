using System;
using System.Linq;

namespace ThumbnailsMaker
{
    static class PrimitiveTypes
    {
        private static readonly Type[] Types;

        static PrimitiveTypes()
        {
            Type[] types =
            {
                typeof(Enum),
                typeof(String),
                typeof(Char),
                typeof(Guid),

                typeof(Boolean),
                typeof(Byte),
                typeof(Int16),
                typeof(Int32),
                typeof(Int64),
                typeof(Single),
                typeof(Double),
                typeof(Decimal),

                typeof(SByte),
                typeof(UInt16),
                typeof(UInt32),
                typeof(UInt64),

                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
            };

            var nullTypes =
                types.Where(t => t.IsValueType).Select(t => typeof(Nullable<>).MakeGenericType(t));

            Types = types.Concat(nullTypes).ToArray();
        }

        public static bool Test(Type type)
        {
            if (Types.Any(x => x.IsAssignableFrom(type)))
            {
                return true;
            }

            var nut = Nullable.GetUnderlyingType(type);
            return nut != null && nut.IsEnum;
        }
    }
}