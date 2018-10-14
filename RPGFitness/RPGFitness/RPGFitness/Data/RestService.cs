using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<Recipe> Recipes { get; set; }
        public List<RecipeContent> RecipeContents { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public User User { get; set; }

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
                    Console.WriteLine(@"              SUCCESS fetching ingredients");
                    Console.WriteLine(@"              SUCCESS fetching items");

                }
                else
                {
                    Console.WriteLine(@"               ERROR while fetching ingredients: {0}", response.StatusCode);
                    Console.WriteLine(@"               ERROR while fetching items: {0}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"				ERROR Exception Caught while fetching ingredients: {0}", ex.Message);
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
                Console.WriteLine(stringContent.ToString());

                response = await client.PostAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();

                Console.WriteLine(response.Headers.Location);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"				ERROR Exception Caught while creating ingredients: {0}", e.Message);
                Console.WriteLine(@"				ERROR Exception Caught while creating items: {0}", e.Message);
            }

            return response.Headers.Location;
        }

        /// <summary>
        /// calls the CreateIngredientAsync function and awaits for it to run
        /// </summary>
        /// <param name="ingredient">Ingredient to be added</param>
        public async void DoCreateIngredient(Ingredient ingredient)
        {
            await CreateIngredientAsync(ingredient);
        }

        /// <summary>
        /// Updates an ingredient entry in the SQL database using the API
        /// </summary>
        /// <param name="ingredient">Ingredient to update</param>
        /// <returns>Ingredient</returns>
        public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var uri = new Uri(string.Format(Constraints.RestUrl + "Ingredient/" + ingredient.ID));
            try
            {
                var content = JsonConvert.SerializeObject(ingredient);
                var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");
                Console.WriteLine(content);

                response = await client.PutAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"				ERROR Exception Caught while updating ingredients: {0}", e.Message);
                Console.WriteLine(@"				ERROR Exception Caught while updating items: {0}", e.Message);
            }

            // Deserialize the updated product from the response body.
            ingredient = await response.Content.ReadAsAsync<Ingredient>();
            return ingredient;
        }

        /// <summary>
        /// Calls update ingredient and awaits for it to finish before printing the updated ingredient
        /// </summary>
        /// <param name="ingredient">Ingredient to be updated</param>
        public async void DoUpdateIngredient(Ingredient ingredient)
        {
            Ingredient updated = await UpdateIngredientAsync(ingredient);
            Console.WriteLine(updated.ToString());
        }

        /// <summary>
        /// Deletes Ingredient from the database
        /// </summary>
        /// <param name="ingredient">Ingredient to be deleted</param>
        /// <returns>Confirmation message</returns>
        public async Task<HttpResponseMessage> DeleteIngredientAsync(Ingredient ingredient)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var uri = new Uri(string.Format(Constraints.RestUrl + "Ingredients/" + ingredient.ID.ToString()));

            try
            {
                response = await client.DeleteAsync(uri);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"				ERROR Exception Caught while deleting ingredients: {0}", e.Message);
                Console.WriteLine(@"				ERROR Exception Caught while deleting item: {0}", e.Message);
            }
            return response;
        }

        /// <summary>
        /// Calls DeleteIngredient and awaits for it to finish
        /// </summary>
        /// <param name="ingredient">Ingredient to delete</param>
        public async void DoDelete(Ingredient ingredient)
        {
            await DeleteIngredientAsync(ingredient);
        }

        /// <summary>
        /// Retrieves user with the provided id
        /// </summary>
        /// <param name="id">User id to get</param>
        /// <returns>User</returns>
        public async Task<User> GetUserAsync(int id)
        {
            var uri = new Uri(string.Format(Constraints.RestUrl + "User/" + id));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)

                {
                    var content = await response.Content.ReadAsStringAsync();
                    User = JsonConvert.DeserializeObject<User>(content);
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
            return User;
        }

        /// <summary>
        /// Awaits for GetUserAsync to complete then prints the result to console
        /// </summary>
        /// <param name="id">user ID to retrieve</param>
        public async void showUser(int id)
        {
            await GetUserAsync(id);
            Console.WriteLine(User.ToString());
        }

        /// <summary>
        /// Adds Provided user to the SQL database
        /// </summary>
        /// <param name="user">User data to add to database</param>
        /// <returns>URI of new user</returns>
        public async Task<Uri> CreateUserAsync(User user)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var uri = new Uri(string.Format(Constraints.RestUrl + "User/"));
            try
            {
                var content = JsonConvert.SerializeObject(user);
                var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");
                Console.WriteLine(stringContent.ToString());

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

        /// <summary>
        /// Updates the Provided users informaion on the database
        /// </summary>
        /// <param name="user">User to be updated</param>
        /// <returns>User data</returns>
        public async Task<User> UpdateUserAsync(User user)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var uri = new Uri(string.Format(Constraints.RestUrl + "User/" + user.UserID));
            try
            {
                var content = JsonConvert.SerializeObject(user);
                var stringContent = new StringContent(content, UnicodeEncoding.UTF8, "application/json");
                Console.WriteLine(content);

                response = await client.PutAsync(uri, stringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"				ERROR Exception Caught while updating items: {0}", e.Message);
            }

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        /// <summary>
        /// Retrieves list of recipes from the database
        /// </summary>
        /// <returns>List of Recipies</returns>
        public async Task<List<Recipe>> GetRecipesAsync()
        {
            var uri = new Uri(string.Format(Constraints.RestUrl + "Recipe/"));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)

                {
                    var content = await response.Content.ReadAsStringAsync();
                    Recipes = JsonConvert.DeserializeObject<List<Recipe>>(content);
                    Console.WriteLine(@"              SUCCESS fetching Recipies");

                }
                else
                {
                    Console.WriteLine(@"               ERROR while fetching Recipies: {0}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"				ERROR Exception Caught while fetching Recipies: {0}", ex.Message);
            }
            return Recipes;
        }

        /// <summary>
        /// Adds new recipe to the database
        /// </summary>
        /// <param name="recipe">Recipe to be added</param>
        /// <param name="ingredients">List of ingredients in recipe</param>
        /// <returns>URI of new Recipe</returns>
        public Task<Uri> CreateRecipeAsync(Recipe recipe, List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> UpdateRecipeAsync(Recipe recipe, List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves Recipe contents
        /// </summary>
        /// <returns>List of contents in recipe</returns>
        public async Task<List<RecipeContent>> GetRecipeContentsAsync()
        {
            var uri = new Uri(string.Format(Constraints.RestUrl + "Contents/"));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)

                {
                    var content = await response.Content.ReadAsStringAsync();
                    RecipeContents = JsonConvert.DeserializeObject<List<RecipeContent>>(content);
                    Console.WriteLine(@"              SUCCESS fetching content");

                }
                else
                {
                    Console.WriteLine(@"               ERROR while fetching content: {0}", response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"				ERROR Exception Caught while fetching content: {0}", ex.Message);
            }
            return RecipeContents;
        }
    }
}
