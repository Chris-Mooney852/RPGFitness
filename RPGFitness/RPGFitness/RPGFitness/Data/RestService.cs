using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<Ingredient> Ingredients { get; set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
        }

        public async Task<List<Ingredient>> GetIngredientAsync()
        {
            Ingredients = new List<Ingredient>();
            var uri = new Uri(string.Format(Constraints.RestUrl + "Ingredient/"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(content);
                    Console.WriteLine(@"              SUCCESS fetching items");

                }
                else
                {
                    Console.WriteLine(@"               ERROR while fetching items: {0}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"				ERROR Exception Caught while fetching items: {0}", ex.Message);
            }
            return Ingredients;

        }

        public async void ShowIngredients()
        {
            await GetIngredientAsync();

            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine(ingredient.ToString() + "\n");
            }
        }
    }
}
