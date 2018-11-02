using RPGFitness.Classes;
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
	public partial class UserMealsPage : ContentPage
	{
        

        public UserMealsPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.UserItemManager.GetUserRecipeAsync();           
        }

        //Show the add custome recipe page
        private void AddRecipeClicked(object sender, EventArgs e)
        {          
            App.navigationManager.ShowCreateRecipePage();
        }

        //Set the current user recipe to the selected recipe
        void OnMealSelected(object sender, SelectedItemChangedEventArgs e)
        {          
            App.UserItemManager.currentUserrecipe = e.SelectedItem as UserRecipe;
            App.navigationManager.ShowUserRecipeDetailPage();
        }
    }
}