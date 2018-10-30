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
        

        public UserExercisePage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //List the current users exercises stored in the SqLite database
            listView.ItemsSource = await App.UserItemManager.GetUserExerciseAsync();

        }

       

        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            //Set the currently selected item to the UserItemManagers currentUserExercise property.
            App.UserItemManager.currentUserExercise = e.SelectedItem as UserExercise;
                       
            App.navigationManager.ShowUserExerciseDetailPage();
        }
    }
}