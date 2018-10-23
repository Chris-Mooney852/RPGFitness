using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RPGFitness.Classes
{
    public class UserExercise
    {
           [PrimaryKey, Unique]
            public string Id { get; set; }
            public string exerciseName { get; set; }
            public int totalCaloriesBurned { get; set; }
            public string exerciseType { get; set; }
        

        public class Rootobject
        {
            public UserExercise[] items { get; set; }
        }
           
    }
}
