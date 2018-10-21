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
    public partial class CreateRecipePage : ContentPage
    {
        public CreateRecipePage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
           
            App.UserItemManager.currentUserrecipe.Id = null;
            App.UserItemManager.currentUserrecipe.recipeName = NameEntry.Text;
            App.UserItemManager.currentUserrecipe.totCalories = Convert.ToInt16(CalorieEntry.Text);
            
            await App.UserItemManager.SaveUserRecipeAsync(App.UserItemManager.currentUserrecipe);
            await Navigation.PopAsync();
        }
    }
}