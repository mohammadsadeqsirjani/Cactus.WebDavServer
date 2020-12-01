using System;
using System.Threading.Tasks;
using WebDav.Request;

namespace WebDav.Console
{
    public class Program
    {
        public static async Task Main()
        {
            var clientParameters = new WebDavClientParameters
            {
                BaseAddress = new Uri("http://localhost/webdav"),
            };

            using var webDavClient = new WebDavClient(clientParameters);

            var response = await webDavClient.GetRawFile("test.docx");

            if (response.IsSuccessful)
            {
            }

            System.Console.WriteLine(response);
        }
    }
}
