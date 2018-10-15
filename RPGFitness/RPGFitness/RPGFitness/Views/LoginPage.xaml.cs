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

        public static Data.PageNavigationManager navManager { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();
            
            
        }

        public async void OnLoginClicked(object sender, EventArgs e)
        {
            //var names = await App.Manager.ReturnAllUsersAsync();
            //App.Manager.currentUsers = names;

            //Create a list of all the users in the database
            List<User> allUsers = await App.Manager.ReturnAllUsersAsync();

            navManager = Data.PageNavigationManager.Instance;
            

            bool loginSuccess = false;

            //Look at each user in the database and determin if the username and password match
           
            foreach (User user in allUsers)
            {
                if ( user.UserName == NameEntry.Text && user.UserPassword == PasswordEntry.Text)
                {
                    
                    loginSuccess = true;
                    
                    //Set the apps current user to the user that matches
                    App.Manager.currentUser = user;
                    break;
                }
                else
                {
                    loginSuccess = false;
                }
            }
            if (loginSuccess == true)
            {

                navManager.ShowMainPage();
            }
            else
            {
                SuccessLabel.Text = "Invalid Username or Password!";
            }
        }

    }
}