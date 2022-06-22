using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BindingDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        int count = 0;
        public event PropertyChangedEventHandler PropertyChanged;
        public Command<string> IncreaseCommand { get; }
        public Command DecreaseCommand { get; }

        public MainViewModel()
        {
            IncreaseCommand = new Command<string>(IncreaseCount);
            DecreaseCommand = new Command(DecreaseCount);
        }

        void IncreaseCount(string i)
        {
            if(int.TryParse(i, out int num))
            {
                count += num;
                OnPropertyChanged(nameof(DisplayCount));
            }
        }
        void DecreaseCount()
        {
            App.Current.Resources["MainColor"] = Color.OrangeRed;
            count--;
            OnPropertyChanged(nameof(DisplayCount));
        }

        public string DisplayCount => $"You clicked {count} time(s)";
        void OnPropertyChanged(string count)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(count));
        }
    }
}
