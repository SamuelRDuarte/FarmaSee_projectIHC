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

namespace FarmaSee
{
    /// <summary>
    /// Interaction logic for Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            this.NavigationService.Navigate(order);
        }

        private void plus_click(object sender, RoutedEventArgs e)
        {
            int quant = Convert.ToInt32(quantityLabel.Content);
            quantityLabel.Content = (quant + 1).ToString();
            minusButton.IsEnabled = true;
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
            int quant = Convert.ToInt32(quantityLabel.Content);
            int result = quant - 1;

            if (result == 0)
            {
                minusButton.IsEnabled = false;
                quantityLabel.Content = result.ToString();
            }
            else
            {
                quantityLabel.Content = result.ToString();
            }
        }
    }
}
