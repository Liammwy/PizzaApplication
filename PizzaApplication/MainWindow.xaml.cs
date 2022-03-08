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
using System.Diagnostics;

namespace PizzaApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double TotalCost = 0;
        double CostOfPizza = 0;
        public bool delivery = false;
        int i = 0;
        public itemList items = new itemList();
        public ItemLists itemList;
        public PizzaChoice pizzaChoice = new PizzaChoice();
        //Creating a random class that will be used to create a random number.
        Random random = new Random();

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
                        //Adding the cost of each topping to the cost of the individual pizza.
                        CostOfPizza += items.PizzaTopping[topping];
                    }
                }
                //Rounding the cost of the pizza to 2 digits.
                CostOfPizza = Math.Round(CostOfPizza, 2);
                //Making the total cost equal the cost of the pizza.
                TotalCost += CostOfPizza;
                //Adding the cost of the pizza to a list along with the number of 'i'.
                items.PizzaOrders.Add(i.ToString(), CostOfPizza);
                //Adding all the pizza toppings into one combined string using this format. It will be displayed as "t1,t2,t3"
                string combinedString = string.Join(", ", PizzaToppingsSelect);
                //Adding the pizza, size, topping and cost to the orderlist.
                OrderList.Items.Add($"Pizza Name: {pizzaChoice.Pizza}\nPizza Size: {pizzaChoice.Size}\nPizza Toppings: {combinedString}\nCost: £{CostOfPizza}");
                //Setting the cost of the pizza back to 0 as we're moving on to another pizza.
                CostOfPizza = 0;
                TotalCost = Math.Round(TotalCost, 2);
                //Adding the total cost to the label, this will update each time something is added to the order.
                TotalCostLabel.Content = ($"Total cost: £{TotalCost}");
            }
            //Unselecting all the selected items so that the user can select another custom pizza.
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

        //Deleting function. Checks to see how many items in each list have been selected and then deletes the ones that were selected.
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

        //A little function to stop the program from not being able to close when 2 applications are opened.
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        //Checking to see how many sides, if any, have been selected.
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            double costOfSide = 0;
            //Foreach loop to loop over each side that has been selected.
            foreach (string sides in SelectSides.SelectedItems)
            {
                //Adding the cost of easch side to a value.
                costOfSide += items.PizzaSides[sides];
                //Adding that valeu to the total cost.
                TotalCost += costOfSide;
                //Rounding the total cost.
                TotalCost = Math.Round(TotalCost, 2);
                //Updating the total cost label.
                TotalCostLabel.Content = ($"Total cost: £{TotalCost}");
                //Adding each item to the order list for the sides.
                OrderListSides.Items.Add($"{sides}\nCost: £{costOfSide}");
                costOfSide = 0;
            }
            //Unselecting all the sides so they can pick some more if they want to.
            SelectSides.UnselectAll();
        }

        //Submit Button, this will move onto either the reciept or the delivery stages depending on if the user has selected delivery.
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Creating new instances for each of the windows (Window1 = receipt, Window2 = delivery confirmation).
            Window1 window = new Window1();
            Window2 window2 = new Window2();

            //Random number generator.
            int randomNum = random.Next(10000, 99999);
            //Updating each of the labels in the receipt to correspond with the correct value.
            window.ReceiptCost.Content = ($"Total Cost: £{TotalCost}");
            window.ReceiptNum.Content = ($"Receipt Number: {randomNum}");
            window.ReceiptDelivery.Content = ($"Delivery: {delivery}");
            //Hiding the name and the address as these won't be needed if the user hasn't selected delivery.
            window.ReceiptName.Visibility = Visibility.Hidden;
            window.ReceiptAddress.Visibility = Visibility.Hidden;
            //Setting the totalCost variable in the delivery confirmation window to the TotalCost.
            window2.totalCost = TotalCost;

            //Checking to see if the yes is ticked for delivery.
            if (Yes.IsChecked == true)
            {
                //If they want delivery, it will show the delivery confirmation window.
                window2.Show();
                //Will set the delivery to true.
                delivery = true;
                window2.delivery = delivery;
            } 
            //If yes isn't checked, that means they don't want delivery and the receipt window will be shown.
            else
            {
                window.Show();
                delivery = false;
            }
        }

        private void Yes_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void No_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
