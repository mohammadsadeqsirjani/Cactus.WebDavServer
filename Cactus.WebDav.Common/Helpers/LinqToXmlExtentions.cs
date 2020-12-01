using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Cactus.WebDav.Common.Helpers
{
    public static class LinqToXmlExtension
    {
        public static string ToStringWithDeclaration(this XDocument @this)
        {
            if (@this == null)
                throw new ArgumentNullException(nameof(@this));

            return @this.Declaration + Environment.NewLine + @this;
        }

        public static string GetValueOrNull(this XElement element)
        {
            return element?.Value;
        }

        public static XElement LocalNameElement(this XElement @this, string localName)
        {
            return LocalNameElement(@this, localName, StringComparison.Ordinal);
        }

        public static XElement LocalNameElement(this XElement @this, string localName, StringComparison comparisonType)
        {
            return @this.Elements().FirstOrDefault(e => e.Name.LocalName.Equals(localName, comparisonType));
        }

        public static IEnumerable<XElement> LocalNameElements(this XElement @this, string localName)
        {
            return LocalNameElements(@this, localName, StringComparison.Ordinal);
        }

        public static IEnumerable<XElement> LocalNameElements(this XElement @this, string localName,
            StringComparison comparisonType)
        {
            return @this.Elements().Where(e => e.Name.LocalName.Equals(localName, comparisonType));
        }

        public static string GetInnerXml(this XElement @this)
        {
            using var reader = @this.CreateReader();
            reader.MoveToContent();
            return reader.ReadInnerXml();
        }

        public static void SetInnerXml(this XElement @this, string innerXml)
        {
            @this.ReplaceNodes(XElement.Parse("<dummy>" + innerXml + "</dummy>").Nodes());
        }
    }
}
