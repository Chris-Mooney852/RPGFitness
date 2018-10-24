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
        public static Data.PageNavigationManager navigationManager { get; set; }

        public SignUpPage ()
		{
			InitializeComponent ();
            

            
        }

        public void OnNextClicked(object sender, EventArgs e)
        {
            

            App.Manager.newUser.UserName = NameEntry.Text;
            App.Manager.newUser.UserPassword = PasswordEntry.Text;
            App.Manager.newUser.UserEmail = EmailEntry.Text;
            
            
            App.Manager.newUser.ConsumedCalories = 0;
            App.Manager.newUser.LastLogin = DateTime.Today;
            

            navigationManager = Data.PageNavigationManager.Instance;
            navigationManager.ShowUserDetailPage();


        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameEntry.Text != null && PasswordEntry.Text != null && EmailEntry.Text != null)
            {
                NextButton.IsEnabled = true;
            }
        }
    }
}