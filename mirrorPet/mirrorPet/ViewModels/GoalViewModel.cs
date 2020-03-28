using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using mirrorPet.Models;
using mirrorPet.Views;
using Xamarin.Forms;

namespace mirrorPet.ViewModels
{
    public class GoalViewModel : BaseViewModel
    {

        public ObservableCollection<Pet> Pets { get; set; }
        public Command LoadPetsCommand { get; set; }


    public GoalViewModel()
        {
            Title = "Choose Pet";
            Pets = new ObservableCollection<Pet>();
            LoadPetsCommand = new Command(async () => await ExecuteLoadPetsCommand());

        }

        async Task ExecuteLoadPetsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Pets.Clear();
                var pets = await PetDataStore.GetPetsAsync();
                foreach (var pet in pets)
                {
                    Pets.Add(pet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public Goal Goal { get; set; }

        public Pet Pet { get; set; }



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


        string _goalName = String.Empty;
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

        double _goalTarget = 0;
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


        string _petId;
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


        string _petName = String.Empty;
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

        ICommand saveGoalCommand;
        public ICommand SaveGoalCommand => saveGoalCommand ?? (saveGoalCommand = new Command<Goal>(SaveGoal));


        public void SaveGoal(Goal goal)
        {

            Application.Current.MainPage = new NavigationPage(new MainPage());

            //TODO: save button saves goal object to mock datastore and sends goal to MainViewModel to display accordingly the
            //horizontal scrollable view show the pet option. User selects Pet and Pet properties are transferred to Goal object
        }

        //Tim's code

    //    //This is the base class for the pet choices
    //    public class PetChoices
    //    {
    //        public string ImageUrl { get; set; }
    //        public string PetId { get; set; }
    //    }
    //    //This is the class that puts the pets into a list. Add to this to make new Pets
    //    public class Pets
    //    {
    //        public static IEnumerable<PetChoices> Get()
    //        {
    //            return new List<PetChoices>
    //            {
    //                new PetChoices() {PetId="01", ImageUrl="Holdkun_Default.png"}
    //            };
    //        }
    //    }

    //    //This overrides OnAppearing so that it can get the list of pets ready when you get to this page
    //    protected override void OnAppearing()
    //    {
    //        base.OnAppearing();

    //        List<PetChoices> AllPets = new List<PetChoices>(Pets.Get());
    //        PetView.ItemsSource = AllPets;
    //    }

    //    //The code to run when the button is clicked. Will change the goal and go back to the main page
    //    async void CompletePage(object sender, EventArgs args)
    //    {
    //        if (Goal.Text != null)
    //        {
    //            App.calorieGoal = Convert.ToDouble(Goal.Text);
    //            await Navigation.PopModalAsync();
    //        }
    //    }
    //}
}
}
