using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using RPGFitness.Data;
using RPGFitness.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGFitness
{
    public partial class App : Application
    {

        public static ItemManager Manager { get; private set; }

        private ContentPage mainPage;


        public App()
        {
            InitializeComponent();
            Manager = new ItemManager(new RestService());

            //Make the app a navigation based app
            mainPage = new LoginPage();
            MainPage = new NavigationPage(mainPage);

            //Assign a navigation object to the pageNavigationManager
            PageNavigationManager.Instance.Navigation = MainPage.Navigation;

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
