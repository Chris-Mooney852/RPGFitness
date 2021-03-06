﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public partial class ExercisePage : ContentPage
	{
        
        public ExercisePage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ExerciseList.ItemsSource = await App.Manager.ReturnExercises();
        }

        //Set the selected exercise item to the current exercise item and show
        //the details page
        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            App.Manager.exerciseItem = e.SelectedItem as Exercise;
            App.navigationManager.ShowExerciseDetailPage();
        }

        //Show the users exercise plan page
        void OnShowUserExerciseClicked (object sender, EventArgs e)
        {            
            App.navigationManager.ShowUserExercisePage();           
        }
    }
}