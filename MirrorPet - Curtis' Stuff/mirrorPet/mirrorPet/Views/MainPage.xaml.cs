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
        double calorieGoal;
        double caloriePercentage;
        String dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/savedText.txt";

        /* Loads calorieCount and calorieGoal from the text file by:
         * Getting the text from the file,
         * splitting the text into substrings,
         * converting those substrings into doubles, and applying the data.
         * 
         * Resets calorieCount if it's been a day.
         */
        public MainPage()
        {
            InitializeComponent();
            String dataText = File.ReadAllText(dataPath);
            if (dataText == null)
                SetGoalandText(2000);
            else
            {
                string[] subStrings = dataText.Split('\n');

                SetGoalandText(Convert.ToDouble(subStrings[0]));
                if (subStrings[2] == DateTime.Now.Day.ToString())
                    caloriePercentage = Convert.ToDouble(subStrings[1]);
                else
                    LocalSave(0);
                UpdateProgressBar();
                
            }
        }

        void SetGoalandText(double goal)
        {
            calorieGoal = goal;
            Goal.Text = goal.ToString();
        }

        /* Brings in new calories, makes sure it's a percentage, and applies it to the progress bar.
         * Also makes sure the text is empty after the button is pressed and saves the data.
         */
        void CaloriesEntered(object sender, EventArgs e)
        {
            Double calInput = Convert.ToDouble(CaloriesIntake.Text);
            calInput /= calorieGoal;
            caloriePercentage += calInput;
            UpdateProgressBar();

            CaloriesIntake.Text = string.Empty;

            LocalSave(caloriePercentage);
        }

        /* Calculates what the percentage of completion is.
         * and applies progress to the bar.
         */
        void UpdateProgressBar()
        {
            progressBar.ProgressTo(caloriePercentage, 900, Easing.Linear);
        }

        /* Saves data to a text file.
         */
        void LocalSave(double newPercentage)
        {
            File.WriteAllText(dataPath, 
                calorieGoal.ToString()   + '\n' + 
                newPercentage.ToString() + '\n' + 
                DateTime.Now.Day);
        }

        void SetGoal(object sender, EventArgs args)
        {
            calorieGoal = Convert.ToDouble(Goal.Text);
        }
    }
}
