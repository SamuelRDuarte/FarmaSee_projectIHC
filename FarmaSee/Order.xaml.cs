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
    /// Interaction logic for History.xaml
    /// </summary>
    
    public class ListMedicamento : ObservableCollection<Medicamento>
    {
        public ListMedicamento()
        {
            Add(new Medicamento { Nome = "Voltaren Gel", Quantidade = 1, Imagem = "voltaren.png" });
            Add(new Medicamento { Nome = "Aspirina C 500 mg", Quantidade = 1, Imagem = "aspirina.jpg" });
            Add(new Medicamento { Nome = "Fenistil Gel", Quantidade = 1, Imagem = "fenistil-gel-300x300.jpg" });
            Add(new Medicamento { Nome = "Avamys", Quantidade = 1, Imagem = "caixa-avamys-m.jpg" });
            Add(new Medicamento { Nome = "Fenergen Pomada", Quantidade = 1, Imagem = "3d-fenergan.jpg" });
            Add(new Medicamento { Nome = "Lisinopril 5 mg", Quantidade = 2, Imagem = "lisinopril.jpg" });
            Add(new Medicamento { Nome = "Ferro-Tardyferon 80mg", Quantidade = 1, Imagem = "ferro.jpg" });

        }
    }

    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            Lista.ItemsSource=new ObservableCollection<Medicamento>(MainWindow.Medicamentos.ToList().GetRange(0, 2));
            Lista1.ItemsSource = new ObservableCollection<Medicamento>(MainWindow.Medicamentos.ToList().GetRange(2, 3));
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

        private void ButtonPharmacy_Click(object sender, RoutedEventArgs e)
        {
            Search sear = new Search(true);
            this.NavigationService.Navigate(sear);
        }

        private void ButtonPayment_Click(object sender, RoutedEventArgs e)
        {
            if(selectFarmacia.Content == null && MainWindow.ShopList.Count > 0)
            {
                MessageBox.Show("Select a pharmacy", "Error", MessageBoxButton.OK);
            }
            if (MainWindow.ShopList.Count <= 0)
                MessageBox.Show("Shopping cart empty", "Error", MessageBoxButton.OK);
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
                (((Button)sender).FindName("icon") as PackIcon).Kind = PackIconKind.ShoppingCartArrowDown;
            }
            else
            {
                MainWindow.ShopList.Add(MainWindow.Medicamentos.ToList().Find(x => x.Nome == med));
                (((Button)sender).FindName("icon") as PackIcon).Kind = PackIconKind.ShoppingCartArrowUp;
            }
        }

    }
}
