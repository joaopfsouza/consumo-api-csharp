using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace consumo_api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                string personalaccesstoken = "srb3k6zh7ahrhkyzmdbcj222f2tm3oaofqfj3xbvjmd6wg77ut3q";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(
                        string.Format("{0}:{1}", "", personalaccesstoken))));

                    using (HttpResponseMessage response = await client.GetAsync("http://tfs:8080/tfs/KrotonCollection/_apis/projects"))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(responseBody);

                        IList<string> projectTFS = json.SelectToken("value").ToList().Select(s =>
                        {
                            Console.WriteLine(s.SelectToken("name").Value<string>());
                            return "teste";

                        }).ToList();

                        //foreach (var item in projectTFS)
                        //{
                        //    Console.WriteLine(item);
                        //}

                        //IEnumerable<JToken> 

                        //Console.WriteLine(json.SelectToken());
                    }


                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ApiPostTest()
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

