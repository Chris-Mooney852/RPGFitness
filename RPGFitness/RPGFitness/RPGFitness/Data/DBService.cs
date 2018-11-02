using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RPGFitness.Classes;
using SQLite;

namespace RPGFitness.Data
{
    class DBService : IDataService
    {

        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// Create the tables in the SqLite local database
        /// </summary>
        /// <param name="dbPath"> Path for the local database </param>
        public DBService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserRecipe>().Wait();
            database.CreateTableAsync<UserExercise>().Wait();
           
        }

        //Return the UserRecipe table in the local database
        public Task<List<UserRecipe>> RefreshRecipesAsync()
        {
            return database.Table<UserRecipe>().ToListAsync();
        }

        //Save the user recipe to the local database
        public Task SaveRecipeAsync(UserRecipe recipe)
        {
            if (recipe.Id != null)
            {
                return database.UpdateAsync(recipe);
            }
            else
            {
                //generate id before saving
                recipe.Id = DateTime.Now.GetHashCode().ToString();
                return database.InsertAsync(recipe);
            }
        }

        //Return the user exercises table from the local database
        public Task<List<UserExercise>> RefreshExerciseAsync()
        {
            return database.Table<UserExercise>().ToListAsync();
        }

        //Save the user exercise to the local database
        public Task SaveExerciseAsync(UserExercise exercise)
        {
            if (exercise.Id != null)
            {
                return database.UpdateAsync(exercise);
            }
            else
            {
                //generate id before saving
                exercise.Id = DateTime.Now.GetHashCode().ToString();
                return database.InsertAsync(exercise);
            }
        }       


    }
}
