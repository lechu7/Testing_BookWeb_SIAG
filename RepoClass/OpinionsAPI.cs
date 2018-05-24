using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RepoClass
{
    
 public class OpinionsObject
    {
        public string username { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }
        public List<OpinionsTabObject> opinions { get; set; }
            public class OpinionsTabObject
        {
            public string id { get; set; }
            public string rate { get; set; }
            public string description { get; set; }
            public string user_id { get; set; }
            public string book_id { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }

        }
    }



    public class OpinionsAPI
    {
        private const string URL = "http://siag-bookweb.herokuapp.com/api/users/json";
        public static string urlParameters = "?opinions=true";


        //WYSTARCZY PRZYPISAC METODĘ DO LISTY<STRING>
        public List<OpinionsObject> opinionsList()
        {
            List<OpinionsObject> lista = new List<OpinionsObject>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(REPO.URLUsers);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<OpinionsObject>>().Result;
                foreach (var d in dataObjects)
                {
                    lista.Add(d);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return lista;
        }
    }
}
