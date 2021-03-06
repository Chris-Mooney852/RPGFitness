﻿using Syncfusion.XForms.ProgressBar;
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
	public partial class HomePage : ContentPage
	{
        

		public HomePage ()
		{
			InitializeComponent ();


            //Bind the Name Label to the current user
            NameLabel.BindingContext = App.Manager.currentUser;

            //Assign the remaing user health to the users health and convert to a percentage.
            App.Manager.currentUser._Health = ((double)App.Manager.currentUser.MaxDailyIntake - 
                (double)App.Manager.currentUser.ConsumedCalories) / (double)App.Manager.currentUser.MaxDailyIntake;


            //Assign the user remaining calories
            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;

            //Bind the health bar to the current user.
            UserHealth.BindingContext = App.Manager.currentUser;

            //Bind the current weight label to the current users weight
            WeightLabel.BindingContext = App.Manager.currentUser;

            //Bind the goal weight label to the current user
            GoalLabel.BindingContext = App.Manager.currentUser;

            CalorieLabel.BindingContext = App.Manager.currentUser;


        }
       
	}
}