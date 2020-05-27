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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

        private void ButtonPharmacy_Click(object sender, RoutedEventArgs e)
        {
            Search sear = new Search();
            MainWindow.AddFarmacia(new Farmacia { Nome = "Teste", Morada = "Olsfisf" });
            this.NavigationService.Navigate(sear);
        }

        private void ButtonPayment_Click(object sender, RoutedEventArgs e)
        {
            if(selectFarmacia.Content != null)
            {
                this.NavigationService.Navigate(new Payment());
            }
            else
            {
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
            }
            
        }
    }
}
