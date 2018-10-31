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

        /// <summary>
        /// Creates a new clock with todays date, also fetches the last login date from the server
        /// </summary>
        public Clock()
        {
            _today = DateTime.Today;
            _lastLogin = (DateTime)App.Manager.currentUser.LastLogin;
            //Console.WriteLine("@@@@@@@@@@@@@Before: {0}", _today.ToString());
            //_today = TimeZoneInfo.ConvertTimeToUtc(_today, TimeZoneInfo.Local);
            //_lastLogin = TimeZoneInfo.ConvertTimeToUtc(_lastLogin, TimeZoneInfo.c);

        }

        /// <summary>
        /// Resets the users data if its a new day since the last login
        /// </summary>
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

        /// <summary>
        /// Updates the users last login to today
        /// </summary>
        public void UpdateLastLogin()
        {
            App.Manager.currentUser.LastLogin = _today;
            App.Manager.UpdateUserAsync();
        }

    }
}
