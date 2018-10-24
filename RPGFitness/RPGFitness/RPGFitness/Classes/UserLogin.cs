using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace RPGFitness
{
    public class UserLogin
    {
        [PrimaryKey, Unique]
        public string Id { get; set; }
        //public string UserId { get; set; }
        public DateTime LastLogin { get; set; }


        public class Rootobject
        {
            public UserLogin[] items { get; set; }
        }
    }
}
