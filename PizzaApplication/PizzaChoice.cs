using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApplication
{
    public class PizzaChoice
    {
        private string toppings;
        private string pizza;
        private string size;
        private string sides;
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
