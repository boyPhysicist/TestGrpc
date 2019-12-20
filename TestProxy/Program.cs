using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;

namespace TestProxy
{
    class Program
    {
        static void Main()
        {
            Listen();
            Console.ReadLine();
        }

        private static void Listen()
        {
           var listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:" + Defines.Port.ToString() + "/");
            listener.Start();

            while (true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
    
}

