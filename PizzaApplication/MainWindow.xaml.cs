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
            if (SelectPizza.SelectedItems.Count == 1)
            {
                pizzaChoice.Pizza = SelectPizza.SelectedItem.ToString();
                if (SelectPizza.SelectedItems.Count == 1)
                {
                    pizzaChoice.Size = SelectSize.SelectedItem.ToString();
                    if (SelectTopping.SelectedItems.Count >= 1)
                    {
                        foreach (string topping in SelectTopping.SelectedItems)
                        {
                            pizzaChoice.Toppings = SelectTopping.SelectedItem.ToString();
                        }

                        OrderList.Items.Add($"Pizza Number: {SelectPizza.Items.Count + 1}\nPizza Name: {pizzaChoice.Pizza}\nPizza Size: {pizzaChoice.Size}\nPizza Toppings: ");
                        SelectPizza.UnselectAll();
                        SelectSize.UnselectAll();
                        SelectTopping.UnselectAll();
                    }
                }
            }
        }
    }
}
