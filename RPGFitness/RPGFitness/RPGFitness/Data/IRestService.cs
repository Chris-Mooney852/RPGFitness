using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGFitness.Data
{
    public interface IRestService
    {
        Task<List<Ingredient>> GetIngredientAsync();
        void ShowIngredients();

    }
}
