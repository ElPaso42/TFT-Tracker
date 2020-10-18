using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TFT_Tracker.Views
{
    /// <summary>
    /// Interaktionslogik für ChampView.xaml
    /// </summary>
    public partial class ChampView : Window
    {
        public ChampView()
        {
            this.Aatrox.Source = "/Resources/Images/Champs/Ahri.png";
            InitializeComponent();
        }
    }
}
