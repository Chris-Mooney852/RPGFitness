using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RPGFitness
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }

        public Ingredient()
        {

        }

        /// <summary>
        /// Creates an Ingredient
        /// </summary>
        /// <param name="id">Identification number of the ingredient</param>
        /// <param name="name">Name of the ingredient</param>
        /// <param name="calories">Total calories in the ingredient</param>
        public Ingredient(int id, string name, int calories)
        {
            ID = id;
            Name = name;
            Calories = calories;
        }

        /// <summary>
        /// Converts ingredient to a string able to be printed to console
        /// </summary>
        /// <returns>Ingredient as a string</returns>
        public override string ToString()
        {

            return String.Format("ID: {0} Name: {1} Calories: {2}", ID, Name, Calories);

        }

    }   
}
