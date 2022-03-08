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
using System.Windows.Shapes;
using System.Diagnostics;


namespace PizzaApplication
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        //Values that are going to be used globally are defined here. The totalcost and delivery value are placeholders.
        public PizzaChoice pizzaChoice = new PizzaChoice();
        public double totalCost = 0;
        public bool delivery;

        //Creating a new random class. This will be used to generate a random number later on.
        Random random = new Random();

        //On the "submit" button click, this function will run.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Creating a new receipt window object.
            Window1 window = new Window1();
            //Error checking to make sure their name and address is correct.
            if (CustomerAddress.Text.Length > 1 && CustomerName.Text.Length > 1)
            {
                //Creating a random number, this will be used for the receipt number at the end.
                int randomNum = random.Next(10000, 99999);
                //Setting the content of each part of the receipt to the given value.
                window.ReceiptCost.Content = ($"Total Cost: £{totalCost}");
                window.ReceiptNum.Content = ($"Receipt Number: {randomNum}");
                window.ReceiptDelivery.Content = ($"Delivery: {delivery}");
                window.ReceiptName.Content = ($"Customer Name: {CustomerName.Text}");
                window.ReceiptAddress.Content = ($"Customer Address: {CustomerAddress.Text}");
                //Showing the receipt.
                window.Show();
            }
        }
    }
}
