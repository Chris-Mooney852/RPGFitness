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
	public partial class UserDetailsPage : ContentPage
	{
        public static Data.PageNavigationManager navigationManager { get; set; }

        public UserDetailsPage ()
		{
			InitializeComponent ();
		}

        public async void OnSubmitClicked(object sender, EventArgs e)
        {
            try
            {
                App.Manager.newUser.CurrentWeight = Convert.ToInt16(CurrentWeight.Text);
                App.Manager.newUser.GoalWeight = Convert.ToInt16(GoalWeight.Text);
                App.Manager.newUser.MaxDailyIntake = App.Manager.newUser.CurrentWeight * 24;

                await App.Manager.SaveUserAsync(App.Manager.newUser);

                navigationManager = Data.PageNavigationManager.Instance;
                navigationManager.ShowLoginPage();

            }
            catch (FormatException)
            {
                ErrorLabel.Text = "Please enter a number";
            }
                      
            

           

          

        }

        public void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CurrentWeight.Text != null && GoalWeight.Text != null)
            {
                SubmitButton.IsEnabled = true;
            }
        }
    }
}