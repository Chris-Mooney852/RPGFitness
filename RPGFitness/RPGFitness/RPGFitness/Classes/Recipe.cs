using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int TotalCalories { get; set; }

        /// <summary>
        /// Converts Recipe into printable string
        /// </summary>
        /// <returns>Recipe as string</returns>
        public override string ToString()
        {
            return String.Format("ID: {0} Name: {1}", RecipeId, RecipeName);
        }

    }
}
