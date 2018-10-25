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

        public List<Ingredient> Ingredients;

        public RecipePage ()
		{
            
			InitializeComponent ();
            


		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Ingredients == null)
            {
                LoadingLabel.Text = "Loading....";
            }
           

            Ingredients = await App.Manager.ReturnRecipeIngredients(App.Manager.mealItem);

            RecipeLabel.BindingContext = App.Manager.mealItem;
            IngredientsList.ItemsSource = Ingredients;

            LoadingLabel.Text = "";
            TotalLabel.Text = "Total Calories:";
            TotalCalories.Text = Convert.ToString(App.Manager.TotalCalories);

        }

        public async void OnIntakeClicked(object sender, EventArgs e)
        {
            App.Manager.currentUser._Health -= App.Manager.CalculateTotalCalories();
            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;
            Console.WriteLine("***************** Current Calories {0}", App.Manager.currentUser.ConsumedCalories);
            Console.WriteLine("**************** current user health: {0}", App.Manager.currentUser._Health);
            App.Manager.TotalCalories = 0;
            await Navigation.PopAsync();
        }

        public async void OnAddMealClicked(object sender, EventArgs e)
        {
            App.UserItemManager.currentUserrecipe.Id = null;
            App.UserItemManager.currentUserrecipe.recipeName = App.Manager.mealItem.RecipeName;
            App.UserItemManager.currentUserrecipe.totCalories = App.Manager.TotalCalories;
            await App.UserItemManager.SaveUserRecipeAsync(App.UserItemManager.currentUserrecipe);
            App.Manager.TotalCalories = 0;
            await Navigation.PopAsync();

        }
    }
}