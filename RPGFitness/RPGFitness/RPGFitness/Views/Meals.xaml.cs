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
	public partial class Meals : ContentPage
	{
        
		public Meals ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MealList.ItemsSource = await App.Manager.ReturnRecipies();
        }

        //Set the the current meal item to the selected recipe
        void OnMealSelected(object sender, SelectedItemChangedEventArgs e)
        {
          
            App.Manager.mealItem = e.SelectedItem as Recipe;
            App.navigationManager.ShowRecipeContentsPage();
        }

        //Show the users meal plan page
        private void OnMyMealsClicked(object sender, EventArgs e)
        {           
            App.navigationManager.ShowMyMealPlanPage();
        }
    }
}
