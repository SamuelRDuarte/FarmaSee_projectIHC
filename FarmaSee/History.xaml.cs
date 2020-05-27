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
    public class Compra
    {
        private string _medicamento;
        private string _farmacia;
        private string _data;
        
        public string Medicamento
        {
            set { _medicamento = value;}
            get { return _medicamento;}
        }

        public string Farmacia
        {
            set { _farmacia = value; }
            get { return _farmacia; }
        }

        public string Data
        {
            set { _data = value; }
            get { return _data; }
        }
    }

    public class ListaCompras : ObservableCollection<Compra>
    {
        public ListaCompras()
        {
            Add(new Compra { Medicamento = "Lisinopril 5mg", Farmacia = "Farmácia Oudinot", Data="14/05/2020" });
            Add(new Compra { Medicamento = "Ferro-Tardyferon 80mg", Farmacia = "Farmácia Nova", Data = "12/02/2020" });
            Add(new Compra { Medicamento = "Voltaren Gel", Farmacia = "Farmácia Nova", Data = "12/02/2020" });
            Add(new Compra { Medicamento = "Aspirina C 500 mg", Farmacia = "Farmácia Oudinot", Data = "18/12/2019" });

        }
    }

    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            InitializeComponent();
            ListBoxHistórico.ItemsSource = MainWindow.Compras;
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Menu menu = new Menu();
            this.NavigationService.Navigate(menu);
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = "";
        }

        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = " Search for medicine or pharmacy...";
        }

        private void TexBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Compra> lista;

            if (TexBoxSearch.Text.Length > 2)
            {
                lista = new ObservableCollection<Compra>(MainWindow.Compras.ToList().FindAll(fa =>
                                                                       fa.Medicamento.ToLower().Contains(TexBoxSearch.Text.ToLower()) || fa.Farmacia.ToLower().Contains(TexBoxSearch.Text.ToLower())));
                ListBoxHistórico.ItemsSource = lista;
            }
            else
            {
                ListBoxHistórico.ItemsSource = MainWindow.Compras;
            }
        }
    }
}
