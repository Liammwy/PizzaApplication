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
    }
}
