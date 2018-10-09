using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public class RestService : IRestService
    {
        HttpClient client;


        public List<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Initializes the rest service to be used with the API
        /// </summary>
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
        }

        /// <summary>
        /// Retrieves the list of all ingredients from the SQL database using the API
        /// </summary>
        /// <returns>List of Ingredients</returns>
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

        /// <summary>
        /// Awaits for GetIngredientsAsync to finish then displays the list of ingredients
        /// </summary>
        public async void ShowIngredients()
        {
            await GetIngredientAsync();

            foreach (Ingredient ingredient in Ingredients)
            {
                Console.WriteLine(ingredient.ToString() + "\n");
            }
        }

        /// <summary>
        /// Adds the provided ingredient to the database
        /// </summary>
        /// <param name="ingredient">Ingredient to be added to the database</param>
        /// <returns>The URI of the created ingredient</returns>
        public async Task<Uri> CreateIngredientAsync(Ingredient ingredient)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var uri = new Uri(string.Format(Constraints.RestUrl + "Ingredient/"));
            try
            {
                var content = JsonConvert.SerializeObject(ingredient);
                var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");

                response = await client.PostAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();

                Console.WriteLine(response.Headers.Location);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"				ERROR Exception Caught while creating items: {0}", e.Message);
            }

            return response.Headers.Location;
        }

        public async void DoCreateIngredient(Ingredient ingredient)
        {
            await CreateIngredientAsync(ingredient);
        }
    }
}
