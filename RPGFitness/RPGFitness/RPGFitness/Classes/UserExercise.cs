using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace RPGFitness.Classes
{
    public class UserExercise : INotifyPropertyChanged
    {

        //Declare event handler to notify view when property has changed
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, Unique]
        public string Id { get; set; }
        public string exerciseName { get; set; }
        public int totalCaloriesBurned { get; set; }
        public string exerciseType { get; set; }

        //Variable use to display total calories burned by an exercise
        private double totalExerciseCalories;

        /// <summary>
        /// This method updates the current users health and remaining calories properties so that they may be displayed
        /// on the home page and saved to the user information in the databse.
        /// </summary>
        public void CalculateCaloriesBurned()
        {
            
            App.Manager.currentUser._Health += ConvertBurnedCalories();

            UpdateUserCalories();

            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;

            
        }

        /// <summary>
        /// This method returns the total calories burned by an exercise as a fraction of the 
        /// users max daily intake so that it may be displayed by the health bar.
        /// </summary>
        /// <returns></returns>
        public double ConvertBurnedCalories()
        {
            return (double)App.UserItemManager.currentUserExercise.totalExerciseCalories / (double)App.Manager.currentUser.MaxDailyIntake;
        }

        /// <summary>
        /// This function updates the user information in the Azure database.
        /// </summary>
        public void UpdateUserCalories()
        {
            App.Manager.currentUser.ConsumedCalories -= (int)totalExerciseCalories;
            App.Manager.UpdateUserAsync();
        }

       

        // Accessor for the total exercise calories property.
        public double TotalExerciseCalories
        {
            set
            {
                if (totalExerciseCalories != value)
                {
                    totalExerciseCalories = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("TotalExerciseCalories"));
                    }
                }

            }
            get
            {
                return totalExerciseCalories;
            }
        }

    }
}
