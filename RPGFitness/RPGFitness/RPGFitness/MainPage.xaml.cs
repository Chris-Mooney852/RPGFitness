﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using RPGFitness.Data;

namespace RPGFitness
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RestService rest = new RestService();
            rest.ShowIngredients();
        }
    }
}
