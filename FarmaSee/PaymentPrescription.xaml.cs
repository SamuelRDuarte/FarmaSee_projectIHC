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

    public class Medicamento
    {
        private string _nome;
        private int _quantidade;
        private string _imagem;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public int Quantidade
        {
            get { return _quantidade; }
            set { _quantidade = value; }
        }

        public string Imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
    }

    public class Prescription : ObservableCollection<Medicamento>
    {
        public Prescription()
        {
            Add(new Medicamento { Nome = "Lisinopril 5 mg", Quantidade = 2 });
            Add(new Medicamento { Nome = "Ferro-Tardyferon 80mg", Quantidade = 1 });

        }
    }
    /// <summary>
    /// Interaction logic for PaymentPrescription.xaml
    /// </summary>
    public partial class PaymentPrescription : Page
    {
        private Prescription _pres;
        public PaymentPrescription( bool novo)
        {
            InitializeComponent();
            if (novo)
            {
                _pres = new Prescription();
                MainWindow.Prescricao = _pres;
            }
            else
            {
                _pres = MainWindow.Prescricao;
            }
            Medicines.ItemsSource = _pres;
        }

        private void ButtonPharmacy_Click(object sender, RoutedEventArgs e)
        {
            Search sear = new Search(false);
            MainWindow.AddFarmacia(new Farmacia { Nome = "Teste", Morada = "Olsfisf" });
            this.NavigationService.Navigate(sear);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            this.NavigationService.Navigate(home);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectFarmacia.Content == null)
            {
                MessageBox.Show("Select a pharmacy", "Erro", MessageBoxButton.OK);
            }
            else if (((bool)pickupBt.IsChecked || (bool)atHomeBt.IsChecked) && ((bool)mbWay.IsChecked || (bool)atDelivery.IsChecked))
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
            }
            else
            {
                MessageBox.Show("Select a type of payment and delivery", "Erro", MessageBoxButton.OK);
            }
        }

        private void PackIcon_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow.Prescricao.RemoveAt(Medicines.SelectedIndex);
        }

        //private void plus_click(object sender, RoutedEventArgs e)
        //{
        //    int quant = Convert.ToInt32(quantityLabel.Content);
        //    quantityLabel.Content = (quant + 1).ToString();
        //    minusButton.IsEnabled = true;
        //}

        //private void minus_click(object sender, RoutedEventArgs e)
        //{
        //    int quant = Convert.ToInt32(quantityLabel.Content);
        //    int result = quant - 1;

        //    if (result == 0)
        //    {
        //        minusButton.IsEnabled = false;
        //        quantityLabel.Content = result.ToString();
        //    }
        //    else
        //    {
        //        quantityLabel.Content = result.ToString();
        //    }
        //}
    }
}
