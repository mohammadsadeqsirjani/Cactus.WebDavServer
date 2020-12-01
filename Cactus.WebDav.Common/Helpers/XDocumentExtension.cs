using System.Xml.Linq;

namespace Cactus.WebDav.Common.Helpers
{
    public static class XDocumentExtension
    {
        public static XDocument TryParse(string text)
        {
            try
            {
                return XDocument.Parse(text);
            }
            catch
            {
                return null;
            }
        }
    }
}
