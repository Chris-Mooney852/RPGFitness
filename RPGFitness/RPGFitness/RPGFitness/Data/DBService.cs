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

        public DBService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserRecipe>().Wait();
            database.CreateTableAsync<UserExercise>().Wait();
            //database.CreateTableAsync<UserLogin>().Wait();
        }

        public Task<List<UserRecipe>> RefreshRecipesAsync()
        {
            return database.Table<UserRecipe>().ToListAsync();
        }

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

        public Task<List<UserExercise>> RefreshExerciseAsync()
        {
            return database.Table<UserExercise>().ToListAsync();
        }

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

        //public Task<UserLogin> RefreshLastLoginAsync(string id)
        //{
        //    return  database.Table<UserLogin>().Where(i => i.UserId == id).FirstOrDefaultAsync();
        //}

        public Task SaveLastLoginAsync(UserLogin login)
        {

            login.Id = DateTime.Now.GetHashCode().ToString();  
            
            return database.InsertAsync(login);

            
        }

        public Task<List<UserLogin>> ReturnLoginAsync()
        {
            return database.Table<UserLogin>().ToListAsync();
        }

        


    }
}
