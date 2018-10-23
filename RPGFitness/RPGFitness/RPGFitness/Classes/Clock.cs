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

        public Clock()
        {
            _today = DateTime.Today;
            _lastLogin = (DateTime)App.Manager.currentUser.LastLogin;
            //Console.WriteLine("@@@@@@@@@@@@@Before: {0}", _today.ToString());
            //_today = TimeZoneInfo.ConvertTimeToUtc(_today, TimeZoneInfo.Local);
            //_lastLogin = TimeZoneInfo.ConvertTimeFromUtc(_lastLogin, TimeZoneInfo.Local);

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
            App.Manager.currentUser.LastLogin = _today;
            App.Manager.UpdateUserAsync();
        }

    }
}
