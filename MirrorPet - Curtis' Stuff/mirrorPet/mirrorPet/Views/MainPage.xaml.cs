using System;
using System.IO;
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

        public MainPage()
        {
            InitializeComponent();
            calorieCount = Convert.ToDouble(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/savedText.txt"));
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

            LocalSave();
        }

        /* Saves data to a text file.
         */
        void LocalSave()
        {
            File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) + "/savedText.txt", 
                calorieCount.ToString());
        }

        private void SetGoal(object sender, EventArgs args)
        {
            calorieGoal = Convert.ToDouble(Goal.Text);
        }
    }
}
