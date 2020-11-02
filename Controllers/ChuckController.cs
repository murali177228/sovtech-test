using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace sovtech_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private const string baseURL = "https://api.chucknorris.io";
        private string api = "/jokes/categories";

        [HttpGet("categories", Name = "categories")]
        public async Task<string> GetCategories()
        {
            var content = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(api);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    content = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
            return content;
        }
    }
}

