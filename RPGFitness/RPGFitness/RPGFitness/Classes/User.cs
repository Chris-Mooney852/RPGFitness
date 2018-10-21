using RPGFitness.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RPGFitness
{
    public class User : INotifyPropertyChanged

    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public Nullable<int> CurrentWeight { get; set; }
        public Nullable<int> GoalWeight { get; set; }
        public Nullable<int> MaxDailyIntake { get; set; }
        public Nullable<int> ConsumedCalories { get; set; }
        public Nullable<int> TargetDailySteps { get; set; }
        public Nullable<int> CurrentSteps { get; set; }
        public Nullable<DateTime> LastLogin { get; set; }
        private double Health;
        private double remainingCalories;

        public event PropertyChangedEventHandler PropertyChanged;



        public User() {
            
        }

        public User(int id, string name, string password, string email)
        {
            UserID = id;
            UserName = name;
            UserPassword = password;
            UserEmail = email;
        }

        public User (string name, string password, string email)
        {
            UserName = name;
            UserPassword = password;
            UserEmail = email;
        }

        public double _Health
        {

            set
            {
                if (Health != value)
                {
                    Health = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("_Health"));
                    }
                }
                
            }
            get
            {
                return Health;
            }
        }

        public double RemainingCalories
        {
            set
            {
                if (remainingCalories != value)
                {
                    remainingCalories = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("RemainingCalories"));
                    }
                }

            }
            get
            {
                return remainingCalories;
            }
        }

        public uint CalculateCaloriesLeft()
        {
            throw new NotImplementedException();
        }

        public uint CalculateCurrentSteps()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {

            return String.Format("ID: {0} Name: {1} Email: {2} LastLogin: {3}", UserID, UserName, UserEmail, LastLogin);

        }
    }
}
