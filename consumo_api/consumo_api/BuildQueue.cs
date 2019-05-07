using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace consumo_api
{
    class BuildQueue
    {
        public HttpClient ClientApiBuild { get; private set; }
        public string Uri { get; set; }

        public BuildQueue(string uri)
        {
            ClientApiBuild = new HttpClient();
            ClientApiBuild.BaseAddress = new Uri(uri);
            ClientApiBuild.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Post> GetBuildsAsync(string apiPath, params string[] param)
        {
            //UriBuilder builder = new UriBuilder(apiPath);
            // builder.Query = String.Join('&', param);
            // builder.Query = String.Join('&', param);

            //Console.WriteLine(builder.ToString());
            // HttpResponseMessage response = await ClientApiBuild.GetAsync(builder.ToString());
            HttpResponseMessage response = await ClientApiBuild.GetAsync(apiPath);


            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Post>(data);
            }

            return null;
        }
    }
}
