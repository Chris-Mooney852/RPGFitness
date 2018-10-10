using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness
{
    public class User
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

        public User(int id, string name, string password, string email)
        {
            UserID = id;
            UserName = name;
            UserPassword = password;
            UserEmail = email;
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

            return String.Format("ID: {0} Name: {1} Email: {2}", UserID, UserName, UserEmail);

        }
    }
}
