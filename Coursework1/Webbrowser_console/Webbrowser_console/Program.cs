﻿using System;
using System.Collections;
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

        public static Stack back = new Stack();
        public static Stack history = new Stack();
        public static Stack forward = new Stack();
        public static string temp;
        public static string home;

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
                Console.WriteLine(response.StatusCode);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                {
                    html = reader.ReadToEnd();
                }
                Console.WriteLine(response.StatusCode);

                StringBuilder webData = new StringBuilder();

                webData.Append(html);
                webData.AppendLine();
                webData.Append("The status code is: ");
                webData.Append(response.StatusCode);

                return webData.ToString();
            }
            catch (WebException e) // Works with normal exception too.
            {
                return e.Message;
            }
        }

        public static void goBack()
        {
            if (back.Count == 0)
            {
                Console.WriteLine("No options to go back to");
                return;
            }

            temp = back.Pop().ToString();
            forward.Push(temp);
            getPage(temp);

        }


        public static void goForward()
        {
            if (forward.Count == 0)
            {
                Console.WriteLine("No options to go forward to");
                return;
            }

            temp = forward.Pop().ToString();
            back.Push(temp);
            getPage(temp);

        }

        public static void goHome()
        {
            if(home == String.Empty || home == null)
            {
                home = history.Peek().ToString();
            }
            Console.WriteLine(home);
            Console.ReadKey();
            getPage(home);

        }

        public static void getHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("History is empty");
                return;
            }
            foreach (string url in history)
            {
                Console.WriteLine(url);
            }
        }



        public static void menu()
        {
            Console.WriteLine("Press b for back, f for forward, n for new url, i for home or h for history:");
            string option = Console.ReadLine();

            switch (option)
            {
                case "b":
                    goBack();
                    break;
                case "f":
                    goForward();
                    break;
                case "n":
                    back.Push(history.Peek());
                    getURL();
                    break;
                case "i":
                    goHome();
                    break;
                case "h":
                    getHistory();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }

        public static void getURL()
        {
            Console.WriteLine("Please insert URL");
            string url = Console.ReadLine();
            getPage(url);
        }

        public static void getPage(string url)
        { 
            try
            {
                new Uri(url);
            }
            catch
            {
                Console.WriteLine("Invalid URL");
                getURL();
            }

            Console.WriteLine(getHtml(url));

            history.Push(url);
            menu();
        }

        static void Main()
        {
            getURL();
            menu();

        }


    }
}
