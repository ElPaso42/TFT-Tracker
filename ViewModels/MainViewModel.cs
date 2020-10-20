using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TFT_Tracker.Commands;

namespace TFT_Tracker.ViewModels
{
    // Generelle Funktion
    class MainViewModel : BaseViewModel
    {
        public BaseViewModel _selectedView;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedView; }
            set { _selectedView = value; }
        }

        public ICommand UpdateViewCommmand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommmand = new UpdateViewCommmand(this);
        }
    }
}
