using System.Net.Http.Headers;
using System.Text;

namespace Cactus.WebDav.Core
{
    public static class MediaTypes
    {
        public static readonly MediaTypeHeaderValue XmlMediaType = new MediaTypeHeaderValue("application/xml")
        {
            CharSet = Encoding.UTF8.WebName
        };

        public static readonly MediaTypeHeaderValue BinaryDataMediaType = new MediaTypeHeaderValue("application/octet-stream");
    }
}
