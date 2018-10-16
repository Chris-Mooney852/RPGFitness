using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace RPGFitness.Data
{
    public class ItemManager
    {
        IRestService restservice;



        public List<Ingredient> currentIngredients { get; set; }
        public List<Recipe> currentRecipes { get; set;}
        public User currentUser { get; set; }
        public List<User> currentUsers { get; set; }
        public Recipe mealItem { get; set; }




        public ItemManager(IRestService service)
        {
            restservice = service;
        }

        public Task<Ingredient> ReturnIngredientAsync(int recipeId)
        {
            return restservice.GetIngredientAsync(recipeId);
        }

        public Task<List<Recipe>> ReturnRecipies()
        {
            return restservice.GetRecipesAsync();
        }

        public Task<User> ReturnUserAsync(string user)
        {
            return restservice.GetUserAsync(user);
        }

        public Task SaveUserAsync(User user)
        {
            return restservice.CreateUserAsync(user);
        }

        public async Task<List<Ingredient>> ReturnRecipeIngredients(Recipe recipe)
        {
            List<RecipeContent> currentContent = await restservice.GetRecipeContentsAsync(recipe.RecipeId);
            Ingredient newIngredient = new Ingredient();
            currentIngredients = new List<Ingredient>();

            foreach (RecipeContent ingredientContext in currentContent)
            {
                newIngredient = await ReturnIngredientAsync(ingredientContext.IngredientId);
                Console.WriteLine(newIngredient.ToString());
                currentIngredients.Add(newIngredient);
            }
            return currentIngredients;
        }
    }
}
