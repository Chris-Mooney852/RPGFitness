using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness.Classes
{
    class User
    {
        private uint userID;
        private string userName;
        private string email;
        private uint currentWeight;
        private uint goalWeight;
        private uint maxDailyIntake;
        private uint consumedCalories;
        private uint targetDailySteps;
        private uint currentSteps;

        public User()
        {

        }

        public uint CalculateCaloriesLeft()
        {
            throw new NotImplementedException();
        }

        public uint CalculateCurrentSteps()
        {
            throw new NotImplementedException();
        }
    }
}
