using System;
using Cactus.WebDav.Common.Enums;

namespace Cactus.WebDav.Common.Helpers
{
    public static class DepthHeaderHelper
    {
        public static string GetValueForPropfind(ApplyTo.Propfind applyTo)
        {
            return applyTo switch
            {
                ApplyTo.Propfind.ResourceOnly => "0",
                ApplyTo.Propfind.ResourceAndChildren => "1",
                ApplyTo.Propfind.ResourceAndAncestors => "infinity",
                _ => throw new ArgumentOutOfRangeException(nameof(applyTo))
            };
        }

        public static string GetValueForCopy(ApplyTo.Copy applyTo)
        {
            return applyTo switch
            {
                ApplyTo.Copy.ResourceOnly => "0",
                ApplyTo.Copy.ResourceAndAncestors => "infinity",
                _ => throw new ArgumentOutOfRangeException(nameof(applyTo))
            };
        }

        public static string GetValueForLock(ApplyTo.Lock applyTo)
        {
            return applyTo switch
            {
                ApplyTo.Lock.ResourceOnly => "0",
                ApplyTo.Lock.ResourceAndAncestors => "infinity",
                _ => throw new ArgumentOutOfRangeException(nameof(applyTo))
            };
        }
    }
}
