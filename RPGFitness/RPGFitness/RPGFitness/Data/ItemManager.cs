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
        public Recipe mealItem { get; set; }
        public int TotalCalories { get; set; }
        public Clock Clock { get; set; }
        public List<Exercise> currentExercises { get; set; }
        public Exercise exerciseItem { get; set; }
        public User newUser = new User();
        public double totalBurnedCalories { get; set; }
        


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

        public async Task<User> ReturnUserAsync(string user)
        {
            currentUser = await restservice.GetUserAsync(user);
            Clock = new Clock();
            Clock.ResetDailyData();
            return currentUser;
            
        }

        public Task SaveUserAsync(User user)
        {
            return restservice.CreateUserAsync(user);
        }

        public void UpdateUserAsync()
        {
            restservice.UpdateUserAsync(currentUser);
        }

        public async Task<List<Ingredient>> ReturnRecipeIngredients(Recipe recipe)
        {
            TotalCalories = 0;

            List<RecipeContent> currentContent = await restservice.GetRecipeContentsAsync(recipe.RecipeId);

            Ingredient newIngredient = new Ingredient();

            currentIngredients = new List<Ingredient>();

            foreach (RecipeContent ingredientContext in currentContent)
            {
                newIngredient = await ReturnIngredientAsync(ingredientContext.IngredientId);
                Console.WriteLine(newIngredient.ToString());
                currentIngredients.Add(newIngredient);
                TotalCalories += newIngredient.Calories;
            }
            Console.WriteLine(TotalCalories.ToString());
            return currentIngredients;
        }

        public double CalculateTotalCalories()
        {
            currentUser.ConsumedCalories += TotalCalories;
            UpdateUserAsync();
            return (double)TotalCalories / (double)currentUser.MaxDailyIntake;
        }

        public Task<List<Exercise>> ReturnExercises()
        {
            return restservice.GetExercisesAsync();
        }

        public double CalculateBurnedCalories()
        {
            currentUser.ConsumedCalories -= (int)totalBurnedCalories;
            UpdateUserAsync();
            return (double)totalBurnedCalories / (double)currentUser.MaxDailyIntake;
        }
    }
}
