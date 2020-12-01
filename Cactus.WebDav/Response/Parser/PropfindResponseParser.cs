using Cactus.WebDav.Common.Enums;
using Cactus.WebDav.Common.Helpers;
using Cactus.WebDav.Core.WebDav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebDav.Response.Parser
{
    internal class PropfindResponseParser : IResponseParser<PropFindResponse>
    {
        private readonly LockResponseParser _lockResponseParser;

        public PropfindResponseParser(LockResponseParser lockResponseParser)
        {
            Guard.NotNull(lockResponseParser, "lockResponseParser");

            _lockResponseParser = lockResponseParser;
        }

        public PropFindResponse Parse(string response, int statusCode, string description)
        {
            if (string.IsNullOrEmpty(response))
                return new PropFindResponse(statusCode, description);

            var xResponse = XDocumentExtension.TryParse(response);

            if (xResponse?.Root == null)
                return new PropFindResponse(statusCode, description);

            var resources = xResponse.Root.LocalNameElements("response", StringComparison.OrdinalIgnoreCase)
                .Select(ParseResource)
                .ToList();

            return new PropFindResponse(statusCode, description, resources);
        }

        private WebDavResource ParseResource(XElement xResponse)
        {
            var uriValue = xResponse.LocalNameElement("href", StringComparison.OrdinalIgnoreCase).GetValueOrNull();

            var propStates = MultiStatusParser.GetPropState(xResponse);

            return CreateResource(uriValue, propStates);
        }

        private WebDavResource CreateResource(string uri, List<MultiStatusParser.PropState> propState)
        {
            var properties = MultiStatusParser.GetProperties(propState);

            var resourceBuilder = new WebDavResource.Builder()
                .WithActiveLocks(_lockResponseParser.ParseLockDiscovery(FindProperty("{DAV:}lockdiscovery", properties)))
                .WithContentLanguage(PropertyValueParser.ParseString(FindProperty("{DAV:}getcontentlanguage", properties)))
                .WithContentLength(PropertyValueParser.ParseLong(FindProperty("{DAV:}getcontentlength", properties)))
                .WithContentType(PropertyValueParser.ParseString(FindProperty("{DAV:}getcontenttype", properties)))
                .WithCreationDate(PropertyValueParser.ParseDateTime(FindProperty("{DAV:}creationdate", properties)))
                .WithDisplayName(PropertyValueParser.ParseString(FindProperty("{DAV:}displayname", properties)))
                .WithETag(PropertyValueParser.ParseString(FindProperty("{DAV:}getetag", properties)))
                .WithLastModifiedDate(PropertyValueParser.ParseDateTime(FindProperty("{DAV:}getlastmodified", properties)))
                .WithProperties(properties.Select(x => new WebDavProperty(x.Name, x.GetInnerXml())).ToList())
                .WithPropertyStatuses(MultiStatusParser.GetPropertyStatuses(propState));

            var isHidden = PropertyValueParser.ParseInteger(FindProperty("{DAV:}ishidden", properties)) > 0;

            if (isHidden) resourceBuilder.IsHidden();

            var isCollection = PropertyValueParser.ParseInteger(FindProperty("{DAV:}iscollection", properties)) > 0 ||
                PropertyValueParser.ParseResourceType(FindProperty("{DAV:}resourcetype", properties)) == ResourceType.Collection;

            if (isCollection)
            {
                resourceBuilder.IsCollection();
                resourceBuilder.WithUri(uri.TrimEnd('/') + "/");
            }
            else
            {
                resourceBuilder.WithUri(uri);
            }

            return resourceBuilder.Build();
        }

        private static XElement FindProperty(XName name, IEnumerable<XElement> properties) => properties.FirstOrDefault(x => x.Name.Equals(name));
    }
}
