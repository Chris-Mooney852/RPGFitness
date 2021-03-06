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
	public partial class UserMealDetailPage : ContentPage
	{
		public UserMealDetailPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NameLabel.BindingContext = App.UserItemManager.currentUserrecipe;
            CalorieLabel.BindingContext = App.UserItemManager.currentUserrecipe;
        }

        //Calculate the remaining calories and update users health (daily intake)
        private void AddCaloriesClicked(object sender, EventArgs e)

        {
            App.Manager.currentUser.CalculateRemainingCalories();

            Navigation.PopAsync();

        }
    }
}