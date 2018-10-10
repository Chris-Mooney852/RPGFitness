using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RPGFitness.Data;
using Xamarin.Forms;

namespace RPGFitness
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RestService rest = new RestService();
            Ingredient ingredient = new Ingredient(1, "coke vanilla", 1000);
            rest.ShowIngredients();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //listView.ItemsSource = await App.Manager.ReturnIngredientAsync();
        }
    }
}
