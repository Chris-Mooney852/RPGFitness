using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using RPGFitness.Data;
<<<<<<< HEAD
=======
using RPGFitness.Views;
>>>>>>> master

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGFitness
{
    public partial class App : Application
    {
<<<<<<< HEAD
        //public static Ingredient Ingredient { get; private set; }
=======
        
        public static ItemManager Manager { get; private set; }

        private ContentPage mainPage;

>>>>>>> master

        public App()
        {
            InitializeComponent();
            Manager = new ItemManager(new RestService());

            //Make the app a navigation based app
            mainPage = new LoginPage();
            MainPage = new NavigationPage(mainPage);

            //Assign a navigation object to the pageNavigationManager
            PageNavigationManager.Instance.Navigation = MainPage.Navigation;

<<<<<<< HEAD
            MainPage = new MainPage();     

=======
>>>>>>> master
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
