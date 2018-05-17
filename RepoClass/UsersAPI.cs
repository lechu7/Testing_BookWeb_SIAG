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
    public class UsersObject
    {
        public string userName { get; set; }
    }


    public class UsersAPI
    {
        private const string URL = "http://siag-bookweb.herokuapp.com/api/users/json";
        public static string urlParameters = "?api_key=123";


        //WYSTARCZY PRZYPISAC METODĘ DO LISTY<STRING>
        public List<string> userList()
        {
            List<string> lista = new List<string>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(REPO.URLUsers);

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<UsersObject>>().Result;
                foreach (var d in dataObjects)
                {
                    lista.Add(d.userName);
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
