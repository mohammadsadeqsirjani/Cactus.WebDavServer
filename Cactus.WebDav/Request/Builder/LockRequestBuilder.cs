using Cactus.WebDav.Common;
using Cactus.WebDav.Common.Enums;
using Cactus.WebDav.Core;
using System;
using System.Xml.Linq;
using Cactus.WebDav.Common.Abstractions;
using Cactus.WebDav.Common.Helpers;
using WebDav.Request.Parameters;

namespace WebDav.Request.Builder
{
    internal static class LockRequestBuilder
    {
        public static string BuildRequestBody(LockParameters lockParams)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var lockInfo = new XElement("{DAV:}lockinfo", new XAttribute(XNamespace.Xmlns + "D", "DAV:"));

            lockInfo.Add(GetLockScope(lockParams.LockScope));
            lockInfo.Add(GetLockType());

            if (lockParams.Owner != null)
                lockInfo.Add(GetLockOwner(lockParams.Owner));

            document.Add(lockInfo);

            return document.ToStringWithDeclaration();
        }

        private static XElement GetLockScope(LockScope lockScope)
        {
            var scope = new XElement("{DAV:}lockscope");

            switch (lockScope)
            {
                case LockScope.Shared:
                    scope.Add(new XElement("{DAV:}shared"));
                    break;
                case LockScope.Exclusive:
                    scope.Add(new XElement("{DAV:}exclusive"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lockScope));
            }

            return scope;
        }

        private static XElement GetLockType()
        {
            var lockType = new XElement("{DAV:}locktype");

            lockType.Add(new XElement("{DAV:}write"));

            return lockType;
        }

        private static XElement GetLockOwner(LockOwner lockOwner)
        {
            var owner = new XElement("{DAV:}owner");

            switch (lockOwner)
            {
                case PrincipalLockOwner:
                    owner.SetValue(lockOwner.Value);
                    break;
                case UriLockOwner:
                    {
                        var uri = new XElement("{DAV:}href");
                        uri.SetValue(lockOwner.Value);
                        owner.Add(uri);
                        break;
                    }
                default:
                    throw new ArgumentException("Lock owner is invalid.", nameof(lockOwner));
            }

            return owner;
        }
    }
}
