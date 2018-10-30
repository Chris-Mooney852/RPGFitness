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
	public partial class SignUpPage : ContentPage
	{
        

        public SignUpPage ()
		{
			InitializeComponent ();
                       
        }

        /// <summary>
        /// Assign the data entered to the properties of the newUser object before
        /// moving to the next page of the sign up process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnNextClicked(object sender, EventArgs e)
        {
            
            App.Manager.newUser.UserName = NameEntry.Text;
            App.Manager.newUser.UserPassword = PasswordEntry.Text;
            App.Manager.newUser.UserEmail = EmailEntry.Text;                      
            App.Manager.newUser.ConsumedCalories = 0;
            App.Manager.newUser.LastLogin = DateTime.Today;
                      
            App.navigationManager.ShowUserDetailPage();

        }

        /// <summary>
        /// Ensure that all the entry boxes have a value before enabling the next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameEntry.Text != null && PasswordEntry.Text != null && EmailEntry.Text != null)
            {
                NextButton.IsEnabled = true;
            }
        }
    }
}