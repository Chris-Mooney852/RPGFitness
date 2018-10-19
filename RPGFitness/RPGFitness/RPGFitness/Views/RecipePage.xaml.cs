using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPGFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipePage : ContentPage
	{
		public RecipePage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            App.Manager.TotalCalories = 0;
            RecipeLabel.BindingContext = App.Manager.mealItem;
            IngredientsList.ItemsSource = await App.Manager.ReturnRecipeIngredients(App.Manager.mealItem);
            Calories.Text = Convert.ToString(App.Manager.TotalCalories);

        }

        public void OnIntakeClicked(object sender, EventArgs e)
        {
            App.Manager.currentUser._Health -= App.Manager.CalculateTotalCalories();
            Console.WriteLine("**************** current user health: {0}", App.Manager.currentUser._Health);
            App.Manager.TotalCalories = 0;
            App.Manager.UpdateUserAsync();
        }
    }
}