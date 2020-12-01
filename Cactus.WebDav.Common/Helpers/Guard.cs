using System;

namespace Cactus.WebDav.Common.Helpers
{
    public static class Guard
    {
        public static void NotNull(object @this, string parameter)
        {
            if (@this == null)
                throw new ArgumentNullException(parameter);
        }

        public static void NotNullOrEmpty(string @this, string parameter)
        {
            if (string.IsNullOrEmpty(@this))
                throw new ArgumentNullException(parameter);
        }
    }
}
