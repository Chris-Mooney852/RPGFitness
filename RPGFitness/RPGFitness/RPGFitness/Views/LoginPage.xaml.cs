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
        public List<User> allUsers;

        public static Data.PageNavigationManager navManager { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();


        }

        public void OnLoginClicked(object sender, EventArgs e)
        {
            //var names = await App.Manager.ReturnAllUsersAsync();
            //App.Manager.currentUsers = names;

            //Create a list of all the users in the database
            //List<User> allUsers = await App.Manager.ReturnAllUsersAsync();

            navManager = Data.PageNavigationManager.Instance;

            bool loginSuccess = false;

            //Look at each user in the database and determin if the username and password match

            foreach (User user in allUsers)
            {
                if ( user.UserName == NameEntry.Text && user.UserPassword == PasswordEntry.Text)
                {

                    loginSuccess = true;

                    //Set the apps current user to the user that matches
                    Console.WriteLine("**************************before assignment");
                    App.Manager.currentUser = user;
                    Console.WriteLine("**************************after assignment");
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
