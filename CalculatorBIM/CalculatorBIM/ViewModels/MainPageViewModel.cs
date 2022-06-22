using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CalculatorBIM.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private double height = 180;
        private double weight = 72;
        private const double STEP = 1.0;
        public double Height { 
            get => height; 
            set 
            {
                height = NextStep(value);
                OnPropertyChanged(nameof(BMI));
                OnPropertyChanged(nameof(Classification));
            } 
        }
        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                OnPropertyChanged(nameof(BMI));
                OnPropertyChanged(nameof(Classification));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Classification
        {
            get
            {
                if (BMI < 18.5)
                    return "You are underweight";
                else if (BMI < 25)
                    return "Your have a normal weight";
                else if (BMI < 30)
                    return "You are overweight";
                else
                    return "You are obese";
            }
        }

        private double NextStep(double value) =>  Math.Round(value / STEP) * STEP;
   
        public double BMI => Math.Round(Weight / Math.Pow(Height/100, 2),2);
    }
}
