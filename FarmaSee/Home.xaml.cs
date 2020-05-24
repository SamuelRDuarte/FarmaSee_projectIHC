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

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            Lista.Visibility = Visibility.Visible;
            var bc = new BrushConverter();
            //GridMenu.Background = (Brush)bc.ConvertFrom("#0773AD");
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            Lista.Visibility= Visibility.Collapsed;
            MainGrid.Opacity = 1;
            var bc = new BrushConverter();
            //GridMenu.Background = (Brush)bc.ConvertFrom("#00517C");
        }

        private void ListViewItemHome_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Home());
        }

        private void ListViewItemShop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new Order());
        }

        private void ListViewItemHistory_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new History());
        }


    }
}
