using System;
using System.IO;
using System.Net;

namespace CallWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Connect();
        }

        static void Connect()
        {
            string URL = "http://url-api";
            string DATA = @"{
                ""client_id"":""client_id"",
                ""client_secret"":""client_secret"",
                ""username"":""username"",
                ""password"":""password"",
                ""grant_type"":""grant_type""
            }";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            using (Stream webStream = request.GetRequestStream())
            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            {
                requestWriter.Write(DATA);
            }

            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            Console.Out.WriteLine(response);
                            Console.ReadLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}