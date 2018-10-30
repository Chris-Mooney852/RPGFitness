using RPGFitness.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RPGFitness
{
    public class User : INotifyPropertyChanged

    {
        //Declare variables of the user class

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

        //Variables used to display users remaining calories
        private double Health;
        private double remainingCalories;

        //Declare event handler to notify view when property has changed
        public event PropertyChangedEventHandler PropertyChanged;


        //Construcor for user
        public User() {
            
        }

       
        //Accessors for user private properties
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

        

        /// <summary>
        /// This method calculates the current users remaining calories by setting the item manager
        /// property TotalCalories to the value of the current user recipies total calories.
        /// The method then sets the value of the current users health property using the item manager method 
        /// CalculateTotalCalories.  Finally the method sets the value of the currentUser RemainingCalories property
        /// based on the currentUser health.
        /// </summary>
        public void CalculateCaloriesLeft()
        {
            App.Manager.mealItem.TotalCalories = App.UserItemManager.currentUserrecipe.totCalories;

            App.Manager.currentUser._Health -= App.Manager.CalculateTotalCalories();

            App.Manager.currentUser.RemainingCalories = App.Manager.currentUser._Health * (double)App.Manager.currentUser.MaxDailyIntake;

            
        }


        /// <summary>
        /// Feature to be implemented in future releases
        /// </summary>
        /// <returns></returns>
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
