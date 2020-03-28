using System;
using System.Collections.Generic;
using mirrorPet.ViewModels;
using Xamarin.Forms;

namespace mirrorPet.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
