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
        private List<UserLogin> _lastLogin;
      
        //private UserLogin _currentUserLogin;

        public Clock()
        {         
            _today = DateTime.Today;
            
        }

        public async void GetLastUserLogin()
        {

            _lastLogin = await App.UserItemManager.GetLastLoginAsync();
           
        }

        public void ResetDailyData()
        {
            Console.WriteLine("**************************Local" + _today.ToString());
            Console.WriteLine("**************************Server" + _lastLogin.ToString());
            if (_lastLogin[_lastLogin.Count -1].LastLogin != _today)
            {
                App.Manager.currentUser.ConsumedCalories = 0;
                App.UserItemManager.currentUserLogin.LastLogin = _today;
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
