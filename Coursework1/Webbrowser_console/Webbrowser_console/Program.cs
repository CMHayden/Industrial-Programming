using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Webbrowser_console
{
    class Program
    {
        public static string getHtml(string url)
        {
            string html = string.Empty;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                   | SecurityProtocolType.Tls11
                   | SecurityProtocolType.Tls12
                   | SecurityProtocolType.Ssl3;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Console.Write(response.StatusCode);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                {
                    html = reader.ReadToEnd();
                }

                return html;
            }
            catch (WebException e) // Works with normal exception too.
            {
                return e.Message;
            }
        }

        static void Main()
        {
            Console.WriteLine("Please insert URL");
            string url = Console.ReadLine();

            try
            {
                new Uri(url);
            }
            catch
            {
                Console.WriteLine("Invalid URL");
                Main();
            }

            //string url = "http://www.contoso.com/";
            string html = getHtml(url);

            Console.WriteLine(html);



            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }


    }
}
