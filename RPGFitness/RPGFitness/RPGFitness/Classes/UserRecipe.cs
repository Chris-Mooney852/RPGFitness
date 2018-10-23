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
    }

    public class Rootobject
    {
        public UserRecipe[] items { get; set; }
    }
}
