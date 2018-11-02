using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RPGFitness.Data;

namespace RPGFitness.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public User currentUser;

        public static PageNavigationManager navManager { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();
        }

        public  async void OnLoginClicked(object sender, EventArgs e)
        {
            //Set the current user to the user that matches the name entered
            currentUser = await App.Manager.ReturnUserAsync(NameEntry.Text);

            navManager = PageNavigationManager.Instance;

            //If the user is not found in the database, display a message to the user
            if (currentUser == null)
            {
                SuccessLabel.Text = "Username does not exist";
            }
            else
            {
                //Check the username and password in the databse
                if (currentUser.UserName == NameEntry.Text && currentUser.UserPassword == PasswordEntry.Text)
                {
                    App.Manager.currentUser = currentUser;

                    navManager.ShowMainPage();
                    
                }
                else
                {
                    SuccessLabel.Text = "Invalid Username or Password!";
                }
            }





        }
    }
}
