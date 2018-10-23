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
	public partial class UserExerciseDetailPage : ContentPage
	{
		public UserExerciseDetailPage ()
		{
			InitializeComponent ();

            ExerciseName.BindingContext = App.UserItemManager.currentUserExercise;
            ExerciseType.BindingContext = App.UserItemManager.currentUserExercise;
            CaloriesBurned.BindingContext = App.UserItemManager.currentUserExercise;
		}

       

        public async void OnCompleteClicked(object sender, EventArgs e)
        {
            App.Manager.totalBurnedCalories = App.UserItemManager.currentUserExercise.totalCaloriesBurned;
            App.Manager.currentUser._Health += App.Manager.CalculateBurnedCalories();
            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;
            App.Manager.totalBurnedCalories = 0;
            await Navigation.PopAsync();
        }
    }
}