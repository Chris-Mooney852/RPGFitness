using RPGFitness.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPGFitness.Data
{
    public interface IDataService
    {
        Task<List<UserRecipe>> RefreshRecipesAsync();

        Task SaveRecipeAsync(UserRecipe recipe);

        Task<List<UserExercise>> RefreshExerciseAsync();

        Task SaveExerciseAsync(UserExercise exercise);

        Task SaveLastLoginAsync(UserLogin login);

        Task<UserLogin> RefreshLastLoginAsync(string id);
    }
}
