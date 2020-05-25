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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public void On_Click()
        {

            if (Farmacias.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                StackPanel stack = (StackPanel) ((ListBoxItem)Farmacias.SelectedValue).Content;
                order.selectFarmacia.Content = stack.Children.ToString();
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }

        
            
            

        private void ListBoxItem1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Farmacias.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                order.selectFarmacia.Content = "Farmácia Oudinot";
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }

        private void ListBoxItem2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Farmacias.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                order.selectFarmacia.Content = "Farmácia Central - Aveiro";
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }

        private void ListBoxItem3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Farmacias.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                order.selectFarmacia.Content = "Farmácia Nova";
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }

        private void ListBoxItem4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Farmacias.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                order.selectFarmacia.Content = "Farmácia Moderna";
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }
    }
}
