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

            //Display a loading message while the ingredients list loads
            if (Ingredients == null)
            {
                LoadingLabel.Text = "Loading....";
            }
           
            //Populate the list of ingredients with items from the Azure database
            Ingredients = await App.Manager.ReturnRecipeIngredients(App.Manager.mealItem);

            //Bind the recipe label to the name of the current recipe
            RecipeLabel.BindingContext = App.Manager.mealItem;

            //Bind the views list of ingredients to the current recipes list of ingredients
            IngredientsList.ItemsSource = Ingredients;

            //Remove the loading message
            LoadingLabel.Text = "";

            TotalLabel.Text = "Total Calories:";

            //Display the total ingredients for the recipe
            TotalCalories.Text = Convert.ToString(App.Manager.mealItem.TotalCalories);

        }

       
        
        //Might need to clean this up a bit ************************
        public async void OnAddMealClicked(object sender, EventArgs e)
        {
            App.UserItemManager.currentUserrecipe.Id = null;
            App.UserItemManager.currentUserrecipe.recipeName = App.Manager.mealItem.RecipeName;
            App.UserItemManager.currentUserrecipe.totCalories = App.Manager.mealItem.TotalCalories;

            await App.UserItemManager.SaveUserRecipeAsync(App.UserItemManager.currentUserrecipe);

            App.Manager.mealItem.TotalCalories = 0;

            await Navigation.PopAsync();

        }
    }
}