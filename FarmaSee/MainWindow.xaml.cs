using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        private static ListaFarmacias _farmacias;
        private static ListaCompras _compras;

        public MainWindow()
        {
            InitializeComponent();
            _farmacias = new ListaFarmacias();
            _compras = new ListaCompras();
        }

        public static ListaFarmacias Farmacias
        {
            get { return _farmacias; }
        }
        public static void AddFarmacia(Farmacia f)
        {
            _farmacias.Add(f);
        }

        public static ListaCompras Compras
        {
            get { return _compras; }
        }
        public static void AddCompra(Compra f)
        {
            _compras.Add(f);
        }



    }
}
