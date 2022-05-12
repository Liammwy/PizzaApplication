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
        /* This class is an extension of itemList.cs
         * I couldn't figure out how to make it so dictionaries linked to the main class, so I had to create a separate class
         * to allow for that.
         */
        public MainWindow instance;
        public ItemLists(MainWindow instance)
        {
            this.instance = instance;
            addPizza();
            addSize();
            addTopping();
            addSides();
        }

        public List<string> PizzaType = new List<string>()
        {
            "Neapolitan",
            "Chicago",
            "Greek",
            "Margherita",
            "Meat Lover",
            "Texan BBQ",
            "Ham",
        };

        public List<string> PizzaSize = new List<string>()
        {
            "Small",
            "Medium",
            "Large",
            "Extra Large",
            "Party",
        };

        public List<string> PizzaTopping = new List<string>()
        {
            "None",
            "Extra Cheese",
            "Ham",
            "Onion",
            "Olives",
            "Mushrooms",
            "Peppers",
            "Beef",
        };

        public List<string> PizzaSides = new List<string>()
        {
            "Diet Coke",
            "Brownie",
            "Fries",
            "Wedges",
            "Waffles",
            "Ice cream",
            "Chocolate bar",
        };

        //Function to add each pizza in the PizzaList list to the menu on the uI.
        public void addPizza()
        {
            foreach (string pizza in PizzaType)
            {
                instance.SelectPizza.Items.Add($"{pizza}");
            }
        }

        //Function to add each pizza size in the PizzaList list to the menu on the uI.
        public void addSize()
        {
            foreach (string size in PizzaSize)
            {
                instance.SelectSize.Items.Add($"{size}");
            }
        }

        //Function to add each topping in the PizzaList list to the menu on the uI.
        public void addTopping()
        {
            foreach (string topping in PizzaTopping)
            {
                instance.SelectTopping.Items.Add($"{topping}");
            }
        }

        //Function to add each side in the PizzaList list to the menu on the uI.
        public void addSides()
        {
            foreach (string side in PizzaSides)
            {
                instance.SelectSides.Items.Add($"{side}");
            }
        }
    }
}
