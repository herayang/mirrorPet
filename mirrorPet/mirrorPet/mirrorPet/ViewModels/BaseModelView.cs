using System;

using Xamarin.Forms;

namespace mirrorPet.ViewModels
{
    public class BaseModelView : ContentPage
    {
        public BaseModelView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

