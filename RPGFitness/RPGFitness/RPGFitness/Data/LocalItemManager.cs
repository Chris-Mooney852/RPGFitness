using RPGFitness.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPGFitness.Data
{
    public class LocalItemManager
    {
        IDataService localUserservice;

        public UserRecipe currentUserrecipe = new UserRecipe();

        public List<UserRecipe> currentUserRecipes { get; set;}

        public LocalItemManager (IDataService service)
        {
            localUserservice = service;
        }

        public Task<List<UserRecipe>> GetUserRecipeAsync()
        {
            return localUserservice.RefreshRecipesAsync();
        }

        public Task SaveUserRecipeAsync(UserRecipe recipe)
        {
            return localUserservice.SaveRecipeAsync(recipe);
        }
           
    }
}
