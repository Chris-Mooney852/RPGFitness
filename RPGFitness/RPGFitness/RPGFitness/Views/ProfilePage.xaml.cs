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
	public partial class ProfilePage : ContentPage
	{
        public static Data.PageNavigationManager navigationManager { get; set; }

        public ProfilePage ()
		{

			InitializeComponent ();

		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            WeightEntry.Text = Convert.ToString(App.Manager.currentUser.CurrentWeight);
            GoalEntry.Text = Convert.ToString(App.Manager.currentUser.GoalWeight);
            CalorieEntry.Text = Convert.ToString(App.Manager.currentUser._MaxDailyIntake);

        }

        public void CalculateDailyIntake()
        {
            App.Manager.currentUser._MaxDailyIntake = Convert.ToInt16(WeightEntry.Text) * 24;
            App.Manager.UpdateUserAsync();
            Console.WriteLine("********************************DONE");
        }

        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            App.Manager.currentUser.CurrentWeight = Convert.ToInt16(WeightEntry.Text);
            App.Manager.currentUser.GoalWeight = Convert.ToInt16(GoalEntry.Text);
            App.Manager.currentUser._MaxDailyIntake = Convert.ToInt16(CalorieEntry.Text);
            App.Manager.UpdateUserAsync();

            Console.WriteLine("*****************************DONE");
        }
    }
}