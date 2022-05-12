using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApplication
{
    public class PizzaChoice
    {
        //Encapsulation is used here. Encapsulation is the process of making sure that sensitive data is hidden from outside users. 
        //Private variables are created.
        private string toppings;
        private string pizza;
        private string size;
        private string sides;

        //Get and set method. "Get" returns the value of the variable name. "Set" assigns that variable to the new variable, in this case "Toppings".
        public string Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public string Pizza
        {
            get { return pizza; }
            set { pizza = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public string Sides
        {
            get { return sides; } 
            set { sides = value; }
        }
    }
}
