using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sovtech_test.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace sovtech_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private const string base_chuck_URL = "https://api.chucknorris.io";
        private const string base_swapi_URL = "https://swapi.dev";
        private string api_chuck = "/jokes/search?query={0}";
        private string api_swapi = "/api/people/?search={0}";

        [HttpGet]
        public async Task<List<Search>> Search(string query)
        {
            dynamic content_chuck = string.Empty;
            dynamic content_swapi = string.Empty;
            var chuck = new Chuck();
            var people = new People();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(base_chuck_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage chuck_response = await client.GetAsync(string.Format(api_chuck, query));
            if (chuck_response.IsSuccessStatusCode)
            {
                content_chuck = await chuck_response.Content.ReadAsStringAsync();
                chuck = JsonConvert.DeserializeObject<Chuck>(content_chuck);
            }
            else
            {
                content_chuck = string.Format("{0} ({1})", (int)chuck_response.StatusCode, chuck_response.ReasonPhrase);
            }

            HttpClient swapi_client = new HttpClient();
            swapi_client.BaseAddress = new Uri(base_swapi_URL);
            swapi_client.DefaultRequestHeaders.Accept.Clear();
            swapi_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage swapi_response = await swapi_client.GetAsync(string.Format(api_swapi, query));
            if (swapi_response.IsSuccessStatusCode)
            {
                content_swapi = await swapi_response.Content.ReadAsStringAsync();
                people = JsonConvert.DeserializeObject<People>(content_swapi);
            }
            else
            {
                content_swapi = string.Format("{0} ({1})", (int)swapi_response.StatusCode, swapi_response.ReasonPhrase);
            }

            List<Search> s = new List<Search>();
            s.Add(new Search
            {
                api_name = base_chuck_URL,
                chuck = chuck
            });
            s.Add(new Search
            {
                api_name = base_swapi_URL,
                swapi = people
            });

            return s;
        }



    }
}