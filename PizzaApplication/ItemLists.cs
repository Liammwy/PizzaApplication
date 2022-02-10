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
    public class ItemLists
    {
        public MainWindow instance;

        public ItemLists(MainWindow instance)
        {
            this.instance = instance;
            addPizza();
            addSize();
            addTopping();
        }
        //Pizza Types list, add more pizza types here.
        public List<string> PizzaTypes = new List<string>()
        {
            "Neapolitan",
            "Chicago",
            "Greek",
            "Margherita",
            "Meat Loaf",
            "Hawaiian",
        };
        //Pizza Size list, Easier to edit adding them all to a list.
        public List<string> PizzaSizes = new List<string>()
        {
            "Small",
            "Medium",
            "Large",
            "Extra Large",
        };
        //Pizza Toppings list.
        public List<string> PizzaToppings = new List<string>()
        {
            "None",
            "Extra Cheese",
            "Peppers",
            "Beef",
            "Chicken",
            "Pickles",
            "Onion",
            "Mushrooms",
            "Ham",
        };


        public void addPizza()
        {
            foreach (string pizza in PizzaTypes)
            {
                instance.SelectPizza.Items.Add($"{pizza} pizza");
            }
        }

        public void addSize()
        {
            foreach (string size in PizzaSizes)
            {
                instance.SelectSize.Items.Add($"{size}");
            }
        }

        public void addTopping()
        {
            foreach (string topping in PizzaToppings)
            {
                instance.SelectTopping.Items.Add($"{topping}");
            }
        }
    }
}
