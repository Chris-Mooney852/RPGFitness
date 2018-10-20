using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;

namespace RPGFitness.Views
{
    public class ViewModel
    {
        private Data.PageNavigationManager navManager;

        public ICommand SignUPageClickCommand { protected set; get; }

        public ICommand MainPageClickCommand { protected set; get; }

        public ICommand LoginPageClickCommand { protected set; get; }

        public ICommand ProfilePageCLickCommand { protected set; get; }

        

        public ViewModel()
        {
            navManager = Data.PageNavigationManager.Instance;
            SignUPageClickCommand = new Command(() =>
            {
                navManager.ShowSignUpPage();
            });

            MainPageClickCommand = new Command(() =>
            {
                navManager.ShowMainPage();
            });

            LoginPageClickCommand = new Command(() =>
            {
                navManager.ShowLoginPage();
            });

            ProfilePageCLickCommand = new Command(() =>
            {
                navManager.ShowProfilePage();
            });
        }
    }
}
