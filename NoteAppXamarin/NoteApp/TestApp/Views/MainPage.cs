using System;
using System.Collections.Generic;
using System.Text;
using TestApp.ViewModels;
using Xamarin.Forms;

namespace TestApp.Views
{
    class MainPage : ContentPage
    {
        public MainPage()
        {
            BackgroundColor = Color.PowderBlue;
            BindingContext = new MainPageViewModel();

            var logoImage = new Image
            {
                Source = "logo.png"
            };

            var noteEditor = new Editor
            {
                Placeholder = "Enter Note",
                BackgroundColor = Color.White,
                Margin = new Thickness(10)
            };
            noteEditor.SetBinding(Editor.TextProperty, "NoteText");
            var saveButton = new Button
            {
                Text = "Save",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                Margin = new Thickness(10)
            };
            saveButton.SetBinding(Button.CommandProperty, "SaveCommand");

            var deleteButton = new Button
            {
                Text = "Delete",
                TextColor = Color.White,
                BackgroundColor = Color.Red,
                Margin = new Thickness(10)
            };
            deleteButton.SetBinding(Button.CommandProperty, "DeleteCommand");

            var collectionView = new CollectionView
            {
                ItemTemplate = new ElementTemplate()
            };
        }
    }
}
