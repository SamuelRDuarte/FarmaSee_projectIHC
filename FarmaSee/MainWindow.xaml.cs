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
        private static ListaHistorico _historico;
        private static Prescription _prescricao;
        private static ListMedicamento _medicamentos;

        public MainWindow()
        {
            InitializeComponent();
            _farmacias = new ListaFarmacias();
            _historico = new ListaHistorico();
            _prescricao = new Prescription();
            _medicamentos = new ListMedicamento();
        }

        public static ListaFarmacias Farmacias
        {
            get { return _farmacias; }
        }
        public static void AddFarmacia(Farmacia f)
        {
            _farmacias.Add(f);
        }

        public static ListaHistorico Historico
        {
            get { return _historico; }
        }
        public static void AddHistorico(Historico f)
        {
            _historico.Add(f);
        }

        public static Prescription Prescricao
        {
            get { return _prescricao; }
            set { _prescricao = value; }
        }

        public static ListMedicamento Medicamentos
        {
            get { return _medicamentos; }
        }
    }
}
