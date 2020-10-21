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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TFT_Tracker.UserControls
{
    /// <summary>
    /// Interaktionslogik für ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        private int[] arrayQuantities = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public ItemView()
        {
            InitializeComponent();

            string[] arrayItems = new string[] { "01",
                                                 "02",
                                                 "03",
                                                 "04",
                                                 "05",
                                                 "06",
                                                 "07",
                                                 "08",
                                                 "09",
                                               };

            // Create oberes Grid für componentitems
            Grid componentsGrid = new Grid();
            componentsGrid.ShowGridLines = false;

            int j = 0;
            
            
            foreach ( string i in arrayItems)
            {
                int index = j;

                ColumnDefinition tempItemCol = new ColumnDefinition();
                tempItemCol.Width = new GridLength(1, GridUnitType.Star);
                componentsGrid.ColumnDefinitions.Add(tempItemCol);


                //Struktur der einzelnen Items
                Grid tempItemGrid = new Grid();
                tempItemGrid.ShowGridLines = false;

                for (int k = 2; k > 0; k--)
                {
                    RowDefinition tempItemRow = new RowDefinition();
                    tempItemRow.Height = new GridLength(k, GridUnitType.Star);
                    tempItemGrid.RowDefinitions.Add(tempItemRow);
                    
                }

                Grid.SetColumn(tempItemGrid, j);
                componentsGrid.Children.Add(tempItemGrid);

                Border img = CreateImage("Items/" + i, Brushes.Black);
                img.Margin = new Thickness(5, 5, 5, 5);
                Grid.SetRow(img, 0);
                tempItemGrid.Children.Add(img);
                


                //Struktur der Buttons unter den einzelnen Items
                Grid tempBtnGrid = new Grid();
                tempBtnGrid.ShowGridLines = false;
                

                for (int k = 0; k < 3; k++)
                {
                    ColumnDefinition tempBtnCol = new ColumnDefinition();
                    tempBtnCol.Width = new GridLength(1, GridUnitType.Star);
                    tempBtnGrid.ColumnDefinitions.Add(tempBtnCol);
                }

                Grid.SetRow(tempBtnGrid, 1);
                tempItemGrid.Children.Add(tempBtnGrid);

                TextBlock tempQuantTextBlock = new TextBlock();
                tempQuantTextBlock.VerticalAlignment = VerticalAlignment.Center;
                tempQuantTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                tempQuantTextBlock.Name = "textBlockQuant" + i;
                tempQuantTextBlock.Text = "0";
                Grid.SetColumn(tempQuantTextBlock, 1);

                Button tempBtnPlus = new Button();
                tempBtnPlus.Name = "btn_" + i;
                tempBtnPlus.Content = "+";
                tempBtnPlus.Margin = new Thickness(2, 9, 2, 9);
                tempBtnPlus.Click += (sender, e) => this.plusBtn_Click(sender, e, index, tempQuantTextBlock);
                Grid.SetColumn(tempBtnPlus, 2);

                Button tempBtnMinus = new Button();
                tempBtnMinus.Name = "btn_" + i;
                tempBtnMinus.Content = "-";
                tempBtnMinus.Margin = new Thickness(2, 9, 2, 9);
                tempBtnMinus.Click += (sender, e) => this.minusBtn_Click(sender, e, index, tempQuantTextBlock);
                Grid.SetColumn(tempBtnMinus, 0);


                tempBtnGrid.Children.Add(tempBtnPlus);
                tempBtnGrid.Children.Add(tempBtnMinus);
                tempBtnGrid.Children.Add(tempQuantTextBlock);

                j++;
            }

            mainItemGrid.Children.Add(componentsGrid);
        }

        private void plusBtn_Click(object sender, EventArgs e, int index, TextBlock t)
        {
            if (arrayQuantities[index] < 10)
            {
                arrayQuantities[index]++;
                t.Text = Convert.ToString(arrayQuantities[index]);
            }
        }

        private void minusBtn_Click(object sender, EventArgs e, int index, TextBlock t)
        {
            if (arrayQuantities[index] > 0)
            {
                arrayQuantities[index]--;
                t.Text = Convert.ToString(arrayQuantities[index]);
            }

        }

        private Border CreateImage(string var, SolidColorBrush brush)
        {
            Border tempBorder = new Border();
            tempBorder.BorderBrush = brush;
            tempBorder.BorderThickness = new Thickness(2);
            tempBorder.VerticalAlignment = VerticalAlignment.Center;
            tempBorder.HorizontalAlignment = HorizontalAlignment.Center;
            Image img = new Image();
            ImageSource Image = new BitmapImage(new Uri("C://Users/Pascal/source/repos/TFT-Tracker/Resources/Images/" + var + ".png")); // relativer pfad
            img.Source = Image;
            tempBorder.Child = img;
            return tempBorder;
        }
    }
}
