using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sovtech_test.Entities;


namespace sovtech_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private const string baseURL = "https://swapi.dev";
        private string api = "/api/people/";

        [HttpGet("people", Name = "people")]
        public async Task<People> GetPeople()
        {
            var content = string.Empty;
            var people = new People();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                    people = JsonConvert.DeserializeObject<People>(content);
                }
                else
                {
                    content = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return people;
        }
    }
}