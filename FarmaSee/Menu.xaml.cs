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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void ButtonShop_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            this.NavigationService.Navigate(order);
        }

        private void ButtonHistory_Click(object sender, RoutedEventArgs e)
        {
            History his = new History();
            this.NavigationService.Navigate(his);
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.NavigationService.Navigate(login);
        }
    }
}
