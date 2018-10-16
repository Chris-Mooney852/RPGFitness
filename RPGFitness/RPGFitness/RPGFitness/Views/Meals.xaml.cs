﻿using System;
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
            MealList.ItemsSource = await App.Manager.ReturnIngredientAsync();
            var items = await App.Manager.ReturnIngredientAsync();
            App.Manager.currentIngredients = items;

            var names = await App.Manager.ReturnAllUsersAsync();
            App.Manager.currentUsers = names;

        }
	}
}
