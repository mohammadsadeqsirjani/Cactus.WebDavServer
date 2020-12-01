using Cactus.WebDav.Core;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Request.Builder
{
    internal static class PropfindRequestBuilder
    {
        public static string BuildRequest(
            PropfindRequestType requestType,
            IReadOnlyCollection<XName> customProperties,
            IReadOnlyCollection<NamespaceAttribute> namespaces)
        {
            return requestType == PropfindRequestType.NamedProperties
                ? BuildNamedPropRequest(customProperties, namespaces)
                : BuildAllPropRequest(customProperties, namespaces);
        }

        private static string BuildAllPropRequest(IReadOnlyCollection<XName> customProperties,
            IEnumerable<NamespaceAttribute> namespaces)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var propfind = new XElement("{DAV:}propfind", new XAttribute(XNamespace.Xmlns + "D", "DAV:"));

            propfind.Add(new XElement("{DAV:}allprop"));

            if (customProperties.Any())
            {
                var include = new XElement("{DAV:}include");

                foreach (var @namespace in namespaces)
                {
                    var namespaceAttr = string.IsNullOrEmpty(@namespace.Prefix)
                        ? "xmlns"
                        : XNamespace.Xmlns + @namespace.Prefix;

                    include.SetAttributeValue(namespaceAttr, @namespace.Namespace);
                }

                foreach (var property in customProperties) include.Add(new XElement(property));

                propfind.Add(include);
            }

            document.Add(propfind);

            return document.ToStringWithDeclaration();
        }

        private static string BuildNamedPropRequest(IReadOnlyCollection<XName> customProperties,
            IEnumerable<NamespaceAttribute> namespaces)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var propfind = new XElement("{DAV:}propfind", new XAttribute(XNamespace.Xmlns + "D", "DAV:"));

            if (customProperties.Any())
            {
                var propertyElement = new XElement("{DAV:}prop");

                foreach (var @namespace in namespaces)
                {
                    var namespaceAttr = string.IsNullOrEmpty(@namespace.Prefix)
                        ? "xmlns"
                        : XNamespace.Xmlns + @namespace.Prefix;

                    propertyElement.SetAttributeValue(namespaceAttr, @namespace.Namespace);
                }

                foreach (var property in customProperties) propertyElement.Add(new XElement(property));

                propfind.Add(propertyElement);
            }

            document.Add(propfind);

            return document.ToStringWithDeclaration();
        }
    }
}
