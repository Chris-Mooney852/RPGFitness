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

        public async void OnAddClicked(object sender, EventArgs e)
        {
            App.UserItemManager.currentUserExercise.Id = null;
            App.UserItemManager.currentUserExercise.exerciseName = App.Manager.exerciseItem.ex_Name;
            App.UserItemManager.currentUserExercise.totalCaloriesBurned = App.Manager.exerciseItem.cals_Burned;
            App.UserItemManager.currentUserExercise.exerciseType = App.Manager.exerciseItem.ex_Type;

            await App.UserItemManager.SaveUserExerciseAsync(App.UserItemManager.currentUserExercise);

            
            App.navigationManager.ShowMainPage();


        }
    }
}