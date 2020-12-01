using Cactus.WebDav.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Response.Parser
{
    internal class LockResponseParser : IResponseParser<LockResponse>
    {
        public LockResponse Parse(string response, int statusCode, string description)
        {
            var xResponse = XDocumentExtension.TryParse(response);

            if (xResponse?.Root == null)
                return new LockResponse(statusCode, description);

            var lockDiscovery = xResponse.Root.LocalNameElement("lockdiscovery", StringComparison.OrdinalIgnoreCase);
            var activeLocks = ParseLockDiscovery(lockDiscovery);

            return new LockResponse(statusCode, description, activeLocks);
        }

        public List<ActiveLock> ParseLockDiscovery(XElement lockDiscovery)
        {
            if (lockDiscovery == null)
                return new List<ActiveLock>();

            return lockDiscovery
                .LocalNameElements("activelock", StringComparison.OrdinalIgnoreCase)
                .Select(x => CreateActiveLock(x.Elements().ToList()))
                .ToList();
        }

        private static ActiveLock CreateActiveLock(IReadOnlyCollection<XElement> properties)
        {
            var activeLock =
                new ActiveLock.Builder()
                    .WithApplyTo(PropertyValueParser.ParseLockDepth(FindProp("depth", properties)))
                    .WithLockScope(PropertyValueParser.ParseLockScope(FindProp("lockscope", properties)))
                    .WithLockToken(PropertyValueParser.ParseString(FindProp("locktoken", properties)))
                    .WithOwner(PropertyValueParser.ParseOwner(FindProp("owner", properties)))
                    .WithLockRoot(PropertyValueParser.ParseString(FindProp("lockroot", properties)))
                    .WithTimeout(PropertyValueParser.ParseLockTimeout(FindProp("timeout", properties)))
                    .Build();

            return activeLock;
        }

        private static XElement FindProp(string localName, IEnumerable<XElement> properties) =>
            properties.FirstOrDefault(
                x => x.Name.LocalName.Equals(localName, StringComparison.OrdinalIgnoreCase));
    }
}
