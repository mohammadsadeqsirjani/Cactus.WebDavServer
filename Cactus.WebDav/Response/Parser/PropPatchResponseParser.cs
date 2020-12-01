using System;
using System.Linq;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Response.Parser
{
    internal class PropPatchResponseParser : IResponseParser<PropPatchResponse>
    {
        public PropPatchResponse Parse(string response, int statusCode, string description)
        {
            if (string.IsNullOrEmpty(response))
                return new PropPatchResponse(statusCode, description);

            var xResponse = XDocumentExtension.TryParse(response);

            if (xResponse?.Root == null)
                return new PropPatchResponse(statusCode, description);

            var propStatuses = xResponse.Root.LocalNameElements("response", StringComparison.OrdinalIgnoreCase)
                .SelectMany(MultiStatusParser.GetPropertyStatuses)
                .ToList();

            return new PropPatchResponse(statusCode, description, propStatuses);
        }
    }
}
