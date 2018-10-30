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
        

        public UserDetailsPage ()
		{
			InitializeComponent ();
		}

        /// <summary>
        /// Save the newUser information to the Azure database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnSubmitClicked(object sender, EventArgs e)
        {
            //Ensure that the information entered is in the correct form.
            try
            {
                App.Manager.newUser.CurrentWeight = Convert.ToInt16(CurrentWeight.Text);
                App.Manager.newUser.GoalWeight = Convert.ToInt16(GoalWeight.Text);

                //Calculate the max daily intake based on the users current weight.
                App.Manager.newUser.MaxDailyIntake = App.Manager.newUser.CurrentWeight * 24;

                //Save the new user to the database
                await App.Manager.SaveUserAsync(App.Manager.newUser);

                //Return to the login page.
                App.navigationManager.ShowLoginPage();

            }
            //If the information entered is not in the correct format, display a message to the user.
            catch (FormatException)
            {
                ErrorLabel.Text = "Please enter a number";
            }
                      
        }
        /// <summary>
        /// Ensure that all needed information is entered before enabling the submit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CurrentWeight.Text != null && GoalWeight.Text != null)
            {
                SubmitButton.IsEnabled = true;
            }
        }
    }
}