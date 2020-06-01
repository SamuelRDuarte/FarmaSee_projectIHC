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

namespace FarmaSee
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }
       

        private void ButtonProfile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Perfil());
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            History his = new History();
            this.NavigationService.Navigate(his);
        }

        private void ButtonShop_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            this.NavigationService.Navigate(order);
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Login());
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if(search_textbox.Text == "" || search_textbox.Text == " Search..")
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
            }
            else
            {
                Order_Search order = new Order_Search(search_textbox.Text);
                this.NavigationService.Navigate(order);
            }
            
        }

        private void ButtonKeySearch_Click(object sender, RoutedEventArgs e)
        {
            if(key_input.Text == "" || key_input.Text == "Key...")
            {
                MessageBox.Show("Insert medical prescription code", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(key_input.Text != "1234")
            {
                MessageBox.Show("Insert a valid medical prescription code", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                PaymentPrescription payment = new PaymentPrescription(true);
                this.NavigationService.Navigate(payment);
            }
            
        }

        private void enterPrescription(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Payment());
        }


        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            search_textbox.Text = "";
        }

        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            search_textbox.Text = "Search...";
        }

        private void keyTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            key_input.Text = "";
        }

        private void keyTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            key_input.Text = "Key...";
        }

        
    }
}
