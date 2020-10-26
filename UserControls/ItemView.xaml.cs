using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        public static int[] arrayQuantities = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public Grid combGrid = new Grid();
        public ScrollViewer combScrollViewer = new ScrollViewer();

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


            foreach (string i in arrayItems)
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


                // Counter und Plus/Minus Buttons

                TextBlock tempQuantTextBlock = new TextBlock();
                tempQuantTextBlock.VerticalAlignment = VerticalAlignment.Center;
                tempQuantTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                tempQuantTextBlock.Name = "textBlockQuant" + i;
                tempQuantTextBlock.Text = "0";
                tempQuantTextBlock.FontSize = 20;
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
            
            combScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
            combScrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Grid.SetRow(combScrollViewer, 2);
            mainItemGrid.Children.Add(componentsGrid);
            mainItemGrid.Children.Add(combScrollViewer);
        }

        private void showSortedCombinations()
        {
            combGrid.ColumnDefinitions.Clear();
            
            SortedCombinations combinations = new SortedCombinations();
            List<List<ItemIDs>> ompf = new List<List<ItemIDs>>();
            ompf = combinations.sortedCombinations;
            int p = 0;

            foreach (List<ItemIDs> singleCombination in ompf)
            { 
                ColumnDefinition tempCombCol = new ColumnDefinition();
                tempCombCol.Width = new GridLength(40, GridUnitType.Pixel);
                combGrid.ColumnDefinitions.Add(tempCombCol);

                Grid singleCombGrid = new Grid();

                int q = 0;
                foreach (ItemIDs Ids in singleCombination)
                {
                    RowDefinition tempRow = new RowDefinition();
                    tempRow.Height = new GridLength(40, GridUnitType.Pixel);
                    singleCombGrid.RowDefinitions.Add(tempRow);
                }

                foreach (ItemIDs Ids in singleCombination) 
                {
                    Ids.sortIDs();
                    Item tempItem = new Item((Ids.Id1 + 1), (Ids.Id2 + 1));
                    tempItem.itemImgBorder.Margin = new Thickness(2, 2, 2, 2);
                    Grid.SetRow(tempItem.itemImgBorder, q);
                    singleCombGrid.Children.Add(tempItem.itemImgBorder);
                    q++;
                }

                Grid.SetColumn(singleCombGrid, p);

                combGrid.Children.Add(singleCombGrid);
                p++;
            }

            combScrollViewer.Content = combGrid;
        }


        // Plus Button Click Funktion
        private void plusBtn_Click(object sender, EventArgs e, int index, TextBlock t)
        {
            if (arrayQuantities[index] < 10)
            {
                arrayQuantities[index]++;
                t.Text = Convert.ToString(arrayQuantities[index]);
                showSortedCombinations();
            }
        }

        // Minus Button Click Funktion
        private void minusBtn_Click(object sender, EventArgs e, int index, TextBlock t)
        {
            if (arrayQuantities[index] > 0)
            {
                arrayQuantities[index]--;
                t.Text = Convert.ToString(arrayQuantities[index]);
                showSortedCombinations();
            }

        }

        

        // Create Image Funktion (muss noch aussortiert werden)
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

        public static List<ItemIDs> getCombinations( int[] tempArray)
        {
            Dictionary<int, int> tempDict1 = new Dictionary<int, int>();
            int j = 0;
            foreach( int i in tempArray)
            {
                tempDict1.Add(j , i);
                j++;
            }
            Dictionary<int, int> tempDict2 = new Dictionary<int, int>(tempDict1);

            List<ItemIDs> combinations = new List<ItemIDs>();

            foreach (KeyValuePair<int, int> kvp1 in tempDict1)
            {
                int prei = kvp1.Value;
                for (int i = prei; i > 0; i--)
                {
                        tempDict2[kvp1.Key]--;


                    foreach (KeyValuePair<int, int> kvp2 in tempDict2)
                    {
                        int prek = kvp2.Value;
                        for (int k = prek; k > 0; k--)
                        {
                            combinations.Add(new ItemIDs(kvp1.Key, kvp2.Key));
                        }
                    }
                }
            }
            return combinations;
        }

    }


    public class SortedCombinations
    {
        public int[] tempArrayQuantities;
        public List<ItemIDs> tempFinalCombination { get; set; } = new List<ItemIDs>();  // column im grid
        public List<List<ItemIDs>> sortedCombinations { get; set; } = new List<List<ItemIDs>> { }; // das gesamte grid

        public int[] maxItems = new int[]{0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};

        public SortedCombinations()
        {
            int[] tempArrayQuantities = new List<int>(ItemView.arrayQuantities).ToArray();
            sortItems(tempArrayQuantities);
        }

        public void sortItems(int[] leftQuantities)
        {
            List<ItemIDs> combinations = new List<ItemIDs> (ItemView.getCombinations(leftQuantities));

            foreach (ItemIDs c in combinations)
            {
                tempFinalCombination.Add(c);
                leftQuantities[c.Id1]--;
                leftQuantities[c.Id2]--;
                int i = addArray(leftQuantities);
                if (i >= 1)
                {
                    sortItems(leftQuantities);
                }
                leftQuantities[c.Id1]++;
                leftQuantities[c.Id2]++;
                
                if (tempFinalCombination.Count() == maxItems[addArray(ItemView.arrayQuantities)])
                {
                    sortedCombinations.Add(new List<ItemIDs>(tempFinalCombination));
                }
                tempFinalCombination.Remove(c);
            }
        }

        public int addArray(int[] array)
        {
            int result = 0;
            foreach (int i in array)
            {
                result += i;
            }
            return result;
        }
    }
    public class ItemIDs
    {
        public int Id1 { get; set; }
        public int Id2 { get; set; }

        public ItemIDs(int id1, int id2)
        {
            Id1 = id1;
            Id2 = id2;
        }

        public void sortIDs()
        {
            if (Id1 > Id2)
            {
                int temp = Id1;
                Id1 = Id2;
                Id2 = temp;
            }
        }
    }

    public class Item{
        private int component1;
        private int component2;
        private string id;
        private Image itemImg;
        public Border itemImgBorder;

        public Item(int comp1, int comp2)
        {
            component1 = comp1;
            component2 = comp2;
            id = sortString(Convert.ToString(comp1) + Convert.ToString(comp2));
            setItemImg(id);
            setItemImgBorder();

        }
        public void setItemImg(string id)
        {
            itemImg = new Image();
            ImageSource src = new BitmapImage(new Uri("C://Users/Pascal/source/repos/TFT-Tracker/Resources/Images/Items/" + id + ".png"));
            itemImg.Source = src;
        }

        public void setItemImgBorder()
        {
            itemImgBorder = new Border();
            itemImgBorder.BorderBrush = Brushes.Black;
            itemImgBorder.BorderThickness = new Thickness(2);
            itemImgBorder.VerticalAlignment = VerticalAlignment.Center;
            itemImgBorder.HorizontalAlignment = HorizontalAlignment.Center;
            itemImgBorder.Child = itemImg;
        }

        static string sortString(string input)
        {
            char[] characters = input.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

    }
}