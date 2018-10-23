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
            //var names = await App.Manager.ReturnAllUsersAsync();
            //App.Manager.currentUsers = names;


            currentUser = await App.Manager.ReturnUserAsync(NameEntry.Text);

          

            navManager = Data.PageNavigationManager.Instance;

            if (currentUser == null)
            {
                SuccessLabel.Text = "Username does not exist";
            }
            else
            {
                navManager = Data.PageNavigationManager.Instance;



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
