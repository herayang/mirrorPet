using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mirrorPet
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        double calorieGoal = 1;
        double calorieCount;
        public MainPage()
        {
            InitializeComponent();
            calorieCount = 0;
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            var temp = CaloriesIntake.Text;
            Double calInput = Convert.ToDouble(temp);
            calInput /= calorieGoal;
            calorieCount += calInput;
            progressBar.ProgressTo(calorieCount, 900, Easing.Linear);
            CaloriesIntake.Text = string.Empty;
        }

        private void SetGoal(object sender, EventArgs args)
        {
            calorieGoal = Convert.ToDouble(Goal.Text);
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (calorieGoal < 10)
                {
                    await System.Threading.Tasks.Task.Delay(250);
                    Goal.Focus();
                }
            });
        }
    }
}
