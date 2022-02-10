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

        public Dictionary<string, double> PizzaType = new Dictionary<string, double>()
        {
            {"Neapolitan", 7.80},
            {"Chicago", 8.60},
            {"Greek", 7.15},
            {"Margherita", 5.45},
            {"Meat Lover", 13.35},
            {"Hawaiian", 9.85},
            {"Texan BBQ", 13.65},
            {"Ham", 5.20},
        };

        public Dictionary<string, double> PizzaSize = new Dictionary<string, double>()
        {
            {"Small", 1.05},
            {"Medium", 1.2},
            {"Large", 1.3},
            {"Extra Large", 1.5},
        };

        public Dictionary<string, double> PizzaTopping = new Dictionary<string, double>()
        {
            {"None", 7.80},
            {"Extra Cheese", 8.60},
            {"Ham", 7.15},
            {"Onion", 5.45},
            {"Olives", 13.35},
            {"Muushrooms", 9.85},
            {"Peppers", 13.65},
            {"Beef", 5.20},
        };

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
