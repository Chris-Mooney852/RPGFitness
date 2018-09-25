using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness.Classes
{
    class Ingredient
    {
        private string ingredientName { get; set; }
        private uint calories { get; set; }

        public Ingredient()
        {

        }

        public Ingredient (string name, uint calories)
        {
            ingredientName = name;
            this.calories = calories;
        }
    }
}
