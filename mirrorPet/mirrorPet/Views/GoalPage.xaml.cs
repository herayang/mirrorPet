using System;
using System.Collections.Generic;
using mirrorPet.ViewModels;
using Xamarin.Forms;

namespace mirrorPet.Views
{
    public partial class GoalPage : ContentPage
    {

        
        public GoalPage()
        {
            InitializeComponent();
            BindingContext = new GoalViewModel();
        }
    }
}
