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

        }
    }
    
    
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

            if (FarmaciasListBox.SelectedValue != null)
            {
                Order order = new Order();
                this.NavigationService.Navigate(order);
                Farmacia far = (Farmacia) FarmaciasListBox.SelectedValue;
                order.selectFarmacia.Content = far.Nome;
            }
            else
                MessageBox.Show("Selecione uma farmacia", "Erro", MessageBoxButton.OK);
        }


        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            On_Click();
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
