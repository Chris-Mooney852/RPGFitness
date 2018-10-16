using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness
{
    public partial class RecipeContent
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        /// <summary>
        /// Converts Recipe into printable string
        /// </summary>
        /// <returns>Recipe as string</returns>
        public override string ToString()
        {
            return String.Format("RecipeID: {0} IngredientID: {1}", RecipeId, IngredientId);
        }
    }
}
