﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public interface IRestService
    {
        Task<Ingredient> GetIngredientAsync(int recipeId);
        Task<Uri> CreateIngredientAsync(Ingredient ingredient);
        Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient);
        Task<HttpResponseMessage> DeleteIngredientAsync(Ingredient ingredient);

        Task<User> GetUserAsync(string name);
        Task<Uri> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);

        Task<List<Recipe>> GetRecipesAsync();

        Task<List<RecipeContent>> GetRecipeContentsAsync(int recipeId);

        Task<List<Exercise>> GetExercisesAsync();
    }
}
