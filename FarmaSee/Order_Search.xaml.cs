using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Order_Search.xaml
    /// </summary>
    public partial class Order_Search : Page
    {
        private string _pesquisa;
        public Order_Search(string pesquisa)
        {
            _pesquisa = pesquisa;
            InitializeComponent();
            TexBoxSearch.Text = pesquisa;
            Lista.ItemsSource = new ObservableCollection<Medicamento>(MainWindow.Medicamentos.ToList().GetRange(0, 2));
            Lista1.ItemsSource = new ObservableCollection<Medicamento>(MainWindow.Medicamentos.ToList<Medicamento>().FindAll(fa =>
                                                                       fa.Nome.ToLower().Contains(TexBoxSearch.Text.ToLower())));
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

        private void ButtonPharmacy_Click(object sender, RoutedEventArgs e)
        {
            Search sear = new Search(3,_pesquisa);
            this.NavigationService.Navigate(sear);
        }

        private void ButtonPayment_Click(object sender, RoutedEventArgs e)
        {
            if (selectFarmacia.Content == null && MainWindow.ShopList.Count > 0)
            {
                MessageBox.Show("Select a pharmacy", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else if (MainWindow.ShopList.Count <= 0)
                MessageBox.Show("Shopping cart empty", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            else
            {
                this.NavigationService.Navigate(new Payment());
            }

        }

        private void ButtonAddShp_Click(object sender, RoutedEventArgs e)
        {
            string med = ((Button)sender).Tag.ToString();
            Medicamento temp = MainWindow.ShopList.ToList().Find(x => x.Nome == med);
            if (temp != null)
            {
                MainWindow.ShopList.Remove(temp);
                (((Button)sender).FindName("icon") as PackIcon).Kind = PackIconKind.ShoppingCart;
            }
            else
            {
                MainWindow.ShopList.Add(MainWindow.Medicamentos.ToList().Find(x => x.Nome == med));
                (((Button)sender).FindName("icon") as PackIcon).Kind = PackIconKind.ShoppingCartOff;
            }
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = "";
        }

        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = " Search...";
        }

        private void TexBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Medicamento> lista;

            if (TexBoxSearch.Text.Length > 2)
            {
                lista = new ObservableCollection<Medicamento>(MainWindow.Medicamentos.ToList<Medicamento>().FindAll(fa =>
                                                                       fa.Nome.ToLower().Contains(TexBoxSearch.Text.ToLower())));
                Lista1.ItemsSource = lista;
            }
            else
            {
                Lista1.ItemsSource = MainWindow.Medicamentos;
            }
        }

     }
}
