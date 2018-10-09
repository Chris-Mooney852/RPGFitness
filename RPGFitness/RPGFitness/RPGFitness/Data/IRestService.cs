using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RPGFitness.Data
{
    public interface IRestService
    {
        Task<List<Ingredient>> GetIngredientAsync();
        void ShowIngredients();
        Task<Uri> CreateIngredient(Ingredient ingredient);

    }
}
