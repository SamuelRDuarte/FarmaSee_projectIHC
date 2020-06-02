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
using System.Windows.Shapes;

namespace FarmaSee
{
    public class Farmacia
    {
        private string _nome;
        private string _morada;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Morada
        {
            get { return _morada; }
            set { _morada = value; }
        }
    }
    
    public class ListaFarmacias : ObservableCollection<Farmacia>
    {
        public ListaFarmacias()
        {
            Add(new Farmacia { Nome = "Farmácia Oudinot", Morada= "Av. Dr. Lourenço Peixinho 145, 3800-166 Aveiro" });
            Add(new Farmacia { Nome = "Farmácia Central - Aveiro", Morada= "R. dos Mercadores 26 28, 3800-225 Aveiro" });
            Add(new Farmacia { Nome = "Farmácia Nova", Morada= "R. Dr. Mário Sacramento 131, 3810-106 Aveiro" });
            Add(new Farmacia { Nome = "Farmácia Moderna", Morada= "R. dos Combatentes da Grande Guerra 103 105, 3810-087 Aveiro" });
            Add(new Farmacia { Nome = "Farmácia Portugal De Viseu", Morada = "Av. Alberto Sampaio nº 76 3510-027 Viseu" });
            Add(new Farmacia { Nome = "Farmácia Grão Vasco", Morada = "Avenida António José de Almeida nº 230 3510-043 Viseu" });
            Add(new Farmacia { Nome = "Farmácia da Misericórdia", Morada = "Av. 10 de Junho 1, 3500-202 Viseu" });

        }
    }
    
    
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        private int _state;
        private string _pesquisa;

        public Search(int x, string pesquisa =null)
        {
            _state = x;
            _pesquisa = pesquisa;
            InitializeComponent();
            FarmaciasListBox.ItemsSource = MainWindow.Farmacias;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        public void On_Click()
        {

            if (FarmaciasListBox.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                Farmacia far = (Farmacia) FarmaciasListBox.SelectedValue;
                order.selectFarmacia.Content = far.Nome;
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        public void On_Click2()
        {

            if (FarmaciasListBox.SelectedValue != null)
            {
                PaymentPrescription order = new PaymentPrescription(false);
                this.NavigationService.Navigate(order);
                Farmacia far = (Farmacia) FarmaciasListBox.SelectedValue;
                order.selectFarmacia.Content = far.Nome;
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void On_Click3()
        {

            if (FarmaciasListBox.SelectedValue != null)
            {
                Order_Search order = new Order_Search(_pesquisa);
                this.NavigationService.Navigate(order);
                Farmacia far = (Farmacia)FarmaciasListBox.SelectedValue;
                order.selectFarmacia.Content = far.Nome;
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (_state == 1)
                On_Click2();
            else if (_state == 0)
                On_Click3();
            else
                On_Click();
           
        }

        private void searchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = "";
        }

        private void searchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TexBoxSearch.Text = " Search a farmacy...";
        }

        private void TexBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            ObservableCollection<Farmacia> lista;

            if (TexBoxSearch.Text.Length > 2)
            {
                lista = new ObservableCollection<Farmacia>(MainWindow.Farmacias.ToList<Farmacia>().FindAll(fa =>
                                                                       fa.Nome.ToLower().Contains(TexBoxSearch.Text.ToLower()) || fa.Morada.ToLower().Contains(TexBoxSearch.Text.ToLower())));
                FarmaciasListBox.ItemsSource = lista;
            }
            else
            {
                FarmaciasListBox.ItemsSource = MainWindow.Farmacias;
            }
        }

        //private void ListBoxItem2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (Farmacias.SelectedValue != null)
        //    {
        //        Order order = new Order();
        //        this.NavigationService.Navigate(order);
        //        order.selectFarmacia.Content = "Farmácia Central - Aveiro";
        //    }
        //    else
        //        MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        //}

        //private void ListBoxItem3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (Farmacias.SelectedValue != null)
        //    {
        //        Order order = new Order();
        //        this.NavigationService.Navigate(order);
        //        order.selectFarmacia.Content = "Farmácia Nova";
        //    }
        //    else
        //        MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        //}

        //private void ListBoxItem4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if (Farmacias.SelectedValue != null)
        //    {
        //        Order order = new Order();
        //        this.NavigationService.Navigate(order);
        //        order.selectFarmacia.Content = "Farmácia Moderna";
        //    }
        //    else
        //        MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        //}
    }
}
