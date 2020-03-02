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
        double calorieGoal = 2000;
        double calorieCount;
        static Dictionary<int, object> calorieData =
              new Dictionary<int, object>();

        public MainPage()
        {
            InitializeComponent();
            calorieCount = 0;
        }

        /* Takes in the calories and applies it to the progress bar? -Curtis
         */
        private void Button_Clicked(object sender, EventArgs e)
        {
            var temp = CaloriesIntake.Text;
            Double calInput = Convert.ToDouble(temp);
            calInput /= calorieGoal;
            calorieCount += calInput;
            progressBar.ProgressTo(calorieCount, 900, Easing.Linear);
            CaloriesIntake.Text = string.Empty;

            SaveGame();
        }

        /* Save stuff.
         */
        void SaveGame()
        {
            //calorieData.Add()
        }

        private void SetGoal(object sender, EventArgs args)
        {
            calorieGoal = Convert.ToDouble(Goal.Text);
        }
    }
}
