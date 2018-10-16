﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using RPGFitness.Data;
using RPGFitness.Views;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RPGFitness
{
    public partial class App : Application
    {
        public static ItemManager Manager { get; private set; }

        private ContentPage mainPage;

        public static PageNavigationManager navManager { get; set; }

        public static ViewModel viewModel { get; set; }

        //public List<User> allUsers { get; set; }


        public App()
        {
            InitializeComponent();
            Manager = new ItemManager(new RestService());

            //allUsers = Manager.currentUsers;


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
