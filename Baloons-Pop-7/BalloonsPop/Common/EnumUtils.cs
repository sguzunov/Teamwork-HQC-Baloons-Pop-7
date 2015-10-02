namespace Balloons.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumUtils
    {
        public static IEnumerable<T> GetEnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
