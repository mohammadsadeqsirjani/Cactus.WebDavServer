using System.Net.Http;

namespace Cactus.WebDav.Core.WebDav
{
    public static class WebDavMethod
    {
        public static readonly HttpMethod Propfind = new HttpMethod("PROPFIND");

        public static readonly HttpMethod PropPatch = new HttpMethod("PROPPATCH");

        public static readonly HttpMethod MkCol = new HttpMethod("MKCOL");

        public static readonly HttpMethod Copy = new HttpMethod("COPY");

        public static readonly HttpMethod Move = new HttpMethod("MOVE");

        public static readonly HttpMethod Lock = new HttpMethod("LOCK");

        public static readonly HttpMethod Unlock = new HttpMethod("UNLOCK");
    }
}
