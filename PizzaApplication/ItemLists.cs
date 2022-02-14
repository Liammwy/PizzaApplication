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
            addSides();
        }

        public Dictionary<string, double> ConfirmedPizzas = new Dictionary<string, double>();

        //Dictionary containing all the pizza types and their associated price.
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

        /*
         * Dictionary containing all the pizza sizes along with how much extra they will cost the order.
         * The way this works is PizzaType * PizzaSize, this stops me from having to define every pizza and their associated size.
         * Of course this isn't perfect, but the system works as intended.
         */
        public Dictionary<string, double> PizzaSize = new Dictionary<string, double>()
        {
            {"Small", 1},
            {"Medium", 1.2},
            {"Large", 1.45},
            {"Extra Large", 1.7},
            {"Party", 1.95},
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

        public Dictionary<string, double> PizzaSides = new Dictionary<string, double>()
        {
            {"Diet Coke", 4.53},
            {"Brownie", 4.53},
            {"Fries", 4.53},
            {"Wedges", 4.53},
            {"Waffles", 4.53},
            {"Ice cream", 4.53},
            {"Chocolate bar", 4.53},
        };


        public void addPizza()
        {
            foreach (string pizza in PizzaType.Keys)
            {
                instance.SelectPizza.Items.Add($"{pizza} pizza");
            }
        }

        public void addSize()
        {
            foreach (string size in PizzaSize.Keys)
            {
                instance.SelectSize.Items.Add($"{size}");
            }
        }

        public void addTopping()
        {
            foreach (string topping in PizzaTopping.Keys)
            {
                instance.SelectTopping.Items.Add($"{topping}");
            }
        }

        public void addSides()
        {
            foreach (string side in PizzaSides.Keys)
            {
                instance.SelectSides.Items.Add($"{side}");
            }
        }
    }
}
