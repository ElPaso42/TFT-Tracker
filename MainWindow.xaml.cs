using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFT_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(home);
        }

        private void btnChamps_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(champs);
        }


        private void btnItems_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(items);
        }

        private void btnComps_Click(object sender, RoutedEventArgs e)
        {
            SetActiveUserControl(comp);
        }

        public void SetActiveUserControl(UserControl control)
        {
            //Collapse all Views
            home.Visibility = Visibility.Collapsed;
            champs.Visibility = Visibility.Collapsed;
            items.Visibility = Visibility.Collapsed;
            comp.Visibility = Visibility.Collapsed;

            //Show current View
            control.Visibility = Visibility.Visible;
        }

    }
}
