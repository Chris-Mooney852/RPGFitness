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

        async void OnSubmitClicked(object sender, EventArgs e)
        {
            

            User newUser = new User();


            newUser.UserName = NameEntry.Text;
            newUser.UserPassword = PasswordEntry.Text;
            newUser.UserEmail = EmailEntry.Text;
            newUser.MaxDailyIntake = Convert.ToInt16(CurrentWeight.Text) * 24;
            newUser.GoalWeight = Convert.ToInt16(GoalWeight.Text);
            newUser.ConsumedCalories = 0;
            newUser.LastLogin = DateTime.Today;

            

            await App.Manager.SaveUserAsync(newUser);

            
            
        }
	}
}