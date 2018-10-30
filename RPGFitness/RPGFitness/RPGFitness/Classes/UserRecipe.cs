using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RPGFitness.Classes
{
    public class UserRecipe
    {
        [PrimaryKey, Unique]
        public string Id { get; set; }
        public string recipeName { get; set; }
        public int totCalories { get; set; }

        /// <summary>
        /// Converts the total calories to a fraction of the maximum daily intake.
        /// </summary>
        /// <returns></returns>
        public double ConvertTotalCalories()
        {           
            return (double)totCalories / (double)App.Manager.currentUser.MaxDailyIntake;
        }

        /// <summary>
        /// Updates the Azure database with the users current calories.
        /// </summary>
        public void UpdateUserCalories()
        {
            App.Manager.currentUser.ConsumedCalories += totCalories;
            App.Manager.UpdateUserAsync();
        }
    }

    
}
