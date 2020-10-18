using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
