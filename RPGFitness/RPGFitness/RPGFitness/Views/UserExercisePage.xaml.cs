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
	public partial class UserExercisePage : ContentPage
	{
        public static Data.PageNavigationManager navigationManager { get; set; }

        public UserExercisePage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.UserItemManager.GetUserExerciseAsync();

        }

       

        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            navigationManager = Data.PageNavigationManager.Instance;
            App.UserItemManager.currentUserExercise = e.SelectedItem as UserExercise;
            App.Manager.exerciseItem = e.SelectedItem as Exercise;
            App.Manager.totalBurnedCalories = 0;
            App.Manager.currentUser.TotalExerciseCalories = 0;
            navigationManager.ShowUserExerciseDetailPage();
        }
    }
}