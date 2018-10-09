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

        public Ingredient(int id, string name, int calories)
        {
            this.ID = id;
            this.Name = name;
            this.Calories = calories;
        }

        public override string ToString()
        {

            return String.Format("ID: {0} Name: {1} Calories: {2}", ID, Name, Calories);

        }

    }   
}
