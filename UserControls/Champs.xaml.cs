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
using System.Windows.Navigation;


namespace TFT_Tracker.Views
{
    /// <summary>
    /// Interaktionslogik für ChampView.xaml
    /// </summary>
    public partial class Champs : UserControl
    {


        public Champs()
        {
            InitializeComponent();
            Grid gridChamps = new Grid();
            gridChamps.Height = 550;
            gridChamps.VerticalAlignment = VerticalAlignment.Top;
            gridChamps.Background = Brushes.DimGray;

            string[,] arrayChamps = new string[,]   {
                                                        { "Aatrox", "4" },
                                                        { "Ahri", "4" },
                                                        { "Akali", "3" },
                                                        { "Annie", "2" },
                                                        { "Aphelios", "2" },
                                                        { "Ashe", "4" },
                                                        { "Azir", "5" },
                                                        { "Cassiopeia", "4" },
                                                        { "Diana", "1" },
                                                        { "Elise", "1" },
                                                        { "Evelynn", "3" },
                                                        { "Ezreal", "5" },
                                                        { "Fiora", "1" },
                                                        { "Garen", "1" },
                                                        { "Hecarim", "2" },
                                                        { "Irelia", "3" },
                                                        { "Janna", "2" },
                                                        { "Jarvan_IV", "2" },
                                                        { "Jax", "2" },
                                                        { "Jhin", "4" },
                                                        { "Jinx", "3" },
                                                        { "Kalista", "3" },
                                                        { "Katarina", "3" },
                                                        { "Kayn", "5" },
                                                        { "Kennen", "3" },
                                                        { "Kindred", "3" },
                                                        { "Lee_Sin", "5" },
                                                        { "Lillia", "5" },
                                                        { "Lissandra", "1" },
                                                        { "Lulu", "2" },
                                                        { "Lux", "3" },
                                                        { "Maokai", "1" },
                                                        { "Morgana", "4" },
                                                        { "Nami", "1" },
                                                        { "Nidalee", "1" },
                                                        { "Nunu", "3" },
                                                        { "Pyke", "2" },
                                                        { "Riven", "4" },
                                                        { "Sejuani", "4" },
                                                        { "Sett", "5" },
                                                        { "Shen", "4" },
                                                        { "Sylas", "2" },
                                                        { "Tahm_Kench", "1" },
                                                        { "Talon", "4" },
                                                        { "Teemo", "2" },
                                                        { "Thresh", "2" },
                                                        { "Twisted_Fate", "1" },
                                                        { "Vayne", "1" },
                                                        { "Veigar", "3" },
                                                        { "Vi", "2" },
                                                        { "Warwick", "4" },
                                                        { "Wukong", "1" },
                                                        { "Xin_Zhao", "3" },
                                                        { "Yasuo", "1" },
                                                        { "Yone", "5" },
                                                        { "Yuumi", "3" },
                                                        { "Zed", "2" },
                                                        { "Zilean", "5" }
                                                    };


            string[,] arrayChampsSorted = new string[,]   {
                                                        { "Diana", "1" },
                                                        { "Elise", "1" },
                                                        { "Fiora", "1" },
                                                        { "Garen", "1" },
                                                        { "Lissandra", "1" },
                                                        { "Maokai", "1" },
                                                        { "Nami", "1" },
                                                        { "Nidalee", "1" },
                                                        { "TahmKench", "1" },
                                                        { "TwistedFate", "1" },
                                                        { "Wukong", "1" },
                                                        { "Vayne", "1" },
                                                        { "Yasuo", "1" },
                                                        { "Annie", "2" },
                                                        { "Aphelios", "2" },
                                                        { "Hecarim", "2" },
                                                        { "Janna", "2" },
                                                        { "JarvanIV", "2" },
                                                        { "Jax", "2" },
                                                        { "Lulu", "2" },
                                                        { "Pyke", "2" },
                                                        { "Sylas", "2" },
                                                        { "Teemo", "2" },
                                                        { "Thresh", "2" },
                                                        { "Vi", "2" },
                                                        { "Zed", "2" },
                                                        { "Akali", "3" },
                                                        { "Evelynn", "3" },
                                                        { "Irelia", "3" },
                                                        { "Jinx", "3" },
                                                        { "Kalista", "3" },
                                                        { "Katarina", "3" },
                                                        { "Kennen", "3" },
                                                        { "Kindred", "3" },
                                                        { "Lux", "3" },
                                                        { "Nunu", "3" },
                                                        { "Veigar", "3" },
                                                        { "XinZhao", "3" },
                                                        { "Yuumi", "3" },
                                                        { "Aatrox", "4" },
                                                        { "Ahri", "4" },
                                                        { "Ashe", "4" },
                                                        { "Cassiopeia", "4" },
                                                        { "Jhin", "4" },
                                                        { "Morgana", "4" },
                                                        { "Riven", "4" },
                                                        { "Sejuani", "4" },
                                                        { "Shen", "4" },
                                                        { "Talon", "4" },
                                                        { "Warwick", "4" },
                                                        { "Azir", "5" },
                                                        { "Ezreal", "5" },
                                                        { "Kayn", "5" },
                                                        { "LeeSin", "5" },
                                                        { "Lillia", "5" },
                                                        { "Sett", "5" },
                                                        { "Yone", "5" },
                                                        { "Zilean", "5" }
                                                    };



            // Find Highest number of same cost Units

            int[] cost = { 0, 0, 0, 0, 0 };

            for (int i = 0; i < (arrayChampsSorted.Length / 2); i++)              //leerer cost array soll auch funktionieren falls 6 7 costs
            {
                cost[Int32.Parse(arrayChampsSorted[i, 1]) - 1]++;
            }

            Array.Sort(cost);
            Array.Reverse(cost);

            // Create Columns
            for (int i = 0; i < cost[0]; i++)
            {
                ColumnDefinition tempcol = new ColumnDefinition();
                tempcol.Width = new GridLength(1, GridUnitType.Star);
                gridChamps.ColumnDefinitions.Add(tempcol);

            }


            // Create Rows
            for (int i = 0; i < cost.Length; i++)
            {
                RowDefinition tempRow = new RowDefinition();
                tempRow.Height = new GridLength(1, GridUnitType.Star);
                gridChamps.RowDefinitions.Add(tempRow);
            }

            // Adding Images
            SolidColorBrush[] colours = { Brushes.Gray, Brushes.LawnGreen, Brushes.MediumBlue, Brushes.Magenta, Brushes.Goldenrod };
            int k = 0;
            for (int i = 0; i < cost.Length; i++)
            {
                for (int j = 0; j < cost[i]; j++)
                {

                    var img = CreateImage(arrayChampsSorted[k, 0], colours[i]);
                    img.Margin = new Thickness(5, 5, 5, 5);
                    Grid.SetRow(img, i);
                    Grid.SetColumn(img, j);
                    gridChamps.Children.Add(img);
                    k++;
                }
            }


            // Display grid into a Window

            this.Content = gridChamps;

        }


        private Border CreateImage(string var, SolidColorBrush brush)
        {
            Border tempBorder = new Border();
            tempBorder.BorderBrush = brush;
            tempBorder.BorderThickness = new Thickness(2);
            tempBorder.VerticalAlignment = VerticalAlignment.Center;
            tempBorder.HorizontalAlignment = HorizontalAlignment.Center;
            Image img = new Image();
            ImageSource Image = new BitmapImage(new Uri("C://Users/Pascal/source/repos/TFT-Tracker/Resources/Images/Champs/" + var + ".png")); // relativer pfad
            img.Source = Image;
            tempBorder.Child = img;
            return tempBorder;
        }
    }
}
