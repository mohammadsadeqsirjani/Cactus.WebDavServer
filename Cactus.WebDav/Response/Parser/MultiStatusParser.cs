using Cactus.WebDav.Core.WebDav;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Cactus.WebDav.Common.Helpers;

namespace WebDav.Response.Parser
{
    internal static class MultiStatusParser
    {
        private static readonly Regex StatusCodeRegex = new Regex(@".*(\d{3}).*");

        public static List<PropState> GetPropState(XElement xResponse)
        {
            return xResponse.LocalNameElements("propstat", StringComparison.OrdinalIgnoreCase)
                .Select(x =>
                    new PropState
                    {
                        Element = x,
                        StatusCode = GetStatusCodeFromPropState(x),
                        Description = GetDescriptionFromPropState(x)
                    })
                .ToList();
        }

        public static List<WebDavPropertyStatus> GetPropertyStatuses(XElement response)
        {
            var propStates = GetPropState(response);

            return GetPropertyStatuses(propStates);
        }

        public static List<WebDavPropertyStatus> GetPropertyStatuses(List<PropState> propStates)
        {
            return propStates
                .SelectMany(x => x.Element.LocalNameElements("prop", StringComparison.OrdinalIgnoreCase)
                    .SelectMany(p => p.Elements())
                    .Select(p => new { Prop = p, x.StatusCode, x.Description }))
                .Select(x => new WebDavPropertyStatus(x.Prop.Name, x.StatusCode, x.Description))
                .ToList();
        }

        public static List<XElement> GetProperties(List<PropState> propStates)
        {
            return propStates
                .Where(x => IsSuccessStatusCode(x.StatusCode))
                .SelectMany(x => x.Element.LocalNameElements("prop", StringComparison.OrdinalIgnoreCase))
                .SelectMany(x => x.Elements())
                .ToList();
        }

        private static bool IsSuccessStatusCode(int statusCode)
        {
            return statusCode >= 200 && statusCode <= 299;
        }

        private static string GetDescriptionFromPropState(XElement propState)
        {
            return
                propState.LocalNameElement("responsedescription", StringComparison.OrdinalIgnoreCase).GetValueOrNull() ??
                propState.LocalNameElement("status", StringComparison.OrdinalIgnoreCase).GetValueOrNull();
        }

        private static int GetStatusCodeFromPropState(XElement propState)
        {
            var statusRawValue = propState.LocalNameElement("status", StringComparison.OrdinalIgnoreCase).GetValueOrNull();

            if (string.IsNullOrEmpty(statusRawValue)) return default;

            var statusCodeGroup = StatusCodeRegex.Match(statusRawValue).Groups[1];

            if (!statusCodeGroup.Success) return default;

            return !int.TryParse(statusCodeGroup.Value, out var statusCode) ? default : statusCode;
        }

        internal class PropState
        {
            public XElement Element { get; set; }

            public int StatusCode { get; set; }

            public string Description { get; set; }
        }
    }
}
