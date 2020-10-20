using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TFT_Tracker.ViewModels;

namespace TFT_Tracker.Commands
{
    class UpdateViewCommmand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommmand()
        {
        }

        public UpdateViewCommmand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("test");
            if(parameter.ToString() == "Champs")
            {
                viewModel.SelectedViewModel = new ChampViewModel();
            }
            else if (parameter.ToString() == "Items")
            {
                viewModel.SelectedViewModel = new ChampViewModel();
            }
        }
    }
}
