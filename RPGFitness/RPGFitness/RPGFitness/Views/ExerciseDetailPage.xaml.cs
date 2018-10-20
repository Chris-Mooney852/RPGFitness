using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RPGFitness.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        public ExerciseDetailPage()
        {
            InitializeComponent();

            ExerciseName.BindingContext = App.Manager.exerciseItem;
            ExerciseType.BindingContext = App.Manager.exerciseItem;
            CaloriesBurned.BindingContext = App.Manager.exerciseItem;
        }
    }
}