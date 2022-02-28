﻿using System;
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
using System.Diagnostics;

namespace PizzaApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double TotalCost = 0;
        double CostOfPizza = 0;
        int i = 0;
        public itemList items = new itemList();
        public ItemLists itemList;
        public PizzaChoice pizzaChoice = new PizzaChoice();

        public MainWindow()
        {
            InitializeComponent();
            new ItemLists(this);
        }

        //When the "Confirm Pizza" button is clicked, this method will run.
        private void ConfirmPizza_Click(object sender, RoutedEventArgs e)
        {
            i++;
            //A count integer will will increment based on how many of the sections are incorrect. This will be used to see if all sections have been selected or not.
            bool valid = true;
            if (SelectPizza.SelectedItems.Count != 1)
            {
                //"Trace" is just the same as Console, it will print out this message if the amount of pizzas selected is not 1.
                Trace.WriteLine("No pizza has been selected.");
                valid = false;
            }

            if (SelectSize.SelectedItems.Count != 1)
            {
                //This message will be printed out if the user hasn't selected a size.
                Trace.WriteLine("Please enter a pizza size.");
                valid = false;
            }

            if (SelectTopping.SelectedItems.Count == 0)
            {
                //This message will be printed out if the user hans't selected AT LEAST one topping (To allow for multiple).
                Trace.WriteLine("Please select a topping.");
                valid = false;
            }

            //This will check to see if any of the fields are invalid. If they aren't, then the count will still be 0 and therefore this code runs.
            if (valid == true)
            {
                pizzaChoice.Pizza = SelectPizza.SelectedItem.ToString();
                pizzaChoice.Size = SelectSize.SelectedItem.ToString();
                pizzaChoice.Toppings = SelectTopping.SelectedItem.ToString();
                //Creating a new list to store all toppings that have been selected, as this caused some issues before with adding them to the order list.
                List<string> PizzaToppingsSelect = new List<string>();
                CostOfPizza += items.PizzaType[pizzaChoice.Pizza] * items.PizzaSize[pizzaChoice.Size];
                //foreach statement to look for each topping that has been selected.
                foreach (string topping in SelectTopping.SelectedItems)
                {
                    //If one of the toppings that have been selected is 'None'.
                    if (topping == "None")
                    {
                        //Writing a line to console saying that the selection is none, just confirmation that the program is working as intended.
                        Trace.WriteLine("None topping selection has been made, therefore no pizzas will be added to the list.");
                        //Clears the whole topping list so the other toppings selected won't be added.
                        PizzaToppingsSelect.Clear();
                        //Add the "none" topping to the list so it's the only one that is displayed.
                        PizzaToppingsSelect.Add(topping);
                        //Breaking the foreach loop so other items aren't added to the list afterwards.
                        break;
                    }
                    else
                    {
                        //If the topping isn't "None" then the topping will be added to the list.
                        PizzaToppingsSelect.Add(topping);
                        CostOfPizza += items.PizzaTopping[topping];
                    }
                }
                CostOfPizza = Math.Round(CostOfPizza, 2);
                TotalCost += CostOfPizza;
                items.PizzaOrders.Add(i.ToString(), CostOfPizza);
                string combinedString = string.Join(", ", PizzaToppingsSelect);
                OrderList.Items.Add($"Pizza Name: {pizzaChoice.Pizza}\nPizza Size: {pizzaChoice.Size}\nPizza Toppings: {combinedString}\nCost: £{CostOfPizza}");
                CostOfPizza = 0;
                TotalCost = Math.Round(TotalCost, 2);
                TotalCostLabel.Content = ($"Total cost: £{TotalCost}");
            }
            SelectPizza.UnselectAll();
            SelectSize.UnselectAll();
            SelectTopping.UnselectAll();
        }

        //Clear the current pizza selection (Pizza, size, topping)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectPizza.UnselectAll();
            SelectSize.UnselectAll();
            SelectTopping.UnselectAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (OrderList.SelectedIndex != -1)
            {
                for (int i = OrderList.SelectedItems.Count - 1; i >= 0; i--)
                {
                    OrderList.Items.Remove(OrderList.SelectedItems[i]);
                }
            }
            if (OrderListSides.SelectedIndex != -1)
            {
                for (int i = OrderListSides.SelectedItems.Count -1; i >= 0; i--)
                {
                    OrderListSides.Items.Remove(OrderListSides.SelectedItems[i]);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double costOfSide = 0;
            foreach (string sides in SelectSides.SelectedItems)
            {
                costOfSide += items.PizzaSides[sides];
                TotalCost += costOfSide;
                TotalCost = Math.Round(TotalCost, 2);
                TotalCostLabel.Content = ($"Total cost: £{TotalCost}");
                OrderListSides.Items.Add($"{sides}\nCost: £{costOfSide}");
                costOfSide = 0;
            }

            SelectSides.UnselectAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            Random random = new Random();
            int randomNum = random.Next(10000, 50000);
            window.ReceiptCost.Content = ($"Total Cost: £{TotalCost}");
            window.ReceiptNum.Content = ($"Receipt Number: {randomNum}");
            window.Show();
        }

        private void Yes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
