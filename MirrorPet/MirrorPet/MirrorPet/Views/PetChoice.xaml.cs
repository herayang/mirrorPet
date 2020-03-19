using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mirrorPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PetChoice : ContentPage
    {
        public PetChoice()
        {
            InitializeComponent();

        }

        //This is the base class for the pet choices
        public class PetChoices
        {
            public string ImageUrl { get; set; } 
            public string PetId { get; set; }
        }
        //This is the class that puts the pets into a list. Add to this to make new Pets
        public class Pets
        {
            public static IEnumerable<PetChoices> Get()
            {
                return new List<PetChoices>
                {
                    new PetChoices() {PetId="01", ImageUrl="Holdkun_Default.png"}
                };
            }
        }

        //This overrides OnAppearing so that it can get the list of pets ready when you get to this page
        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<PetChoices> AllPets = new List<PetChoices>(Pets.Get());
            PetView.ItemsSource = AllPets;
        }

        //The code to run when the button is clicked. Will change the goal and go back to the main page
        async void CompletePage(object sender, EventArgs args)
        {
            if (Goal.Text != null)
            {
                App.calorieGoal = Convert.ToDouble(Goal.Text);
                await Navigation.PopModalAsync();
            }
        }
    }
}