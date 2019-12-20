using System;
using System.IO;
using System.Net;
using System.Text;

namespace Listener
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://127.0.0.1";
            string port = "50052";
            string prefix = $"{url}:{port}/";

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix);

            listener.Start();

            Console.WriteLine("Welcome to simple HttpListener.\n", port);
            Console.WriteLine("Listening on {0}...", prefix);

            while (true)
            {
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;

                HttpListenerResponse response = context.Response;

                string requestBody;
                Stream inputStream = request.InputStream;
                Encoding encoding = request.ContentEncoding;
                StreamReader reader = new StreamReader(inputStream, encoding);
                requestBody = reader.ReadToEnd();

                Console.WriteLine("{0} request was caught: {1}",
                    request.HttpMethod, request.Url);

                response.StatusCode = (int)HttpStatusCode.OK;

                using (Stream stream = response.OutputStream) { }
            }
        }
    }
}
