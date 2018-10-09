using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness.Classes
{
    public class User
    {
        private uint userID;
        private string userName;
        private string email;
        private uint currentWeight;
        private uint goalWeight;
        private double maxDailyIntake;
        private double consumedCalories;
        private uint targetDailySteps;
        private uint currentSteps;

        public User()
        {
            maxDailyIntake = 0.5;
            this.userName = "Test";
            consumedCalories = 0;

        }

        public double MaxDailyIntake
        {
            get
            {
                return maxDailyIntake;
            }
            set
            {
                maxDailyIntake = value;
            }
        }

        public double ConsumedCalories
        {
            get
            {
                return consumedCalories;
            }
            set
            {
                consumedCalories = value;
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

        public void ReduceCalories( double amount)
        {
            maxDailyIntake -= amount;
        }
    }
}
