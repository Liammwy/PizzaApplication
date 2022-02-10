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
        public ItemLists itemList;
        public PizzaChoice pizzaChoice = new PizzaChoice();

        public MainWindow()
        {
            InitializeComponent();
            new ItemLists(this);
        }

        private void ConfirmPizza_Click(object sender, RoutedEventArgs e)
        {
            int Count = 0;
            if (SelectPizza.SelectedItems.Count != 1)
            {
                Trace.WriteLine("No pizza has been selected.");
                Count++;
            }

            if (SelectSize.SelectedItems.Count != 1)
            {
                Trace.WriteLine("Please enter a pizza size.");
                Count++;
            }

            if (SelectTopping.SelectedItems.Count == 0)
            {
                Trace.WriteLine("Please select a topping.");
                Count++;
            }

            if (Count == 0)
            {
                pizzaChoice.Pizza = SelectPizza.SelectedItem.ToString();
                pizzaChoice.Size = SelectSize.SelectedItem.ToString();
                pizzaChoice.Toppings = SelectTopping.SelectedItem.ToString();
                List<string> PizzaToppingsSelect = new List<string>();
                foreach(string topping in SelectTopping.SelectedItems)
                {
                    if (topping == "None")
                    {
                        Trace.WriteLine("None topping selection has been made, therefore no pizzas will be added to the list.");
                        PizzaToppingsSelect.Clear();
                        PizzaToppingsSelect.Add(topping);
                        break;
                    }
                    else
                    {
                        PizzaToppingsSelect.Add(topping);
                    }
                }
                string combinedString = string.Join(", ", PizzaToppingsSelect);
                OrderList.Items.Add($"Pizza Number: {OrderList.Items.Count + 1}\nPizza Name: {pizzaChoice.Pizza}\nPizza Size: {pizzaChoice.Size}\nPizza Toppings: {combinedString}");
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
    }
}
