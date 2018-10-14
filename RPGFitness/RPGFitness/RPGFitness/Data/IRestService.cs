using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public interface IRestService
    {
        Task<List<Ingredient>> GetIngredientAsync();
        void ShowIngredients();
        Task<Uri> CreateIngredientAsync(Ingredient ingredient);
        Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        Task<HttpResponseMessage> DeleteIngredientAsync(Ingredient ingredient);

        Task<User> GetUserAsync(int id);
        Task<Uri> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);

        Task<List<Recipe>> GetRecipesAsync();
        Task<Uri> CreateRecipeAsync(Recipe recipe, List<Ingredient> ingredients);
        Task<Recipe> UpdateRecipeAsync(Recipe recipe, List<Ingredient> ingredients );

        Task<List<RecipeContent>> GetRecipeContentsAsync();
    }
}
