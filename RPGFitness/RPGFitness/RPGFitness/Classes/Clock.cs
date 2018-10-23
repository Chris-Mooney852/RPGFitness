using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using RPGFitness.Data;

namespace RPGFitness
{
    public class Clock
    {
        private readonly DateTime _today;
        private DateTime _lastLogin;
        private string _currentUserId;
        private UserLogin _currentUserLogin;

        public Clock()
        {
            _currentUserId = App.Manager.currentUser.UserEmail;

            _today = DateTime.Today;
           

        }

        public async void GetLastUserLogin()
        {
            _currentUserLogin =  await App.UserItemManager.GetLastLoginAsync(_currentUserId);
            _lastLogin = _currentUserLogin.LastLogin;
        }

        public void ResetDailyData()
        {
            Console.WriteLine("**************************Local" + _today.ToString());
            Console.WriteLine("**************************Server" + _lastLogin.ToString());
            if (_lastLogin != _today)
            {
                App.Manager.currentUser.ConsumedCalories = 0;
                UpdateLastLogin();
               
            }
        }

        public void UpdateLastLogin()
        {
            App.UserItemManager.currentUserLogin.LastLogin = _today;

            App.UserItemManager.SaveUserLoginAsync(App.UserItemManager.currentUserLogin);
        }

    }
}
