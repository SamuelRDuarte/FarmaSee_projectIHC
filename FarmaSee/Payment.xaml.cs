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
            Medicines.ItemsSource = MainWindow.ShopList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (((bool)pickupBt.IsChecked || (bool)atHomeBt.IsChecked) && ((bool)mbWay.IsChecked || (bool)atDelivery.IsChecked))
            {
                //Order order = new Order();
                //this.NavigationService.Navigate(order);
                MessageBox.Show("Order made", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new Home());
                MainWindow.ShopList.Clear();
            }
            else
            {
                MessageBox.Show("Select a type of payment and delivery", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void plus_click(object sender, RoutedEventArgs e)
        {
            string nome = ((Button)sender).Tag.ToString();
            Medicamento med = MainWindow.ShopList.ToList().Find(x => x.Nome == nome);
            MainWindow.ShopList.Remove(med);
            med.Quantidade++;
            MainWindow.ShopList.Add(med);
            Medicines.ItemsSource = MainWindow.ShopList;
        }

        private void minus_click(object sender, RoutedEventArgs e)
        {
            string nome = ((Button)sender).Tag.ToString();
            Medicamento med = MainWindow.ShopList.ToList().Find(x => x.Nome == nome);
            if(med.Quantidade > 1)
            {
                MainWindow.ShopList.Remove(med);
                med.Quantidade--;
                MainWindow.ShopList.Add(med);
                Medicines.ItemsSource = MainWindow.ShopList;
            }
            else
            {
                MessageBox.Show("Quantity can't be less than 1", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            string nome = ((Button)sender).Tag.ToString();
            MainWindow.ShopList.Remove(MainWindow.ShopList.ToList().Find(x => x.Nome == nome));
            Medicines.ItemsSource = MainWindow.ShopList;
        }
    }
}
