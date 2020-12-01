using Cactus.WebDav.Core;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Request.Builder
{
    internal static class PropPatchRequestBuilder
    {
        public static string BuildRequestBody(IDictionary<XName, string> propertiesToSet,
            IReadOnlyCollection<XName> propertiesToRemove,
            IReadOnlyCollection<NamespaceAttribute> namespaces)
        {
            var document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var propertyUpdate = new XElement("{DAV:}propertypdate", new XAttribute(XNamespace.Xmlns + "D", "DAV:"));

            foreach (var @namespace in namespaces)
            {
                var namespaceAttr = string.IsNullOrEmpty(@namespace.Prefix)
                    ? "xmlns"
                    : XNamespace.Xmlns + @namespace.Prefix;
                propertyUpdate.SetAttributeValue(namespaceAttr, @namespace.Namespace);
            }

            if (propertiesToSet.Any())
            {
                var content = new XElement("{DAV:}set");
                var propElement = new XElement("{DAV:}prop");

                foreach (var (key, value) in propertiesToSet)
                {
                    var element = new XElement(key);

                    element.SetInnerXml(value);

                    propElement.Add(element);
                }

                content.Add(propElement);
                propertyUpdate.Add(content);
            }

            if (propertiesToRemove.Any())
            {
                var content = new XElement("{DAV:}remove");
                var propElement = new XElement("{DAV:}prop");

                foreach (var prop in propertiesToRemove) propElement.Add(new XElement(prop));

                content.Add(propElement);
                propertyUpdate.Add(content);
            }

            document.Add(propertyUpdate);

            return document.ToStringWithDeclaration();
        }
    }
}
