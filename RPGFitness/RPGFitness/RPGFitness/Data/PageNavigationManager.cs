﻿using System;
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

        public void ShowLoginPage()
        {
            navigation.PushAsync(new Views.LoginPage());
        }

        public void ShowRecipeContentsPage()
        {
            navigation.PushAsync(new Views.RecipePage());
        }

        public void ShowExerciseDetailPage()
        {
            navigation.PushAsync(new Views.ExerciseDetailPage());
        }

        public void ShowUserDetailPage()
        {
            navigation.PushAsync(new Views.UserDetailsPage());
        }

        public void ShowMyMealPlanPage()
        {
            navigation.PushAsync(new Views.UserMealsPage());
        }

        public void ShowCreateRecipePage()
        {
            navigation.PushAsync(new Views.CreateRecipePage());
        }

        public void ShowUserRecipeDetailPage()
        {
            navigation.PushAsync(new Views.UserMealDetailPage());
        }

        public void ShowUserExercisePage()
        {
            navigation.PushAsync(new Views.UserExercisePage());
        }
        
        public void ShowUserExerciseDetailPage()
        {
            navigation.PushAsync(new Views.UserExerciseDetailPage());
        }

       
    }
}
