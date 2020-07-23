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

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for AdminRequisitor.xaml
    /// </summary>
    public partial class AdminRequisitor : Window
    {
        CamadaNegocio.RequisitorCollection requisitorCollection = null;

        public AdminRequisitor()
        {
            InitializeComponent();
            CamadaNegocio.RequisitorCollection requisitores = CamadaNegocio.Requisitor.ObterListaRequisitores();
            if (requisitores != null) {
            
            List<string> nomes = (from element in requisitores
                                 select element.Nome).ToList();
            this.listBoxRequesitores.DataContext = nomes;
            }

            requisitorCollection = requisitores;
        }

        private void BtnAdicionarRequisitor_Click(object sender, RoutedEventArgs e)
        {
            AddRequisitor addRequisitor = new AddRequisitor();
            addRequisitor.ShowDialog();
        }

        private void ListBoxRequesitores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnVoltarAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Admin admin = new Admin();
            admin.ShowDialog();
            admin = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String textoFiltro = this.textBoxFiltroRequesitores.Text;
            CamadaNegocio.RequisitorCollection requisitoresFiltrados = this.requisitorCollection.Filtrar(textoFiltro);



            List<string> nomes = (from element in requisitoresFiltrados
                         select element.Nome).ToList();




            this.listBoxRequesitores.DataContext = nomes;
        }
    }
}
