namespace Cactus.WebDav.Common.Helpers
{
    public static class IfHeaderHelper
    {
        public static string GetHeaderValue(string lockToken)
        {
            return $"(<{lockToken}>)";
        }
    }
}
