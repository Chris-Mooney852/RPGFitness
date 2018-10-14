using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RPGFitness.Data
{
    public class PageNavigationManager
    {
        private static PageNavigationManager instance;

        private INavigation navigation;

        private PageNavigationManager() { }

        public static PageNavigationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageNavigationManager();
                }
                return instance;
            }
        }

        public INavigation Navigation
        {
            set { navigation = value; }
        }

        public void ShowSignUpPage()
        {
            navigation.PushAsync(new Views.SignUpPage());
        }

        public void ShowMainPage()
        {
            navigation.PushAsync(new MainPage());
        }
    }
}
