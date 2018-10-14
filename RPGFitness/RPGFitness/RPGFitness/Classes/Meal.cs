using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness.Classes
{
    class Meal
    {
        public Dictionary<string, uint> Ingredients { get; set; } = new Dictionary<string, uint>();
        public int TotalCalories { get; set; }
        

        public Meal()
        {
        }

        

        public List<uint> GetCalories()
        {
            throw new NotImplementedException();
        }

        public uint CalculateTotalCalories( List<uint> calories )
        {
            throw new NotImplementedException();
        }

        
    }
}
