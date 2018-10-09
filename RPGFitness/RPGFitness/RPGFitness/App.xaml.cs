using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using RPGFitness.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGFitness
{
    public partial class App : Application
    {
        //public static Ingredient Ingredient { get; private set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();     

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
