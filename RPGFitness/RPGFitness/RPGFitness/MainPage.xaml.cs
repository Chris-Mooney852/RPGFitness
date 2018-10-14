using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RPGFitness.Data;
using Xamarin.Forms;

namespace RPGFitness
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            printRecipeAndIngredients();
        }

        public async void printRecipeAndIngredients()
        {
            RestService restService = new RestService();
            
            await restService.GetRecipesAsync();
            Recipe snags = restService.Recipes.Find(x => x.RecipeId == 4);
            await restService.GetRecipeContentsAsync();
            List<RecipeContent> snagsContent = restService.RecipeContents.FindAll(x => x.RecipeId == snags.RecipeId);
            await restService.GetIngredientAsync();
            
            Console.WriteLine(snags.ToString());

            foreach (RecipeContent content in snagsContent)
            {
                Ingredient ingredient = restService.Ingredients.Find(x => x.ID == content.IngredientId);
                Console.WriteLine(ingredient.ToString());
            }
        }
    }
}
