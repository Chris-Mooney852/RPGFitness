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
	public partial class LoginPage : ContentPage
	{
        public List<User> allUsers;

		public LoginPage ()
		{
			InitializeComponent ();
            
            
            
        }

        public async void OnLoginClicked(object sender, EventArgs e)
        {
            var names = await App.Manager.ReturnAllUsersAsync();
            App.Manager.currentUsers = names;

            List<User> allUsers = await App.Manager.ReturnAllUsersAsync();

            bool loginSuccess = false;

            foreach (User user in allUsers)
            {
                if ( user.UserName == NameEntry.Text && user.UserPassword == PasswordEntry.Text)
                {
                    //await Navigation.PushAsync(new MainPage());
                    loginSuccess = true;
                    break;
                }
                else
                {
                    loginSuccess = false;
                }
            }
            if (loginSuccess == true)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                SuccessLabel.Text = "Invalid Username or Password!";
            }
        }

    }
}