using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RPGFitness.Data
{
    public class ItemManager
    {
        IRestService restservice;

        public List<Ingredient> currentIngredients { get; set; }
        public User currentUser { get; set; }
        

        public ItemManager(IRestService service)
        {
            restservice = service;
        }

        public Task<List<Ingredient>> ReturnIngredientAsync()
        {
            return restservice.GetIngredientAsync();
        }

        public Task<User> ReturnUserAsync()
        {
            return restservice.GetUserAsync(3);
        }
    }
}
