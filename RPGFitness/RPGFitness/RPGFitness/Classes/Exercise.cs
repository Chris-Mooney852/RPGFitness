using System;
using System.Collections.Generic;
using System.Text;

namespace RPGFitness
{
    public class Exercise
    {
        public int ex_ID { get; set; }
        public string ex_Name { get; set; }
        public string ex_Type { get; set; }
        public int cals_Burned { get; set; }

        public Exercise() { }
    }
}
