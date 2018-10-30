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

            App.UserItemManager.currentUserExercise.CalculateCaloriesBurned();
            
            await Navigation.PopAsync();
        }

        private void ExerciseLength_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                App.UserItemManager.currentUserExercise.TotalExerciseCalories = Convert.ToDouble(ExerciseLength.Text) * (App.UserItemManager.currentUserExercise.totalCaloriesBurned / 10);
            }
            catch(Exception)
            {

            } 
          
        }
    }
}