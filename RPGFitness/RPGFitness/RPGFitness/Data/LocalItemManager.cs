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

        public UserExercise currentUserExercise = new UserExercise();

        public List<UserExercise> currentUserExercises { get; set; }

        public UserLogin currentUserLogin = new UserLogin();

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

        public Task<List<UserExercise>> GetUserExerciseAsync()
        {
            return localUserservice.RefreshExerciseAsync();
        }

        public Task SaveUserExerciseAsync(UserExercise exercise)
        {
            return localUserservice.SaveExerciseAsync(exercise);
        }

        public Task SaveUserLoginAsync(UserLogin login)
        {
            return localUserservice.SaveLastLoginAsync(login);
        }

        public Task<List<UserLogin>> GetLastLoginAsync()
        {
            return localUserservice.ReturnLoginAsync();
        }

     

           
    }
}
