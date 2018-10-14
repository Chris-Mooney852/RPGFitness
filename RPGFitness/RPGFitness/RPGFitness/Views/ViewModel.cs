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

        public ICommand SignUpPageClickCommand { protected set; get; }

        public ICommand MainPageClickCommand { protected set; get; }

        public ViewModel()
        {
            navManager = Data.PageNavigationManager.Instance;
            SignUpPageClickCommand = new Command(() =>
            {
                navManager.ShowSignUpPage();
            });

            MainPageClickCommand = new Command(() =>
            {
                navManager.ShowMainPage();
            });
        }
    }
}
