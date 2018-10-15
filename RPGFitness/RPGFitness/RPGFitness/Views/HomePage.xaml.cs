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
	public partial class HomePage : ContentPage
	{
        //public double remainingHealth = (double)App.Manager.currentUser.MaxDailyIntake / 2000;

		public HomePage ()
		{
			InitializeComponent ();


            //Bind the Name Label to the current user
            NameLabel.BindingContext = App.Manager.currentUser;

            //Assign the remaing user health to the users health and convert to a percentage.
            App.Manager.currentUser.Health = ((double)App.Manager.currentUser.MaxDailyIntake - 
                (double)App.Manager.currentUser.ConsumedCalories) / (double)App.Manager.currentUser.MaxDailyIntake;

            //Bind the health bar to the current user.
            UserHealth.BindingContext = App.Manager.currentUser;

         
		}

        public async void OnEatClicked(object sender, EventArgs e)
        {
             App.Manager.currentUser.Health -= 0.1;
            Console.WriteLine("**************** current user health: {0}", App.Manager.currentUser.Health);
        }
	}
}