using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApplication
{
    public class itemList
    {
        
        /* This class is used to store a bunch of dictionaries. These dictionaries are used throughout the program
         * PizzaType is the type of pizza and the price of that pizza.
         * PizzaSize is the size of the pizza and the multiplier of that size (PizzaType * PizzaSize)
         * PizzaTopping is the list of toppings and their price.
         * PizzaSides is the list of sides and their price.
         */

        public Dictionary<string, double> PizzaType = new Dictionary<string, double>()
        {
            {"Neapolitan", 7.85},
            {"Chicago", 8.75},
            {"Greek", 7.15},
            {"Margherita", 5.45},
            {"Meat Lover", 13.35},
            {"Hawaiian", 9.85},
            {"Texan BBQ", 13.65},
            {"Ham", 6.85},
        };

        public Dictionary<string, double> PizzaSize = new Dictionary<string, double>()
        {
            {"Small", 1},
            {"Medium", 1.22},
            {"Large", 1.45},
            {"Extra Large", 1.75},
            {"Party", 1.95},
        };

        public Dictionary<string, double> PizzaTopping = new Dictionary<string, double>()
        {
            {"None", 7.80},
            {"Extra Cheese", 0.35},
            {"Ham", 0.65},
            {"Onion", 0.45},
            {"Olives", 0.45},
            {"Mushrooms", 0.65},
            {"Peppers", 0.55},
            {"Beef", 0.75},
        };

        public Dictionary<string, double> PizzaSides = new Dictionary<string, double>()
        {
            {"Diet Coke", 1.45},
            {"Brownie", 3.25},
            {"Fries", 2.55},
            {"Wedges", 3.25},
            {"Waffles", 3.65},
            {"Ice cream", 2.35},
            {"Chocolate bar", 1.15},
        };
    }
}
