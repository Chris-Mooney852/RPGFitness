using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public partial class ExercisePage : ContentPage
	{
        public static Data.PageNavigationManager navigationManager { get; set; }

        public ExercisePage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            ExerciseList.ItemsSource = await App.Manager.ReturnExercises();


        }

        void OnExerciseSelected(object sender, SelectedItemChangedEventArgs e)
        {
            navigationManager = Data.PageNavigationManager.Instance;
            //App.Manager.exerciseItem = e.SelectedItem as Exercise;
        }
    }
}