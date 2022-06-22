using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using TestApp.Models;
using Xamarin.Forms;

namespace TestApp.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        string theNote = string.Empty;
        public ObservableCollection<string> AllNotes { get; set; }

        string selectedNote;
        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                var args = new PropertyChangedEventArgs(nameof(SelectedNote));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public MainPageViewModel() 
        {
            AllNotes = new ObservableCollection<NoteModel>();

            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();
                detailPage.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });

            DeleteCommand = new Command(() =>
            {
                TheNote = string.Empty;
            }); 
            
            SaveCommand = new Command(() =>
            {
                var note = new NoteModel
                {
                    Text = TheNote
                };
               AllNotes.Add(TheNote);
               TheNote = string.Empty;
            });
        }

        public string TheNote
        {
            get => theNote;
            set 
            {
                theNote = value;
                var args = new PropertyChangedEventArgs(nameof(TheNote));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command SelectedNoteChangedCommand { get; }
        public Command DeleteCommand { get;  }

    }
}
