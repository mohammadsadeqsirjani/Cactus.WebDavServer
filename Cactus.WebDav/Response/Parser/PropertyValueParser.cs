using System;
using System.Xml.Linq;
using Cactus.WebDav.Common;
using Cactus.WebDav.Common.Abstractions;
using Cactus.WebDav.Common.Enums;
using Cactus.WebDav.Common.Helpers;
using Cactus.WebDav.Core;

namespace WebDav.Response.Parser
{
    internal static class PropertyValueParser
    {
        public static string ParseString(XElement element) => element?.Value;

        public static int? ParseInteger(XElement element)
        {
            if (element == null) return null;

            return int.TryParse(element.Value, out var value) ? (int?)value : null;
        }

        public static long? ParseLong(XElement element)
        {
            if (element == null) return null;

            return long.TryParse(element.Value, out var value) ? (long?)value : null;
        }

        public static DateTime? ParseDateTime(XElement element)
        {
            if (element == null) return null;

            return DateTime.TryParse(element.Value, out var value) ? (DateTime?)value : null;
        }

        public static ResourceType ParseResourceType(XElement element)
        {
            if (element == null) return ResourceType.Other;

            return element.LocalNameElement("collection") != null
                ? ResourceType.Collection
                : ResourceType.Other;
        }

        public static LockScope? ParseLockScope(XElement element)
        {
            if (element == null) return null;

            if (element.LocalNameElement("shared", StringComparison.OrdinalIgnoreCase) != null)
                return LockScope.Shared;

            if (element.LocalNameElement("exclusive", StringComparison.OrdinalIgnoreCase) != null)
                return LockScope.Exclusive;

            return null;
        }

        public static ApplyTo.Lock? ParseLockDepth(XElement element)
        {
            if (element == null) return null;

            return element.Value.Equals("0") ? ApplyTo.Lock.ResourceOnly : ApplyTo.Lock.ResourceAndAncestors;
        }

        public static LockOwner ParseOwner(XElement element)
        {
            if (element == null) return null;

            var uri = element.LocalNameElement("href", StringComparison.OrdinalIgnoreCase);
            if (uri != null && Uri.IsWellFormedUriString(uri.Value, UriKind.Absolute))
                return new UriLockOwner(uri.Value);

            return !string.IsNullOrEmpty(element.Value) ? new PrincipalLockOwner(element.Value) : null;
        }

        public static TimeSpan? ParseLockTimeout(XElement element)
        {
            if (element == null) return null;

            var value = element.Value;

            if (value.Equals("infinity", StringComparison.OrdinalIgnoreCase))
                return null;

            if (!value.StartsWith("Second-", StringComparison.OrdinalIgnoreCase)) return null;

            if (int.TryParse(value.Substring(value.IndexOf("-", StringComparison.Ordinal) + 1), out var seconds))
                return TimeSpan.FromSeconds(seconds);

            return null;
        }
    }
}
