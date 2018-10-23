using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using RPGFitness.Data;
using RPGFitness.Views;
using System.Collections.Generic;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGFitness
{
    public partial class App : Application
    {        

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserSQLite.db3");

        //create item manger for web API
        public static ItemManager Manager { get; private set; }

        //create item manager for local sql
        public static LocalItemManager UserItemManager { get; set; }

        private ContentPage mainPage;

        public static PageNavigationManager navManager { get; set; }

        public static ViewModel viewModel { get; set; }

      


        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY0NzZAMzEzNjJlMzMyZTMwSDhWM1pMTUJNOFM1SnRYSmYwbjlmUzA5MmlLdDF6SERtSjVLL0s3alIwZz0=");

            InitializeComponent();
            Manager = new ItemManager(new RestService());

            UserItemManager = new LocalItemManager(new DBService(dbPath));




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
