using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using mirrorPet.Models;
using Xamarin.Forms;

namespace mirrorPet.ViewModels
{

    public class MainViewModel : BaseViewModel
    {

        public Goal Goal { get; set; }

        //public Pet Pet { get; set; }

        int _goalId;
        public int GoalId
        {
            get
            {
                return _goalId;
            }
            set
            {
                _goalId = value;
                OnPropertyChanged();
            }
        }


        string _goalName = "Lose Weight Fatty";
        public string GoalName
        {
            get
            {
                return _goalName;
            }
            set
            {
                _goalName = value;
                OnPropertyChanged();
            }
        }

        double _goalTarget = 2000;
        public double GoalTarget
        {
            get
            {
                return _goalTarget;
            }
            set
            {
                _goalTarget = value;
                OnPropertyChanged();
            }
        }


        string _petId = "2";
        public string PetId
        {
            get
            {
                return _petId;
            }
            set
            {
                _petId = value;
                OnPropertyChanged();
            }
        }


        string _petName = "JuJu";
        public string PetName
        {
            get
            {
                return _petName;
            }
            set
            {
                _petName = value;
                OnPropertyChanged();
            }
        }


        string petImageUrl = $"2.ok.png";
        public string PetImageUrl
        {
      
            get
            {
                return petImageUrl;
            }
            set
            {
                if (petImageUrl != value)
                {
                    petImageUrl = value;
                    OnPropertyChanged(nameof(ProgressInput));
                    OnPropertyChanged(nameof(Comments));
                    OnPropertyChanged(nameof(PetImageUrl));
                }
            }
        }

        string progressInput = String.Empty;
        public string ProgressInput
        {
            get => progressInput;

            set
            {
                if (progressInput != value)
                {
                    progressInput = value;
                    OnPropertyChanged(nameof(ProgressInput));
                    OnPropertyChanged(nameof(Comments));
                    OnPropertyChanged(nameof(PetImageUrl));
                    OnPropertyChanged(nameof(Test));
                    OnPropertyChanged(nameof(GoalSum));
                    OnPropertyChanged(nameof(GoalPercentage));
                    OnPropertyChanged(nameof(GoalPercentageProgressBar));

                }
                
            }
        }


        private double _goalSum;
        public double GoalSum
        {
            get => _goalSum;

            set
            {
                _goalSum = value;
                OnPropertyChanged(nameof(GoalSum));
                OnPropertyChanged(nameof(GoalPercentage));
                OnPropertyChanged(nameof(ProgressInput));
                OnPropertyChanged(nameof(GoalPercentageProgressBar));
                OnPropertyChanged(nameof(Test));
                ;

            }
        }

        private double _goalPercentage;
        public double GoalPercentage
        {
            get => _goalPercentage;

            set
            {
                _goalPercentage = value;
                OnPropertyChanged(nameof(GoalSum));
                OnPropertyChanged(nameof(GoalPercentage));
                OnPropertyChanged(nameof(ProgressInput));
                OnPropertyChanged(nameof(PetImageUrl));
                OnPropertyChanged(nameof(Test));
                ;

            }
        }

        private double _goalPercentageProgressBar;
        public double GoalPercentageProgressBar
        {
            get => _goalPercentageProgressBar;

            set
            {
                _goalPercentageProgressBar = value;
                OnPropertyChanged(nameof(GoalSum));
                OnPropertyChanged(nameof(GoalPercentage));
                OnPropertyChanged(nameof(GoalPercentageProgressBar));
                OnPropertyChanged(nameof(ProgressInput));
                OnPropertyChanged(nameof(PetImageUrl));
                OnPropertyChanged(nameof(Test));
                ;

            }
        }

        // method called by command that tallies percentage total
        void GetPercentage(string ProgressInput)
        {
           try
            {
                if (ProgressInput != null || ProgressInput != "" || ProgressInput != String.Empty)
                {
                    _goalSum += Convert.ToDouble(ProgressInput);
                    _goalPercentageProgressBar = _goalSum / _goalTarget;
                    _goalPercentage = (_goalSum / _goalTarget) * 100;
                    this.ProgressInput = "";
                    Comments = "";
                    
                }
                else

                    Comments = "You must enter a valid value";
                

            }
            catch
            {
                Comments = "You must enter a valid value";
            }

        }


        // method called by command that changes images based off percentage completed
        void SetImage(double GoalPercentage)
        {

            try
            {
                if (GoalPercentage != 0)
                {
                    if (GoalPercentage <= 95)

      
                    {
                        PetImageUrl = $"{PetId}.below.png";
                        Comments = "Close but no cigar, time to regroup and try again tomorrow!";


                    }
                    else if (GoalPercentage <= 105)
                    {
                        PetImageUrl = $"{PetId}.ok.png";
                        Comments = "Great job, you met your goal! Keep up the good work!";

                    }
                    else
                    {
                        PetImageUrl = $"{PetId}.over.png";
                        Comments = "Easy turbo, try to stay on target. Better luck next time!";

                    }

                }
            } catch
            {
                Comments = "You must enter a valid value";
            }
            
        }


        string comments = string.Empty;
        public string Comments
        {
            get => comments;

            set
            {
                comments = value;
                OnPropertyChanged(nameof(Comments));
                OnPropertyChanged(nameof(ProgressInput));
                OnPropertyChanged(nameof(PetImageUrl));

            }
        }



        public string Test => $"Total = {GoalPercentage}";


     


        ICommand submitProgressCommand;
        public ICommand SubmitProgressCommand => submitProgressCommand ?? (submitProgressCommand = new Command<string>(GetPercentage));


        ICommand finishDayCommand;
        public ICommand FinishDayCommand => finishDayCommand ?? (finishDayCommand = new Command<double>(SetImage));






        // Curtis's code

        //// Learn more about making custom code visible in the Xamarin.Forms previewer
        //// by visiting https://aka.ms/xamarinforms-previewer
        //[DesignTimeVisible(false)]
        //public partial class MainPage : ContentPage
        //{
        //    double calorieGoal = 1;
        //    double caloriePercentage;
        //    String dataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/savedText.txt";

        //    /* Loads calorieCount and calorieGoal from the text file by:
        //     * Getting the text from the file,
        //     * splitting the text into substrings,
        //     * converting those substrings into doubles, and applying the data.
        //     * 
        //     * Resets calorieCount if it's been a day.
        //     */
        //    public MainPage()
        //    {
        //        InitializeComponent();
        //        try
        //        {
        //            String dataText = File.ReadAllText(dataPath);

        //            string[] subStrings = dataText.Split('\n');
        //            SetGoalandText(Convert.ToDouble(subStrings[0]));

        //            if (subStrings[2] == DateTime.Now.Day.ToString())
        //                caloriePercentage = Convert.ToDouble(subStrings[1]);
        //            else
        //                LocalSave(0);
        //            UpdateProgressBar();
        //        }
        //        catch
        //        {
        //            OnAppearing();
        //            LocalSave(2);
        //        }
        //    }

        //    void SetGoalandText(double goal)
        //    {
        //        calorieGoal = goal;
        //        Goal.Text = goal.ToString();
        //    }

        //    /* Brings in new calories, makes sure it's a percentage, and applies it to the progress bar.
        //     * Also makes sure the text is empty after the button is pressed and saves the data.
        //     */
        //    void CaloriesEntered(object sender, EventArgs e)
        //    {
        //        Double calInput = Convert.ToDouble(CaloriesIntake.Text);
        //        calInput /= calorieGoal;
        //        caloriePercentage += calInput;
        //        UpdateProgressBar();

        //        CaloriesIntake.Text = string.Empty;

        //        LocalSave(caloriePercentage);
        //    }

        //    /* Calculates what the percentage of completion is.
        //     * and applies progress to the bar.
        //     */
        //    void UpdateProgressBar()
        //    {
        //        progressBar.ProgressTo(caloriePercentage, 900, Easing.Linear);
        //    }

        //    /* Saves data to a text file.
        //     */
        //    void LocalSave(double newPercentage)
        //    {
        //        File.WriteAllText(dataPath,
        //            calorieGoal.ToString() + '\n' +
        //            newPercentage.ToString() + '\n' +
        //            DateTime.Now.Day);
        //    }

        //    void SetGoal(object sender, EventArgs args)
        //    {
        //        calorieGoal = Convert.ToDouble(Goal.Text);
        //        SetGoalandText(Convert.ToDouble(Goal.Text));
        //        OnAppearing();
        //    }

        //    /* If the goal has not been set or is too small make the player enter a goal.
        //     */
        //    protected override void OnAppearing()
        //    {
        //        base.OnAppearing();

        //        Device.BeginInvokeOnMainThread(async () =>
        //        {
        //            if (calorieGoal < 10)
        //            {

        //                await System.Threading.Tasks.Task.Delay(250);
        //                Goal.Focus();
        //            }
        //        });
        //    }

        //    //private void Advance_Button(object sender, EventArgs args)
        //    //{
        //    //    Goal.Text = "1337";
        //    //}
        //}

    }
}




