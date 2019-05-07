using System;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace consumo_api
{
    class Program
    {
        static void Main(string[] args)
        {
            //Post
            string commentsApi = String.Format("https://jsonplaceholder.typicode.com/posts");
            WebRequest requestObjectPost = WebRequest.Create(commentsApi);
            requestObjectPost.Method = "POST";
            requestObjectPost.ContentType = "application/json";
            requestObjectPost.Credentials = new NetworkCredential("Username", "password");

            string postData = "{\"title\":\"testdata\",\"body\":\"testbody\",\"userId\":\"50\"}";

            using (var streamWriter = new StreamWriter(requestObjectPost.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjectPost.GetResponse();

                string resultPost = null;
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resultPost = streamReader.ReadToEnd();
                    Console.WriteLine(resultPost);
                }


            }
        }




        private static void GetTestWebRequest()
        {
            string commentsApi = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");

            WebRequest request = WebRequest.Create(commentsApi);
            request.Method = "GET";

            HttpWebResponse responseObject = (HttpWebResponse)request.GetResponse();

            string resultTest = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultTest = sr.ReadToEnd();
                Console.WriteLine(resultTest);

                sr.Close();

            }
        }

        private static async Task ApiTest()
        {
            BuildQueue build = new BuildQueue(@"https://jsonplaceholder.typicode.com");

            var list = await build.GetBuildsAsync("posts/42", "42");

            //foreach (var item in list)
            //{
            Console.WriteLine(list.ToString());
            //}


            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

