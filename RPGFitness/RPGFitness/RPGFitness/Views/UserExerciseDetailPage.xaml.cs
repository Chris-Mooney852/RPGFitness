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
            CaloriesBurned.BindingContext = App.Manager.currentUser;
		}

       

        public async void OnCompleteClicked(object sender, EventArgs e)
        {

            App.Manager.totalBurnedCalories = App.Manager.currentUser.TotalExerciseCalories;
            App.Manager.currentUser._Health += App.Manager.CalculateBurnedCalories();
            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;
            App.Manager.totalBurnedCalories = 0;
            await Navigation.PopAsync();
        }

        private void ExerciseLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.Manager.currentUser.TotalExerciseCalories = Convert.ToInt16(ExerciseLength.Text) * (App.UserItemManager.currentUserExercise.totalCaloriesBurned / 10);
            }
            catch(Exception)
            {

            } 
            

            App.Manager.totalBurnedCalories = App.Manager.currentUser.TotalExerciseCalories;

        }
    }
}