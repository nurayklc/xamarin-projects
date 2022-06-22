using BurgerSpotXamarin.Models;
using BurgerSpotXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BurgerSpotXamarin.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            burgers = GetBurgers();
        }

        ObservableCollection<Burger> burgers;
        public ObservableCollection<Burger> Burgers 
        { 
            get { return burgers; }
            set
            {
                burgers = value;
                OnPropertyChanged();
            } 
        }
        private Burger selectedBurger;
        public Burger SelectedBurger
        {
            get { return selectedBurger; }
            set
            {
                selectedBurger = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(DisplayBurger);

        private void DisplayBurger()
        {
            if(selectedBurger != null)
            {
                var viewModel = new DetailsViewModel
                {
                    SelectedBurger = selectedBurger,
                    Burgers = burgers,
                    Position = burgers.IndexOf(selectedBurger)
                };
                var detailsPage = new DetailsPage { BindingContext = viewModel };
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(detailsPage, true);
            }
        }

        private ObservableCollection<Burger> GetBurgers()
        {
            return new ObservableCollection<Burger>
            {
                new Burger { Name = "CLASSIC", Price = 12.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Burger { Name = "DOUBLE", Price = 19.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Burger { Name = "SHARK", Price = 17.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Burger { Name = "CHICKEN", Price = 15.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Burger { Name = "MEAT", Price = 11.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."},
                new Burger { Name = "BBQ", Price = 13.99f, Image = "hmbrgr.webp",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."}
            };
        }
    }
}
