using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using OpenQA.Selenium.Remote;
using System.Net;

namespace RepoClass
{
    public class BooksObject
    {
        public string title { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
    }

    public class BooksAPI
    {
        public static string urlParameters = "?api_key=123";

        //WYSTARCZY PRZYPISAC METODĘ DO LISTY<BooksObject>
        public List<BooksObject> BookList()
        {
            List<BooksObject> lista = new List<BooksObject>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(REPO.URLBooks);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<BooksObject>>().Result;
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
